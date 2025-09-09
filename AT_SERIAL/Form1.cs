using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using AT_SERIAL.Properties;
using System.IO;
using System.Text.RegularExpressions;
using System.Net;
using System.Web.Script.Serialization;
using System.Media;

namespace AT_SERIAL
{
    public partial class Main_form : Form
    {
        private enum State { Idle, Scanning, Connecting, Connected, Disconnecting }
        private State currentState = State.Idle;
        private DateTime lastFindClickUtc = DateTime.MinValue;
        private System.Threading.CancellationTokenSource connectCts;
        private readonly BindingList<string> availablePorts = new BindingList<string>();
        private readonly List<string> logBuffer = new List<string>();
        private readonly object logLock = new object();
        private readonly Queue<string> commandHistory = new Queue<string>();
        private int historyIndex = -1;
        private readonly List<string> persistedHistory = new List<string>();
        private string historyFilePath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "AT_SERIAL", "history.json");

        public Main_form()
        {
            InitializeComponent();
            InitializeUiState();
        }

        private void InitializeUiState()
        {
            cboPort.DataSource = availablePorts;
            // Apply saved settings if available
            cboBaud.SelectedItem = Settings.Default.LastBaud.ToString();
            if (cboBaud.SelectedIndex < 0) cboBaud.SelectedIndex = 4;
            cboDataBits.SelectedItem = Settings.Default.LastDataBits.ToString();
            if (cboDataBits.SelectedIndex < 0) cboDataBits.SelectedIndex = 1;
            cboParity.SelectedItem = Settings.Default.LastParity;
            if (cboParity.SelectedIndex < 0) cboParity.SelectedIndex = 0;
            cboStopBits.SelectedItem = Settings.Default.LastStopBits;
            if (cboStopBits.SelectedIndex < 0) cboStopBits.SelectedIndex = 0;
            cboFlow.SelectedItem = Settings.Default.LastFlow;
            if (cboFlow.SelectedIndex < 0) cboFlow.SelectedIndex = 0;
            // Default to append CR/LF for reliable command termination
            chkCRLF.Checked = true;
            // Hacker terminal style for log: bright green text on black background
            rtbLog.BackColor = Color.Black;
            rtbLog.ForeColor = Color.Lime;
            rtbLog.Font = new System.Drawing.Font("Consolas", 10F);
            SetState(State.Idle, "Idle. Select a port.");
            UpdateStatus();
        }

        private void SetState(State newState, string statusMessage = null)
        {
            currentState = newState;
            // Toggle Connect/Disconnect visibility at the same visual place
            btnConnect.Visible = (newState == State.Idle || newState == State.Scanning || newState == State.Connecting);
            btnDisconnect.Visible = (newState == State.Connected || newState == State.Disconnecting);

            // Base texts
            btnFindPorts.Text = (newState == State.Scanning) ? "Finding..." : "Find Ports";
            btnConnect.Text = (newState == State.Connecting) ? "Connecting..." : "Connect";
            btnDisconnect.Text = (newState == State.Disconnecting) ? "Disconnecting..." : "Disconnect";

            // Enable/disable rules
            bool combosEnabled = (newState == State.Idle);
            bool findEnabled = (newState == State.Idle);
            bool connectEnabled = (newState == State.Idle);
            bool disconnectEnabled = (newState == State.Connected);

            btnFindPorts.Enabled = findEnabled;
            btnConnect.Enabled = connectEnabled;
            btnDisconnect.Enabled = disconnectEnabled;

            cboPort.Enabled = combosEnabled;
            cboBaud.Enabled = combosEnabled;
            cboDataBits.Enabled = combosEnabled;
            cboParity.Enabled = combosEnabled;
            cboStopBits.Enabled = combosEnabled;
            cboFlow.Enabled = combosEnabled;
            chkCRLF.Enabled = combosEnabled;

            // Log/search controls read-only when not idle/connected
            txtSearch.ReadOnly = !combosEnabled;
            chkShowRX.Enabled = combosEnabled;
            chkShowTX.Enabled = combosEnabled;

            if (!string.IsNullOrEmpty(statusMessage))
            {
                lblStatusPort.Text = statusMessage;
            }
        }

        private void Main_form_Load(object sender, EventArgs e)
        {
            FindPorts();
            if (!string.IsNullOrEmpty(Settings.Default.LastPort))
            {
                var idx = availablePorts.IndexOf(Settings.Default.LastPort);
                if (idx >= 0) cboPort.SelectedIndex = idx;
            }
            EnsureTrialStart();
            UpdateTrialLabel();
            InitializeCommandMode();
            InitializeScriptMode();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSupport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Support: support@example.com", "Support", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSysInfo_Click(object sender, EventArgs e)
        {
            var info = $"OS: {Environment.OSVersion}\r\n64-bit: {Environment.Is64BitOperatingSystem}\r\nMachine: {Environment.MachineName}";
            MessageBox.Show(info, "System Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            lock (logLock)
            {
                logBuffer.Clear();
            }
            ApplyFiltersAndRender();
        }

        private void btnSaveLog_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog { Filter = "Text Files (*.txt)|*.txt|CSV (*.csv)|*.csv", FileName = "at_log.txt" })
            {
                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    System.IO.File.WriteAllLines(sfd.FileName, logBuffer);
                }
            }
        }

        private async void btnFindPorts_Click(object sender, EventArgs e)
        {
            // Debounce 500–800ms
            var now = DateTime.UtcNow;
            if ((now - lastFindClickUtc).TotalMilliseconds < 500) return;
            lastFindClickUtc = now;

            SetState(State.Scanning, "Scanning serial ports...");
            btnFindPorts.Enabled = false;
            await Task.Delay(600);

            var before = availablePorts.ToList();
            FindPorts();
            var after = availablePorts.ToList();
            var newOnes = after.Except(before, StringComparer.OrdinalIgnoreCase).ToList();

            if (after.Count == 0)
            {
                lblStatusPort.Text = "No serial ports found. Reconnect your device.";
            }
            else if (newOnes.Count == 1)
            {
                var np = newOnes[0];
                var idx = availablePorts.IndexOf(np);
                if (idx >= 0) cboPort.SelectedIndex = idx;
                lblStatusPort.Text = "Detected new port: " + np;
            }

            SetState(State.Idle);
            btnFindPorts.Enabled = true;
        }

        private void FindPorts()
        {
            var ports = SerialPort.GetPortNames().OrderBy(p => p, StringComparer.OrdinalIgnoreCase).ToArray();
            availablePorts.Clear();
            foreach (var p in ports) availablePorts.Add(p);
            if (availablePorts.Count > 0) cboPort.SelectedIndex = 0;
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            if (cboPort.SelectedItem == null)
            {
                SystemSounds.Beep.Play();
                SetState(State.Idle, "Select a port");
                return;
            }

            try
            {
                SetState(State.Connecting, "Opening port...");
                connectCts?.Cancel();
                connectCts = new System.Threading.CancellationTokenSource(TimeSpan.FromSeconds(4));
                var ct = connectCts.Token;

                var portName = cboPort.SelectedItem as string;
                var baud = int.Parse(cboBaud.SelectedItem as string ?? "115200");
                var flow = cboFlow.SelectedItem as string ?? "None";
                var useRtsCts = string.Equals(flow, "RTS/CTS", StringComparison.OrdinalIgnoreCase);

                await Task.Run(() =>
                {
                    if (serialPort.IsOpen) serialPort.Close();
                    serialPort.PortName = portName;
                    serialPort.BaudRate = baud;
                    serialPort.DataBits = 8;
                    serialPort.Parity = Parity.None;
                    serialPort.StopBits = StopBits.One;
                    serialPort.Handshake = useRtsCts ? Handshake.RequestToSend : Handshake.None;
                    serialPort.DtrEnable = true;
                    serialPort.RtsEnable = useRtsCts;
                    serialPort.NewLine = "\r\n";
                    serialPort.Open();
                }, ct).ConfigureAwait(true);

                AppendLog($"[PORT] Opened {serialPort.PortName} @ {serialPort.BaudRate}", isTx:false);
                PersistPortSelection();
                SetState(State.Connected, $"Connected to {serialPort.PortName} @{serialPort.BaudRate}");
                UpdateStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connect failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetState(State.Idle, "Idle. Select a port.");
            }
        }

        private async void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                SetState(State.Disconnecting, "Closing port...");
                connectCts?.Cancel();
                await Task.Run(() =>
                {
                    try
                    {
                        if (serialPort.IsOpen)
                        {
                            serialPort.DiscardInBuffer();
                            serialPort.DiscardOutBuffer();
                            serialPort.Close();
                        }
                    }
                    catch { }
                }).ConfigureAwait(true);
                AppendLog("[PORT] Closed", isTx:false);
                SetState(State.Idle, "Disconnected.");
                UpdateStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Disconnect failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetState(State.Idle, "Idle. Select a port.");
            }
        }

        private void ApplyFlowControl()
        {
            var flow = cboFlow.SelectedItem as string ?? "None";
            switch (flow)
            {
                case "RTS/CTS":
                    serialPort.Handshake = Handshake.RequestToSend;
                    break;
                case "XON/XOFF":
                    serialPort.Handshake = Handshake.XOnXOff;
                    break;
                default:
                    serialPort.Handshake = Handshake.None;
                    break;
            }
        }

        private static StopBits ParseStopBits(string s)
        {
            if (s == "1") return StopBits.One;
            if (s == "1.5") return StopBits.OnePointFive;
            if (s == "2") return StopBits.Two;
            return StopBits.One;
        }

        private void txtCmd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SendCommand(txtCmd.Text);
                if (!string.IsNullOrWhiteSpace(txtCmd.Text))
                {
                    commandHistory.Enqueue(txtCmd.Text);
                    while (commandHistory.Count > 50) commandHistory.Dequeue();
                }
                historyIndex = -1;
                txtCmd.Clear();
            }
            else if (e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;
                if (commandHistory.Count > 0)
                {
                    if (historyIndex == -1) historyIndex = commandHistory.Count - 1;
                    else historyIndex = Math.Max(0, historyIndex - 1);
                    txtCmd.Text = commandHistory.ElementAt(historyIndex);
                    txtCmd.SelectionStart = txtCmd.TextLength;
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                e.SuppressKeyPress = true;
                if (commandHistory.Count > 0)
                {
                    if (historyIndex == -1) return;
                    historyIndex = Math.Min(commandHistory.Count - 1, historyIndex + 1);
                    txtCmd.Text = commandHistory.ElementAt(historyIndex);
                    txtCmd.SelectionStart = txtCmd.TextLength;
                }
            }
        }

        private void SendCommand(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return;
            if (!serialPort.IsOpen)
            {
                MessageBox.Show("Port is not open.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var data = text;
            // Ensure proper line termination: at least CR, or CRLF if enabled
            if (chkCRLF.Checked)
            {
                if (!data.EndsWith("\n")) data = data.TrimEnd('\r') + "\r\n";
            }
            else
            {
                if (!data.EndsWith("\r") && !data.EndsWith("\n")) data += "\r";
            }
            try
            {
                serialPort.Write(data);
                AppendLog($"> {text}", isTx:true);
            }
            catch (Exception ex)
            {
                AppendLog("[TX ERROR] " + ex.Message, isTx:true);
            }
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                var incoming = serialPort.ReadExisting();
                AppendLogThreadSafe(incoming, isTx:false);
                BeginInvoke((Action)UpdateStatusSignals);
                lock (rxAccumulator)
                {
                    rxAccumulator.Append(incoming);
                    var snapshot = rxAccumulator.ToString();
                    // deliver minimal response up to OK/ERROR or prompt
                    if (snapshot.Contains("\r\nOK\r\n") || snapshot.Contains("\r\nERROR\r\n") || snapshot.TrimEnd().EndsWith(">"))
                    {
                        readTcs?.TrySetResult(snapshot);
                    }
                }
            }
            catch { }
        }

        private void AppendLogThreadSafe(string text, bool isTx)
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action)(() => AppendLog(text, isTx)));
            }
            else
            {
                AppendLog(text, isTx);
            }
        }

        private void AppendLog(string text, bool isTx)
        {
            var lines = text.Replace("\r", string.Empty).Split('\n');
            var ts = DateTime.Now.ToString("HH:mm:ss.fff");
            lock (logLock)
            {
                foreach (var line in lines)
                {
                    if (line.Length == 0) continue;
                    var prefix = isTx ? "TX" : "RX";
                    logBuffer.Add($"[{ts}] {prefix}: {line}");
                }
            }
            ApplyFiltersAndRender();
        }

        private void ApplyFiltersAndRender()
        {
            if (rtbLog.IsDisposed) return;
            string search = txtSearch.Text?.Trim() ?? string.Empty;
            bool showRx = chkShowRX.Checked;
            bool showTx = chkShowTX.Checked;
            List<string> view;
            lock (logLock)
            {
                view = logBuffer.Where(l =>
                    ((showRx && l.Contains(" RX:")) || (showTx && l.Contains(" TX:"))) &&
                    (search.Length == 0 || l.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0)
                ).ToList();
            }
            rtbLog.SuspendLayout();
            rtbLog.Text = string.Join("\r\n", view);
            rtbLog.SelectionStart = rtbLog.TextLength;
            rtbLog.ScrollToCaret();
            rtbLog.ResumeLayout();
            lblLineCount.Text = "Lines: " + view.Count.ToString();
            UpdateStatus();
        }

        private void rtbLog_TextChanged(object sender, EventArgs e)
        {
            // No-op handler to satisfy designer wiring if present
        }

        private void FilterChanged(object sender, EventArgs e)
        {
            ApplyFiltersAndRender();
        }

        private void PersistPortSelection()
        {
            Settings.Default.LastPort = cboPort.SelectedItem as string;
            Settings.Default.LastBaud = int.Parse(cboBaud.SelectedItem as string ?? "115200");
            Settings.Default.LastDataBits = int.Parse(cboDataBits.SelectedItem as string ?? "8");
            Settings.Default.LastParity = cboParity.SelectedItem as string ?? "None";
            Settings.Default.LastStopBits = cboStopBits.SelectedItem as string ?? "1";
            Settings.Default.LastFlow = cboFlow.SelectedItem as string ?? "None";
            Settings.Default.Save();
        }

        private void EnsureTrialStart()
        {
            if (Settings.Default.TrialStart == DateTime.MinValue)
            {
                Settings.Default.TrialStart = DateTime.UtcNow.Date;
                Settings.Default.Save();
            }
        }

        private void UpdateTrialLabel()
        {
            var days = 7 - (int)(DateTime.UtcNow.Date - Settings.Default.TrialStart.Date).TotalDays;
            if (days < 0) days = 0;
            lblLicense.Text = days > 0 ? $"Trial: {days} days left" : "Trial expired";
        }

        private void InitializeCommandMode()
        {
            // monospace
            var mono = new System.Drawing.Font("Consolas", 9F);
            txtCmdModeInput.Font = mono;
            // snippets
            cboCmdSnippets.Items.Clear();
            cboCmdSnippets.Items.AddRange(new object[] { "ATI", "AT+CSQ", "AT+CMGF=1", "AT+CPIN?", "AT+CREG?", "AT+COPS?" });
            // load history
            try
            {
                var dir = Path.GetDirectoryName(historyFilePath);
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
                if (File.Exists(historyFilePath))
                {
                    var json = File.ReadAllText(historyFilePath);
                    var serializer = new JavaScriptSerializer();
                    var arr = serializer.Deserialize<List<string>>(json) ?? new List<string>();
                    persistedHistory.Clear();
                    persistedHistory.AddRange(arr);
                }
            }
            catch { }
            RefreshHistoryListBox();
        }

        private void RefreshHistoryListBox()
        {
            lstCmdHistory.Items.Clear();
            foreach (var item in Enumerable.Reverse(persistedHistory).Take(200))
            {
                lstCmdHistory.Items.Add(item);
            }
        }

        private void SaveHistory()
        {
            try
            {
                var dir = Path.GetDirectoryName(historyFilePath);
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(persistedHistory.Distinct().Take(500).ToList());
                File.WriteAllText(historyFilePath, json);
            }
            catch { }
        }

        private void txtCmdModeInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnCmdModeSend_Click(sender, EventArgs.Empty);
            }
        }

        private void btnCmdModeSend_Click(object sender, EventArgs e)
        {
            var cmd = txtCmdModeInput.Text.Trim();
            if (string.IsNullOrEmpty(cmd)) return;
            if (chkCmdModeCrLf.Checked && !cmd.EndsWith("\\r") && !cmd.EndsWith("\\n"))
            {
                // console level already appends CRLF when option enabled in main panel
            }
            SendCommand(cmd);
            persistedHistory.Add(cmd);
            SaveHistory();
            RefreshHistoryListBox();
        }

        private void cboCmdSnippets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCmdSnippets.SelectedIndex >= 0)
            {
                txtCmdModeInput.Text = cboCmdSnippets.SelectedItem as string;
                txtCmdModeInput.SelectionStart = txtCmdModeInput.TextLength;
                txtCmdModeInput.Focus();
            }
        }

        private void lstCmdHistory_DoubleClick(object sender, EventArgs e)
        {
            if (lstCmdHistory.SelectedItem is string s)
            {
                txtCmdModeInput.Text = s;
                txtCmdModeInput.SelectionStart = s.Length;
                txtCmdModeInput.Focus();
                SendCommand(s);
            }
        }

        // Script Mode
        private class ScriptModel
        {
            public string name { get; set; }
            public List<ScriptStep> steps { get; set; }
        }
        private class ScriptStep
        {
            public string send { get; set; }
            public string expect { get; set; }
            public int? timeout { get; set; }
        }

        private System.Threading.CancellationTokenSource scriptCts;

        private void InitializeScriptMode()
        {
            gridScriptResults.Columns.Clear();
            gridScriptResults.Columns.Add("colId", "#");
            gridScriptResults.Columns.Add("colCmd", "Command");
            gridScriptResults.Columns.Add("colExpect", "Expect");
            gridScriptResults.Columns.Add("colResult", "Result");
            gridScriptResults.Columns.Add("colLatency", "Latency (ms)");
            gridScriptResults.Rows.Clear();
            txtScriptEditor.Font = new System.Drawing.Font("Consolas", 9F);
        }

        private void btnScriptOpen_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog { Filter = "Script Files (*.json;*.yaml;*.yml)|*.json;*.yaml;*.yml|All files|*.*" })
            {
                if (ofd.ShowDialog(this) == DialogResult.OK)
                {
                    txtScriptEditor.Text = File.ReadAllText(ofd.FileName);
                }
            }
        }

        private void btnScriptSave_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog { Filter = "Script Files (*.json;*.yaml)|*.json;*.yaml", FileName = "script.json" })
            {
                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    File.WriteAllText(sfd.FileName, txtScriptEditor.Text);
                }
            }
        }

        private async void btnScriptRun_Click(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen) { MessageBox.Show("Open a port first."); return; }
            scriptCts?.Cancel();
            scriptCts = new System.Threading.CancellationTokenSource();
            var ct = scriptCts.Token;
            gridScriptResults.Rows.Clear();
            var script = ParseScript(txtScriptEditor.Text);
            if (script == null || script.steps == null || script.steps.Count == 0) { MessageBox.Show("Invalid script."); return; }
            var variables = new Dictionary<string, string>();
            int index = 1;
            foreach (var step in script.steps)
            {
                if (ct.IsCancellationRequested) break;
                var rowIndex = gridScriptResults.Rows.Add(index.ToString(), step.send, step.expect, "Running...", "");
                var started = DateTime.UtcNow;
                try
                {
                    var timeout = TimeSpan.FromMilliseconds(step.timeout ?? 3000);
                    var resp = await SendCommandAndReadAsync(ReplaceVars(step.send, variables), timeout);
                    var ok = Regex.IsMatch(resp ?? string.Empty, step.expect ?? "OK", RegexOptions.Multiline);
                    var latency = (int)(DateTime.UtcNow - started).TotalMilliseconds;
                    gridScriptResults.Rows[rowIndex].Cells[3].Value = ok ? "Pass" : "Fail";
                    gridScriptResults.Rows[rowIndex].Cells[4].Value = latency.ToString();
                    // capture groups into ${1}, ${2}...
                    var m = Regex.Match(resp ?? string.Empty, step.expect ?? string.Empty, RegexOptions.Multiline);
                    if (m.Success)
                    {
                        for (int i = 1; i < m.Groups.Count; i++)
                        {
                            variables["$" + i.ToString()] = m.Groups[i].Value;
                        }
                    }
                }
                catch (Exception ex)
                {
                    gridScriptResults.Rows[rowIndex].Cells[3].Value = "Fail";
                    gridScriptResults.Rows[rowIndex].Cells[4].Value = "-";
                    AppendLog("[SCRIPT ERROR] " + ex.Message, isTx:false);
                }
                index++;
            }
        }

        private void btnScriptStop_Click(object sender, EventArgs e)
        {
            scriptCts?.Cancel();
        }

        private void btnScriptExport_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog { Filter = "CSV (*.csv)|*.csv|HTML (*.html)|*.html", FileName = "report.csv" })
            {
                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    if (Path.GetExtension(sfd.FileName).Equals(".html", StringComparison.OrdinalIgnoreCase))
                        ExportResultsHtml(sfd.FileName);
                    else
                        ExportResultsCsv(sfd.FileName);
                }
            }
        }

        private string ReplaceVars(string input, Dictionary<string, string> vars)
        {
            if (string.IsNullOrEmpty(input)) return input;
            foreach (var kv in vars)
            {
                input = input.Replace(kv.Key, kv.Value);
            }
            return input;
        }

        private ScriptModel ParseScript(string text)
        {
            try
            {
                text = text?.Trim() ?? string.Empty;
                if (text.StartsWith("{") || text.StartsWith("["))
                {
                    var serializer = new JavaScriptSerializer();
                    return serializer.Deserialize<ScriptModel>(text);
                }
                else
                {
                    // minimal YAML support: convert to JSON using a naive approach or require JSON for now
                    // For now, try a very naive parse for simple YAML structure specified in requirements
                    return ParseSimpleYaml(text);
                }
            }
            catch
            {
                return null;
            }
        }

        private ScriptModel ParseSimpleYaml(string yaml)
        {
            var model = new ScriptModel { name = "yaml", steps = new List<ScriptStep>() };
            var lines = yaml.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
            ScriptStep current = null;
            foreach (var raw in lines)
            {
                var line = raw.Trim();
                if (string.IsNullOrWhiteSpace(line)) continue;
                if (line.StartsWith("name:")) { model.name = line.Substring(5).Trim(); continue; }
                if (line.StartsWith("- "))
                {
                    current = new ScriptStep();
                    model.steps.Add(current);
                    continue;
                }
                if (current != null)
                {
                    if (line.StartsWith("send:")) current.send = line.Substring(5).Trim().Trim('"');
                    else if (line.StartsWith("expect:")) current.expect = line.Substring(7).Trim().Trim('"');
                    else if (line.StartsWith("timeout:")) { if (int.TryParse(line.Substring(8).Trim(), out var t)) current.timeout = t; }
                }
            }
            return model;
        }

        private void ExportResultsCsv(string path)
        {
            var sb = new StringBuilder();
            sb.AppendLine("#;Command;Expect;Result;Latency(ms)");
            foreach (DataGridViewRow row in gridScriptResults.Rows)
            {
                if (row.IsNewRow) continue;
                sb.AppendLine(string.Join(",", new[]
                {
                    row.Cells[0].Value?.ToString(),
                    EscapeCsv(row.Cells[1].Value?.ToString()),
                    EscapeCsv(row.Cells[2].Value?.ToString()),
                    row.Cells[3].Value?.ToString(),
                    row.Cells[4].Value?.ToString(),
                }));
            }
            File.WriteAllText(path, sb.ToString());
        }

        private void ExportResultsHtml(string path)
        {
            var sb = new StringBuilder();
            sb.AppendLine("<html><head><meta charset=\"utf-8\"><style>table{border-collapse:collapse}td,th{border:1px solid #ccc;padding:4px}</style></head><body>");
            sb.AppendLine("<table><tr><th>#</th><th>Command</th><th>Expect</th><th>Result</th><th>Latency(ms)</th></tr>");
            foreach (DataGridViewRow row in gridScriptResults.Rows)
            {
                if (row.IsNewRow) continue;
                sb.AppendLine("<tr>" + string.Join("", new[]
                {
                    Td(row.Cells[0].Value?.ToString()),
                    Td(WebUtility.HtmlEncode(row.Cells[1].Value?.ToString() ?? string.Empty)),
                    Td(WebUtility.HtmlEncode(row.Cells[2].Value?.ToString() ?? string.Empty)),
                    Td(row.Cells[3].Value?.ToString()),
                    Td(row.Cells[4].Value?.ToString()),
                }) + "</tr>");
            }
            sb.AppendLine("</table></body></html>");
            File.WriteAllText(path, sb.ToString());
        }

        private static string EscapeCsv(string s)
        {
            if (s == null) return string.Empty;
            if (s.Contains(",") || s.Contains("\"") || s.Contains("\n"))
            {
                return "\"" + s.Replace("\"", "\"\"") + "\"";
            }
            return s;
        }

        private static string Td(string s) => "<td>" + (s ?? string.Empty) + "</td>";

        private async void btnDiagRun_Click(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen)
            {
                MessageBox.Show("Open a port first.");
                return;
            }
            txtDiagOutput.Clear();
            var lines = new[] { "AT", "ATI", "AT+CGMM", "AT+CSQ", "AT+CREG?" };
            foreach (var cmd in lines)
            {
                var resp = await SendCommandAndReadAsync(cmd, TimeSpan.FromMilliseconds(800));
                txtDiagOutput.AppendText($"> {cmd}\r\n{resp}\r\n");
            }
        }

        private async void btnSimCpin_Click(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen) { MessageBox.Show("Open a port first."); return; }
            var resp = await SendCommandAndReadAsync("AT+CPIN?", TimeSpan.FromMilliseconds(800));
            txtSimOutput.AppendText($"CPIN?\r\n{resp}\r\n");
        }

        private async void btnSimEnterPin_Click(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen) { MessageBox.Show("Open a port first."); return; }
            var pin = txtPin.Text.Trim();
            if (string.IsNullOrEmpty(pin)) { MessageBox.Show("Enter PIN."); return; }
            var resp = await SendCommandAndReadAsync($"AT+CPIN=\"{pin}\"", TimeSpan.FromMilliseconds(1500));
            txtSimOutput.AppendText($"Enter PIN\r\n{resp}\r\n");
        }

        private async void btnSimReadIds_Click(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen) { MessageBox.Show("Open a port first."); return; }
            var iccid = await SendCommandAndReadAsync("AT+CCID", TimeSpan.FromMilliseconds(800));
            var imsi = await SendCommandAndReadAsync("AT+CIMI", TimeSpan.FromMilliseconds(800));
            var oper = await SendCommandAndReadAsync("AT+COPS?", TimeSpan.FromMilliseconds(800));
            txtSimOutput.AppendText($"ICCID\r\n{iccid}\r\nIMSI\r\n{imsi}\r\nOperator\r\n{oper}\r\n");
        }

        private TaskCompletionSource<string> readTcs;
        private readonly StringBuilder rxAccumulator = new StringBuilder();

        private async Task<string> SendCommandAndReadAsync(string cmd, TimeSpan timeout)
        {
            var tcs = new TaskCompletionSource<string>();
            readTcs = tcs;
            rxAccumulator.Clear();
            SendCommand(cmd);
            using (var cts = new System.Threading.CancellationTokenSource(timeout))
            {
                using (cts.Token.Register(() => tcs.TrySetResult(rxAccumulator.ToString())))
                {
                    var result = await tcs.Task.ConfigureAwait(true);
                    return result;
                }
            }
        }

        private async void btnSmsSend_Click(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen) { MessageBox.Show("Open a port first."); return; }
            var phone = txtSmsPhone.Text.Trim();
            var msg = txtSmsMsg.Text;
            if (string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(msg)) { MessageBox.Show("Enter phone and message."); return; }
            try
            {
                // Set text mode
                await SendCommandAndReadAsync("AT+CMGF=1", TimeSpan.FromMilliseconds(800));
                // Start CMGS
                var start = await SendCommandAndReadAsync($"AT+CMGS=\"{phone}\"", TimeSpan.FromMilliseconds(1500));
                // After prompt, send body + Ctrl+Z
                serialPort.Write(msg + "\x1A");
                var resp = await SendCommandAndReadAsync(string.Empty, TimeSpan.FromMilliseconds(6000));
                txtSmsOut.Text = resp.Replace("\r\n", " ").Trim();
            }
            catch (Exception ex)
            {
                txtSmsOut.Text = "SMS send error: " + ex.Message;
            }
        }

        private async void btnUssdSend_Click(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen) { MessageBox.Show("Open a port first."); return; }
            var code = txtUssd.Text.Trim();
            if (string.IsNullOrEmpty(code)) { MessageBox.Show("Enter USSD code."); return; }
            try
            {
                await SendCommandAndReadAsync("AT+CUSD=1", TimeSpan.FromMilliseconds(800));
                var resp = await SendCommandAndReadAsync($"AT+CUSD=1,\"{code}\",15", TimeSpan.FromMilliseconds(15000));
                txtUssdOut.Text = resp;
            }
            catch (Exception ex)
            {
                txtUssdOut.Text = "USSD error: " + ex.Message;
            }
        }

        private void UpdateStatus()
        {
            lblStatusPort.Text = "Port: " + (serialPort.IsOpen ? serialPort.PortName : "N/A");
            lblStatusBaud.Text = "Baud: " + (serialPort.IsOpen ? serialPort.BaudRate.ToString() : "N/A");
            UpdateStatusSignals();
        }

        private void UpdateStatusSignals()
        {
            if (!serialPort.IsOpen)
            {
                lblCtsRts.Text = "CTS/RTS: N/A";
                return;
            }
            try
            {
                lblCtsRts.Text = $"CTS: {(serialPort.CtsHolding ? "1" : "0")} | RTS: {(serialPort.DsrHolding ? "1" : "0")}";
            }
            catch { }
        }
    }
}
