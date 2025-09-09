
namespace AT_SERIAL
{
    partial class Main_form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.btnSupport = new System.Windows.Forms.ToolStripButton();
            this.btnSysInfo = new System.Windows.Forms.ToolStripButton();
            this.btnClearLog = new System.Windows.Forms.ToolStripButton();
            this.btnSaveLog = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lblLicense = new System.Windows.Forms.ToolStripLabel();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.tabLeft = new System.Windows.Forms.TabControl();
            this.tabConnection = new System.Windows.Forms.TabPage();
            this.groupPort = new System.Windows.Forms.GroupBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnFindPorts = new System.Windows.Forms.Button();
            this.cboFlow = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboStopBits = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboParity = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboDataBits = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboBaud = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboPort = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupDiagnostics = new System.Windows.Forms.GroupBox();
            this.btnDiagRun = new System.Windows.Forms.Button();
            this.txtDiagOutput = new System.Windows.Forms.TextBox();
            this.tabSIM = new System.Windows.Forms.TabPage();
            this.groupSIM = new System.Windows.Forms.GroupBox();
            this.btnSimCpin = new System.Windows.Forms.Button();
            this.txtPin = new System.Windows.Forms.TextBox();
            this.btnSimEnterPin = new System.Windows.Forms.Button();
            this.btnSimReadIds = new System.Windows.Forms.Button();
            this.txtSimOutput = new System.Windows.Forms.TextBox();
            this.tabSMS = new System.Windows.Forms.TabPage();
            this.groupSMS = new System.Windows.Forms.GroupBox();
            this.lblSmsPhone = new System.Windows.Forms.Label();
            this.txtSmsPhone = new System.Windows.Forms.TextBox();
            this.btnSmsSend = new System.Windows.Forms.Button();
            this.lblSmsMsg = new System.Windows.Forms.Label();
            this.txtSmsMsg = new System.Windows.Forms.TextBox();
            this.txtSmsOut = new System.Windows.Forms.TextBox();
            this.tabUSSD = new System.Windows.Forms.TabPage();
            this.groupUSSD = new System.Windows.Forms.GroupBox();
            this.lblUssd = new System.Windows.Forms.Label();
            this.txtUssd = new System.Windows.Forms.TextBox();
            this.btnUssdSend = new System.Windows.Forms.Button();
            this.txtUssdOut = new System.Windows.Forms.TextBox();
            this.tabNetwork = new System.Windows.Forms.TabPage();
            this.tabGPS = new System.Windows.Forms.TabPage();
            this.tabSignal = new System.Windows.Forms.TabPage();
            this.tabCmdMode = new System.Windows.Forms.TabPage();
            this.groupCmdMode = new System.Windows.Forms.GroupBox();
            this.txtCmdModeInput = new System.Windows.Forms.TextBox();
            this.btnCmdModeSend = new System.Windows.Forms.Button();
            this.chkCmdModeCrLf = new System.Windows.Forms.CheckBox();
            this.cboCmdSnippets = new System.Windows.Forms.ComboBox();
            this.lstCmdHistory = new System.Windows.Forms.ListBox();
            this.tabScript = new System.Windows.Forms.TabPage();
            this.groupScript = new System.Windows.Forms.GroupBox();
            this.btnScriptOpen = new System.Windows.Forms.Button();
            this.btnScriptSave = new System.Windows.Forms.Button();
            this.btnScriptRun = new System.Windows.Forms.Button();
            this.btnScriptStop = new System.Windows.Forms.Button();
            this.btnScriptExport = new System.Windows.Forms.Button();
            this.txtScriptEditor = new System.Windows.Forms.TextBox();
            this.gridScriptResults = new System.Windows.Forms.DataGridView();
            this.tabSnapshot = new System.Windows.Forms.TabPage();
            this.panelRight = new System.Windows.Forms.Panel();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.groupLogFilters = new System.Windows.Forms.GroupBox();
            this.chkShowTX = new System.Windows.Forms.CheckBox();
            this.chkShowRX = new System.Windows.Forms.CheckBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelCmd = new System.Windows.Forms.Panel();
            this.chkCRLF = new System.Windows.Forms.CheckBox();
            this.txtCmd = new System.Windows.Forms.TextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatusPort = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusBaud = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCtsRts = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLineCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.toolStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.tabLeft.SuspendLayout();
            this.tabConnection.SuspendLayout();
            this.groupPort.SuspendLayout();
            this.groupDiagnostics.SuspendLayout();
            this.tabSIM.SuspendLayout();
            this.groupSIM.SuspendLayout();
            this.tabSMS.SuspendLayout();
            this.groupSMS.SuspendLayout();
            this.tabUSSD.SuspendLayout();
            this.groupUSSD.SuspendLayout();
            this.tabCmdMode.SuspendLayout();
            this.groupCmdMode.SuspendLayout();
            this.tabScript.SuspendLayout();
            this.groupScript.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridScriptResults)).BeginInit();
            this.panelRight.SuspendLayout();
            this.groupLogFilters.SuspendLayout();
            this.panelCmd.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMain
            // 
            this.toolStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExit,
            this.btnSupport,
            this.btnSysInfo,
            this.btnClearLog,
            this.btnSaveLog,
            this.toolStripSeparator1,
            this.lblLicense});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(1200, 27);
            this.toolStripMain.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(37, 24);
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSupport
            // 
            this.btnSupport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSupport.Name = "btnSupport";
            this.btnSupport.Size = new System.Drawing.Size(66, 24);
            this.btnSupport.Text = "Support";
            this.btnSupport.Click += new System.EventHandler(this.btnSupport_Click);
            // 
            // btnSysInfo
            // 
            this.btnSysInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSysInfo.Name = "btnSysInfo";
            this.btnSysInfo.Size = new System.Drawing.Size(64, 24);
            this.btnSysInfo.Text = "Sys Info";
            this.btnSysInfo.Click += new System.EventHandler(this.btnSysInfo_Click);
            // 
            // btnClearLog
            // 
            this.btnClearLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(76, 24);
            this.btnClearLog.Text = "Clear Log";
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // btnSaveLog
            // 
            this.btnSaveLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSaveLog.Name = "btnSaveLog";
            this.btnSaveLog.Size = new System.Drawing.Size(73, 24);
            this.btnSaveLog.Text = "Save Log";
            this.btnSaveLog.Click += new System.EventHandler(this.btnSaveLog_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // lblLicense
            // 
            this.lblLicense.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblLicense.Name = "lblLicense";
            this.lblLicense.Size = new System.Drawing.Size(112, 24);
            this.lblLicense.Text = "Trial: 7 days left";
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 27);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.tabLeft);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.panelRight);
            this.splitContainerMain.Size = new System.Drawing.Size(1200, 672);
            this.splitContainerMain.SplitterDistance = 420;
            this.splitContainerMain.TabIndex = 1;
            // 
            // tabLeft
            // 
            this.tabLeft.Controls.Add(this.tabConnection);
            this.tabLeft.Controls.Add(this.tabCmdMode);
            this.tabLeft.Controls.Add(this.tabSIM);
            this.tabLeft.Controls.Add(this.tabSMS);
            this.tabLeft.Controls.Add(this.tabUSSD);
            this.tabLeft.Controls.Add(this.tabNetwork);
            this.tabLeft.Controls.Add(this.tabGPS);
            this.tabLeft.Controls.Add(this.tabSignal);
            this.tabLeft.Controls.Add(this.tabScript);
            this.tabLeft.Controls.Add(this.tabSnapshot);
            this.tabLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabLeft.Location = new System.Drawing.Point(0, 0);
            this.tabLeft.Name = "tabLeft";
            this.tabLeft.SelectedIndex = 0;
            this.tabLeft.Size = new System.Drawing.Size(420, 672);
            this.tabLeft.TabIndex = 0;
            // 
            // tabConnection
            // 
            this.tabConnection.Controls.Add(this.groupPort);
            this.tabConnection.Controls.Add(this.groupDiagnostics);
            this.tabConnection.Location = new System.Drawing.Point(4, 25);
            this.tabConnection.Name = "tabConnection";
            this.tabConnection.Padding = new System.Windows.Forms.Padding(3);
            this.tabConnection.Size = new System.Drawing.Size(412, 643);
            this.tabConnection.TabIndex = 0;
            this.tabConnection.Text = "Connection/Diagnostics";
            this.tabConnection.UseVisualStyleBackColor = true;
            // 
            // groupPort
            // 
            this.groupPort.Controls.Add(this.btnDisconnect);
            this.groupPort.Controls.Add(this.btnConnect);
            this.groupPort.Controls.Add(this.btnFindPorts);
            this.groupPort.Controls.Add(this.cboFlow);
            this.groupPort.Controls.Add(this.label7);
            this.groupPort.Controls.Add(this.cboStopBits);
            this.groupPort.Controls.Add(this.label6);
            this.groupPort.Controls.Add(this.cboParity);
            this.groupPort.Controls.Add(this.label5);
            this.groupPort.Controls.Add(this.cboDataBits);
            this.groupPort.Controls.Add(this.label4);
            this.groupPort.Controls.Add(this.cboBaud);
            this.groupPort.Controls.Add(this.label3);
            this.groupPort.Controls.Add(this.cboPort);
            this.groupPort.Controls.Add(this.label2);
            this.groupPort.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPort.Location = new System.Drawing.Point(3, 363);
            this.groupPort.Name = "groupPort";
            this.groupPort.Size = new System.Drawing.Size(406, 260);
            this.groupPort.TabIndex = 0;
            this.groupPort.TabStop = false;
            this.groupPort.Text = "Port Configuration";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(275, 214);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(110, 30);
            this.btnDisconnect.TabIndex = 14;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(144, 214);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(110, 30);
            this.btnConnect.TabIndex = 13;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnFindPorts
            // 
            this.btnFindPorts.Location = new System.Drawing.Point(16, 214);
            this.btnFindPorts.Name = "btnFindPorts";
            this.btnFindPorts.Size = new System.Drawing.Size(110, 30);
            this.btnFindPorts.TabIndex = 12;
            this.btnFindPorts.Text = "Find Ports";
            this.btnFindPorts.UseVisualStyleBackColor = true;
            this.btnFindPorts.Click += new System.EventHandler(this.btnFindPorts_Click);
            // 
            // cboFlow
            // 
            this.cboFlow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFlow.FormattingEnabled = true;
            this.cboFlow.Items.AddRange(new object[] {
            "None",
            "RTS/CTS",
            "XON/XOFF"});
            this.cboFlow.Location = new System.Drawing.Point(275, 168);
            this.cboFlow.Name = "cboFlow";
            this.cboFlow.Size = new System.Drawing.Size(110, 24);
            this.cboFlow.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(220, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "Flow";
            // 
            // cboStopBits
            // 
            this.cboStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStopBits.FormattingEnabled = true;
            this.cboStopBits.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.cboStopBits.Location = new System.Drawing.Point(93, 168);
            this.cboStopBits.Name = "cboStopBits";
            this.cboStopBits.Size = new System.Drawing.Size(110, 24);
            this.cboStopBits.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "StopBits";
            // 
            // cboParity
            // 
            this.cboParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboParity.FormattingEnabled = true;
            this.cboParity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
            this.cboParity.Location = new System.Drawing.Point(275, 126);
            this.cboParity.Name = "cboParity";
            this.cboParity.Size = new System.Drawing.Size(110, 24);
            this.cboParity.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(220, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Parity";
            // 
            // cboDataBits
            // 
            this.cboDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDataBits.FormattingEnabled = true;
            this.cboDataBits.Items.AddRange(new object[] {
            "7",
            "8"});
            this.cboDataBits.Location = new System.Drawing.Point(93, 126);
            this.cboDataBits.Name = "cboDataBits";
            this.cboDataBits.Size = new System.Drawing.Size(110, 24);
            this.cboDataBits.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "DataBits";
            // 
            // cboBaud
            // 
            this.cboBaud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBaud.FormattingEnabled = true;
            this.cboBaud.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200",
            "230400",
            "460800",
            "921600"});
            this.cboBaud.Location = new System.Drawing.Point(275, 82);
            this.cboBaud.Name = "cboBaud";
            this.cboBaud.Size = new System.Drawing.Size(110, 24);
            this.cboBaud.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(220, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Baud";
            // 
            // cboPort
            // 
            this.cboPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPort.FormattingEnabled = true;
            this.cboPort.Location = new System.Drawing.Point(93, 82);
            this.cboPort.Name = "cboPort";
            this.cboPort.Size = new System.Drawing.Size(110, 24);
            this.cboPort.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Port";
            // 
            // groupDiagnostics
            // 
            this.groupDiagnostics.Controls.Add(this.btnDiagRun);
            this.groupDiagnostics.Controls.Add(this.txtDiagOutput);
            this.groupDiagnostics.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupDiagnostics.Location = new System.Drawing.Point(3, 3);
            this.groupDiagnostics.Name = "groupDiagnostics";
            this.groupDiagnostics.Size = new System.Drawing.Size(406, 360);
            this.groupDiagnostics.TabIndex = 1;
            this.groupDiagnostics.TabStop = false;
            this.groupDiagnostics.Text = "Diagnostics";
            // 
            // btnDiagRun
            // 
            this.btnDiagRun.Location = new System.Drawing.Point(16, 22);
            this.btnDiagRun.Name = "btnDiagRun";
            this.btnDiagRun.Size = new System.Drawing.Size(150, 30);
            this.btnDiagRun.TabIndex = 0;
            this.btnDiagRun.Text = "Run Basic";
            this.btnDiagRun.UseVisualStyleBackColor = true;
            this.btnDiagRun.Click += new System.EventHandler(this.btnDiagRun_Click);
            // 
            // txtDiagOutput
            // 
            this.txtDiagOutput.Location = new System.Drawing.Point(16, 62);
            this.txtDiagOutput.Multiline = true;
            this.txtDiagOutput.Name = "txtDiagOutput";
            this.txtDiagOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDiagOutput.Size = new System.Drawing.Size(369, 280);
            this.txtDiagOutput.TabIndex = 1;
            // 
            // tabSIM
            // 
            this.tabSIM.Controls.Add(this.groupSIM);
            this.tabSIM.Location = new System.Drawing.Point(4, 25);
            this.tabSIM.Name = "tabSIM";
            this.tabSIM.Padding = new System.Windows.Forms.Padding(3);
            this.tabSIM.Size = new System.Drawing.Size(412, 643);
            this.tabSIM.TabIndex = 1;
            this.tabSIM.Text = "SIM";
            this.tabSIM.UseVisualStyleBackColor = true;
            // 
            // groupSIM
            // 
            this.groupSIM.Controls.Add(this.btnSimCpin);
            this.groupSIM.Controls.Add(this.txtPin);
            this.groupSIM.Controls.Add(this.btnSimEnterPin);
            this.groupSIM.Controls.Add(this.btnSimReadIds);
            this.groupSIM.Controls.Add(this.txtSimOutput);
            this.groupSIM.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupSIM.Location = new System.Drawing.Point(3, 3);
            this.groupSIM.Name = "groupSIM";
            this.groupSIM.Size = new System.Drawing.Size(406, 360);
            this.groupSIM.TabIndex = 0;
            this.groupSIM.TabStop = false;
            this.groupSIM.Text = "SIM";
            // 
            // btnSimCpin
            // 
            this.btnSimCpin.Location = new System.Drawing.Point(16, 22);
            this.btnSimCpin.Name = "btnSimCpin";
            this.btnSimCpin.Size = new System.Drawing.Size(120, 30);
            this.btnSimCpin.TabIndex = 0;
            this.btnSimCpin.Text = "CPIN?";
            this.btnSimCpin.UseVisualStyleBackColor = true;
            this.btnSimCpin.Click += new System.EventHandler(this.btnSimCpin_Click);
            // 
            // txtPin
            // 
            this.txtPin.Location = new System.Drawing.Point(150, 26);
            this.txtPin.MaxLength = 8;
            this.txtPin.Name = "txtPin";
            this.txtPin.PasswordChar = '*';
            this.txtPin.Size = new System.Drawing.Size(120, 22);
            this.txtPin.TabIndex = 1;
            // 
            // btnSimEnterPin
            // 
            this.btnSimEnterPin.Location = new System.Drawing.Point(280, 22);
            this.btnSimEnterPin.Name = "btnSimEnterPin";
            this.btnSimEnterPin.Size = new System.Drawing.Size(105, 30);
            this.btnSimEnterPin.TabIndex = 2;
            this.btnSimEnterPin.Text = "Enter PIN";
            this.btnSimEnterPin.UseVisualStyleBackColor = true;
            this.btnSimEnterPin.Click += new System.EventHandler(this.btnSimEnterPin_Click);
            // 
            // btnSimReadIds
            // 
            this.btnSimReadIds.Location = new System.Drawing.Point(16, 64);
            this.btnSimReadIds.Name = "btnSimReadIds";
            this.btnSimReadIds.Size = new System.Drawing.Size(150, 30);
            this.btnSimReadIds.TabIndex = 3;
            this.btnSimReadIds.Text = "Read ICCID/IMSI/OP";
            this.btnSimReadIds.UseVisualStyleBackColor = true;
            this.btnSimReadIds.Click += new System.EventHandler(this.btnSimReadIds_Click);
            // 
            // txtSimOutput
            // 
            this.txtSimOutput.Location = new System.Drawing.Point(16, 104);
            this.txtSimOutput.Multiline = true;
            this.txtSimOutput.Name = "txtSimOutput";
            this.txtSimOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSimOutput.Size = new System.Drawing.Size(369, 238);
            this.txtSimOutput.TabIndex = 4;
            // 
            // tabSMS
            // 
            this.tabSMS.Controls.Add(this.groupSMS);
            this.tabSMS.Location = new System.Drawing.Point(4, 25);
            this.tabSMS.Name = "tabSMS";
            this.tabSMS.Size = new System.Drawing.Size(412, 643);
            this.tabSMS.TabIndex = 2;
            this.tabSMS.Text = "SMS";
            this.tabSMS.UseVisualStyleBackColor = true;
            // 
            // groupSMS
            // 
            this.groupSMS.Controls.Add(this.lblSmsPhone);
            this.groupSMS.Controls.Add(this.txtSmsPhone);
            this.groupSMS.Controls.Add(this.btnSmsSend);
            this.groupSMS.Controls.Add(this.lblSmsMsg);
            this.groupSMS.Controls.Add(this.txtSmsMsg);
            this.groupSMS.Controls.Add(this.txtSmsOut);
            this.groupSMS.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupSMS.Location = new System.Drawing.Point(0, 0);
            this.groupSMS.Name = "groupSMS";
            this.groupSMS.Size = new System.Drawing.Size(412, 360);
            this.groupSMS.TabIndex = 0;
            this.groupSMS.TabStop = false;
            this.groupSMS.Text = "SMS (Text Mode)";
            // 
            // lblSmsPhone
            // 
            this.lblSmsPhone.Location = new System.Drawing.Point(16, 28);
            this.lblSmsPhone.Name = "lblSmsPhone";
            this.lblSmsPhone.Size = new System.Drawing.Size(70, 17);
            this.lblSmsPhone.TabIndex = 0;
            this.lblSmsPhone.Text = "Phone";
            // 
            // txtSmsPhone
            // 
            this.txtSmsPhone.Location = new System.Drawing.Point(92, 25);
            this.txtSmsPhone.Name = "txtSmsPhone";
            this.txtSmsPhone.Size = new System.Drawing.Size(210, 22);
            this.txtSmsPhone.TabIndex = 1;
            // 
            // btnSmsSend
            // 
            this.btnSmsSend.Location = new System.Drawing.Point(310, 23);
            this.btnSmsSend.Name = "btnSmsSend";
            this.btnSmsSend.Size = new System.Drawing.Size(75, 26);
            this.btnSmsSend.TabIndex = 2;
            this.btnSmsSend.Text = "Send";
            this.btnSmsSend.Click += new System.EventHandler(this.btnSmsSend_Click);
            // 
            // lblSmsMsg
            // 
            this.lblSmsMsg.Location = new System.Drawing.Point(16, 64);
            this.lblSmsMsg.Name = "lblSmsMsg";
            this.lblSmsMsg.Size = new System.Drawing.Size(70, 17);
            this.lblSmsMsg.TabIndex = 3;
            this.lblSmsMsg.Text = "Message";
            // 
            // txtSmsMsg
            // 
            this.txtSmsMsg.Location = new System.Drawing.Point(19, 84);
            this.txtSmsMsg.Multiline = true;
            this.txtSmsMsg.Name = "txtSmsMsg";
            this.txtSmsMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSmsMsg.Size = new System.Drawing.Size(366, 200);
            this.txtSmsMsg.TabIndex = 4;
            // 
            // txtSmsOut
            // 
            this.txtSmsOut.Location = new System.Drawing.Point(19, 292);
            this.txtSmsOut.Name = "txtSmsOut";
            this.txtSmsOut.ReadOnly = true;
            this.txtSmsOut.Size = new System.Drawing.Size(366, 22);
            this.txtSmsOut.TabIndex = 5;
            // 
            // tabUSSD
            // 
            this.tabUSSD.Controls.Add(this.groupUSSD);
            this.tabUSSD.Location = new System.Drawing.Point(4, 25);
            this.tabUSSD.Name = "tabUSSD";
            this.tabUSSD.Size = new System.Drawing.Size(412, 643);
            this.tabUSSD.TabIndex = 3;
            this.tabUSSD.Text = "USSD";
            this.tabUSSD.UseVisualStyleBackColor = true;
            // 
            // groupUSSD
            // 
            this.groupUSSD.Controls.Add(this.lblUssd);
            this.groupUSSD.Controls.Add(this.txtUssd);
            this.groupUSSD.Controls.Add(this.btnUssdSend);
            this.groupUSSD.Controls.Add(this.txtUssdOut);
            this.groupUSSD.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupUSSD.Location = new System.Drawing.Point(0, 0);
            this.groupUSSD.Name = "groupUSSD";
            this.groupUSSD.Size = new System.Drawing.Size(412, 200);
            this.groupUSSD.TabIndex = 0;
            this.groupUSSD.TabStop = false;
            this.groupUSSD.Text = "USSD";
            // 
            // lblUssd
            // 
            this.lblUssd.Location = new System.Drawing.Point(16, 30);
            this.lblUssd.Name = "lblUssd";
            this.lblUssd.Size = new System.Drawing.Size(70, 17);
            this.lblUssd.TabIndex = 0;
            this.lblUssd.Text = "Code";
            // 
            // txtUssd
            // 
            this.txtUssd.Location = new System.Drawing.Point(92, 27);
            this.txtUssd.Name = "txtUssd";
            this.txtUssd.Size = new System.Drawing.Size(210, 22);
            this.txtUssd.TabIndex = 1;
            // 
            // btnUssdSend
            // 
            this.btnUssdSend.Location = new System.Drawing.Point(310, 25);
            this.btnUssdSend.Name = "btnUssdSend";
            this.btnUssdSend.Size = new System.Drawing.Size(75, 26);
            this.btnUssdSend.TabIndex = 2;
            this.btnUssdSend.Text = "Send";
            this.btnUssdSend.Click += new System.EventHandler(this.btnUssdSend_Click);
            // 
            // txtUssdOut
            // 
            this.txtUssdOut.Location = new System.Drawing.Point(19, 70);
            this.txtUssdOut.Multiline = true;
            this.txtUssdOut.Name = "txtUssdOut";
            this.txtUssdOut.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtUssdOut.Size = new System.Drawing.Size(366, 110);
            this.txtUssdOut.TabIndex = 3;
            // 
            // tabNetwork
            // 
            this.tabNetwork.Location = new System.Drawing.Point(4, 25);
            this.tabNetwork.Name = "tabNetwork";
            this.tabNetwork.Size = new System.Drawing.Size(412, 643);
            this.tabNetwork.TabIndex = 4;
            this.tabNetwork.Text = "Network Selection";
            this.tabNetwork.UseVisualStyleBackColor = true;
            // 
            // tabGPS
            // 
            this.tabGPS.Location = new System.Drawing.Point(4, 25);
            this.tabGPS.Name = "tabGPS";
            this.tabGPS.Size = new System.Drawing.Size(412, 643);
            this.tabGPS.TabIndex = 5;
            this.tabGPS.Text = "GPS/NMEA";
            this.tabGPS.UseVisualStyleBackColor = true;
            // 
            // tabSignal
            // 
            this.tabSignal.Location = new System.Drawing.Point(4, 25);
            this.tabSignal.Name = "tabSignal";
            this.tabSignal.Size = new System.Drawing.Size(412, 643);
            this.tabSignal.TabIndex = 6;
            this.tabSignal.Text = "Signal Check";
            this.tabSignal.UseVisualStyleBackColor = true;
            // 
            // tabCmdMode
            // 
            this.tabCmdMode.Controls.Add(this.groupCmdMode);
            this.tabCmdMode.Location = new System.Drawing.Point(4, 25);
            this.tabCmdMode.Name = "tabCmdMode";
            this.tabCmdMode.Size = new System.Drawing.Size(412, 643);
            this.tabCmdMode.TabIndex = 7;
            this.tabCmdMode.Text = "Command Mode";
            this.tabCmdMode.UseVisualStyleBackColor = true;
            // 
            // groupCmdMode
            // 
            this.groupCmdMode.Controls.Add(this.txtCmdModeInput);
            this.groupCmdMode.Controls.Add(this.btnCmdModeSend);
            this.groupCmdMode.Controls.Add(this.chkCmdModeCrLf);
            this.groupCmdMode.Controls.Add(this.cboCmdSnippets);
            this.groupCmdMode.Controls.Add(this.lstCmdHistory);
            this.groupCmdMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupCmdMode.Location = new System.Drawing.Point(0, 0);
            this.groupCmdMode.Name = "groupCmdMode";
            this.groupCmdMode.Size = new System.Drawing.Size(412, 643);
            this.groupCmdMode.TabIndex = 0;
            this.groupCmdMode.TabStop = false;
            this.groupCmdMode.Text = "Command Mode";
            // 
            // txtCmdModeInput
            // 
            this.txtCmdModeInput.Location = new System.Drawing.Point(16, 28);
            this.txtCmdModeInput.Name = "txtCmdModeInput";
            this.txtCmdModeInput.Size = new System.Drawing.Size(292, 22);
            this.txtCmdModeInput.TabIndex = 0;
            this.txtCmdModeInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCmdModeInput_KeyDown);
            // 
            // btnCmdModeSend
            // 
            this.btnCmdModeSend.Location = new System.Drawing.Point(316, 26);
            this.btnCmdModeSend.Name = "btnCmdModeSend";
            this.btnCmdModeSend.Size = new System.Drawing.Size(69, 26);
            this.btnCmdModeSend.TabIndex = 1;
            this.btnCmdModeSend.Text = "Send";
            this.btnCmdModeSend.Click += new System.EventHandler(this.btnCmdModeSend_Click);
            // 
            // chkCmdModeCrLf
            // 
            this.chkCmdModeCrLf.Location = new System.Drawing.Point(16, 58);
            this.chkCmdModeCrLf.Name = "chkCmdModeCrLf";
            this.chkCmdModeCrLf.Size = new System.Drawing.Size(120, 20);
            this.chkCmdModeCrLf.TabIndex = 2;
            this.chkCmdModeCrLf.Text = "Append CR/LF";
            // 
            // cboCmdSnippets
            // 
            this.cboCmdSnippets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCmdSnippets.Location = new System.Drawing.Point(146, 56);
            this.cboCmdSnippets.Name = "cboCmdSnippets";
            this.cboCmdSnippets.Size = new System.Drawing.Size(239, 24);
            this.cboCmdSnippets.TabIndex = 3;
            this.cboCmdSnippets.SelectedIndexChanged += new System.EventHandler(this.cboCmdSnippets_SelectedIndexChanged);
            // 
            // lstCmdHistory
            // 
            this.lstCmdHistory.ItemHeight = 16;
            this.lstCmdHistory.Location = new System.Drawing.Point(16, 90);
            this.lstCmdHistory.Name = "lstCmdHistory";
            this.lstCmdHistory.Size = new System.Drawing.Size(369, 196);
            this.lstCmdHistory.TabIndex = 4;
            this.lstCmdHistory.DoubleClick += new System.EventHandler(this.lstCmdHistory_DoubleClick);
            // 
            // tabScript
            // 
            this.tabScript.Controls.Add(this.groupScript);
            this.tabScript.Location = new System.Drawing.Point(4, 25);
            this.tabScript.Name = "tabScript";
            this.tabScript.Size = new System.Drawing.Size(412, 643);
            this.tabScript.TabIndex = 8;
            this.tabScript.Text = "Script Mode";
            this.tabScript.UseVisualStyleBackColor = true;
            // 
            // groupScript
            // 
            this.groupScript.Controls.Add(this.btnScriptOpen);
            this.groupScript.Controls.Add(this.btnScriptSave);
            this.groupScript.Controls.Add(this.btnScriptRun);
            this.groupScript.Controls.Add(this.btnScriptStop);
            this.groupScript.Controls.Add(this.btnScriptExport);
            this.groupScript.Controls.Add(this.txtScriptEditor);
            this.groupScript.Controls.Add(this.gridScriptResults);
            this.groupScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupScript.Location = new System.Drawing.Point(0, 0);
            this.groupScript.Name = "groupScript";
            this.groupScript.Size = new System.Drawing.Size(412, 643);
            this.groupScript.TabIndex = 0;
            this.groupScript.TabStop = false;
            this.groupScript.Text = "Script";
            // 
            // btnScriptOpen
            // 
            this.btnScriptOpen.Location = new System.Drawing.Point(16, 24);
            this.btnScriptOpen.Name = "btnScriptOpen";
            this.btnScriptOpen.Size = new System.Drawing.Size(60, 26);
            this.btnScriptOpen.TabIndex = 0;
            this.btnScriptOpen.Text = "Open";
            this.btnScriptOpen.Click += new System.EventHandler(this.btnScriptOpen_Click);
            // 
            // btnScriptSave
            // 
            this.btnScriptSave.Location = new System.Drawing.Point(82, 24);
            this.btnScriptSave.Name = "btnScriptSave";
            this.btnScriptSave.Size = new System.Drawing.Size(60, 26);
            this.btnScriptSave.TabIndex = 1;
            this.btnScriptSave.Text = "Save";
            this.btnScriptSave.Click += new System.EventHandler(this.btnScriptSave_Click);
            // 
            // btnScriptRun
            // 
            this.btnScriptRun.Location = new System.Drawing.Point(148, 24);
            this.btnScriptRun.Name = "btnScriptRun";
            this.btnScriptRun.Size = new System.Drawing.Size(60, 26);
            this.btnScriptRun.TabIndex = 2;
            this.btnScriptRun.Text = "Run";
            this.btnScriptRun.Click += new System.EventHandler(this.btnScriptRun_Click);
            // 
            // btnScriptStop
            // 
            this.btnScriptStop.Location = new System.Drawing.Point(214, 24);
            this.btnScriptStop.Name = "btnScriptStop";
            this.btnScriptStop.Size = new System.Drawing.Size(60, 26);
            this.btnScriptStop.TabIndex = 3;
            this.btnScriptStop.Text = "Stop";
            this.btnScriptStop.Click += new System.EventHandler(this.btnScriptStop_Click);
            // 
            // btnScriptExport
            // 
            this.btnScriptExport.Location = new System.Drawing.Point(280, 24);
            this.btnScriptExport.Name = "btnScriptExport";
            this.btnScriptExport.Size = new System.Drawing.Size(60, 26);
            this.btnScriptExport.TabIndex = 4;
            this.btnScriptExport.Text = "Export";
            this.btnScriptExport.Click += new System.EventHandler(this.btnScriptExport_Click);
            // 
            // txtScriptEditor
            // 
            this.txtScriptEditor.Location = new System.Drawing.Point(16, 56);
            this.txtScriptEditor.Multiline = true;
            this.txtScriptEditor.Name = "txtScriptEditor";
            this.txtScriptEditor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtScriptEditor.Size = new System.Drawing.Size(369, 240);
            this.txtScriptEditor.TabIndex = 5;
            // 
            // gridScriptResults
            // 
            this.gridScriptResults.AllowUserToAddRows = false;
            this.gridScriptResults.AllowUserToDeleteRows = false;
            this.gridScriptResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridScriptResults.ColumnHeadersHeight = 29;
            this.gridScriptResults.Location = new System.Drawing.Point(16, 304);
            this.gridScriptResults.Name = "gridScriptResults";
            this.gridScriptResults.ReadOnly = true;
            this.gridScriptResults.RowHeadersWidth = 51;
            this.gridScriptResults.Size = new System.Drawing.Size(369, 300);
            this.gridScriptResults.TabIndex = 6;
            // 
            // tabSnapshot
            // 
            this.tabSnapshot.Location = new System.Drawing.Point(4, 25);
            this.tabSnapshot.Name = "tabSnapshot";
            this.tabSnapshot.Size = new System.Drawing.Size(412, 643);
            this.tabSnapshot.TabIndex = 9;
            this.tabSnapshot.Text = "Snapshot";
            this.tabSnapshot.UseVisualStyleBackColor = true;
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.rtbLog);
            this.panelRight.Controls.Add(this.groupLogFilters);
            this.panelRight.Controls.Add(this.panelCmd);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(0, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(776, 672);
            this.panelRight.TabIndex = 0;
            // 
            // rtbLog
            // 
            this.rtbLog.DetectUrls = false;
            this.rtbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLog.Location = new System.Drawing.Point(0, 60);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.Size = new System.Drawing.Size(776, 582);
            this.rtbLog.TabIndex = 1;
            this.rtbLog.Text = "";
            this.rtbLog.TextChanged += new System.EventHandler(this.rtbLog_TextChanged);
            // 
            // groupLogFilters
            // 
            this.groupLogFilters.Controls.Add(this.chkShowTX);
            this.groupLogFilters.Controls.Add(this.chkShowRX);
            this.groupLogFilters.Controls.Add(this.txtSearch);
            this.groupLogFilters.Controls.Add(this.label1);
            this.groupLogFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupLogFilters.Location = new System.Drawing.Point(0, 0);
            this.groupLogFilters.Name = "groupLogFilters";
            this.groupLogFilters.Size = new System.Drawing.Size(776, 60);
            this.groupLogFilters.TabIndex = 0;
            this.groupLogFilters.TabStop = false;
            this.groupLogFilters.Text = "Log Filters";
            // 
            // chkShowTX
            // 
            this.chkShowTX.AutoSize = true;
            this.chkShowTX.Checked = true;
            this.chkShowTX.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowTX.Location = new System.Drawing.Point(364, 25);
            this.chkShowTX.Name = "chkShowTX";
            this.chkShowTX.Size = new System.Drawing.Size(86, 21);
            this.chkShowTX.TabIndex = 3;
            this.chkShowTX.Text = "Show TX";
            this.chkShowTX.UseVisualStyleBackColor = true;
            this.chkShowTX.CheckedChanged += new System.EventHandler(this.FilterChanged);
            // 
            // chkShowRX
            // 
            this.chkShowRX.AutoSize = true;
            this.chkShowRX.Checked = true;
            this.chkShowRX.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowRX.Location = new System.Drawing.Point(270, 25);
            this.chkShowRX.Name = "chkShowRX";
            this.chkShowRX.Size = new System.Drawing.Size(87, 21);
            this.chkShowRX.TabIndex = 2;
            this.chkShowRX.Text = "Show RX";
            this.chkShowRX.UseVisualStyleBackColor = true;
            this.chkShowRX.CheckedChanged += new System.EventHandler(this.FilterChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(63, 23);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(190, 22);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.FilterChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search";
            // 
            // panelCmd
            // 
            this.panelCmd.Controls.Add(this.chkCRLF);
            this.panelCmd.Controls.Add(this.txtCmd);
            this.panelCmd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCmd.Location = new System.Drawing.Point(0, 642);
            this.panelCmd.Name = "panelCmd";
            this.panelCmd.Size = new System.Drawing.Size(776, 30);
            this.panelCmd.TabIndex = 2;
            // 
            // chkCRLF
            // 
            this.chkCRLF.AutoSize = true;
            this.chkCRLF.Location = new System.Drawing.Point(676, 6);
            this.chkCRLF.Name = "chkCRLF";
            this.chkCRLF.Size = new System.Drawing.Size(122, 21);
            this.chkCRLF.TabIndex = 1;
            this.chkCRLF.Text = "Append CR/LF";
            this.chkCRLF.UseVisualStyleBackColor = true;
            // 
            // txtCmd
            // 
            this.txtCmd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCmd.Location = new System.Drawing.Point(0, 0);
            this.txtCmd.Name = "txtCmd";
            this.txtCmd.Size = new System.Drawing.Size(776, 22);
            this.txtCmd.TabIndex = 0;
            this.txtCmd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCmd_KeyDown);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusPort,
            this.lblStatusBaud,
            this.lblCtsRts,
            this.lblLineCount});
            this.statusStrip.Location = new System.Drawing.Point(0, 699);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1200, 26);
            this.statusStrip.TabIndex = 2;
            // 
            // lblStatusPort
            // 
            this.lblStatusPort.Name = "lblStatusPort";
            this.lblStatusPort.Size = new System.Drawing.Size(69, 20);
            this.lblStatusPort.Text = "Port: N/A";
            // 
            // lblStatusBaud
            // 
            this.lblStatusBaud.Name = "lblStatusBaud";
            this.lblStatusBaud.Size = new System.Drawing.Size(77, 20);
            this.lblStatusBaud.Text = "Baud: N/A";
            // 
            // lblCtsRts
            // 
            this.lblCtsRts.Name = "lblCtsRts";
            this.lblCtsRts.Size = new System.Drawing.Size(98, 20);
            this.lblCtsRts.Text = "CTS/RTS: N/A";
            // 
            // lblLineCount
            // 
            this.lblLineCount.Name = "lblLineCount";
            this.lblLineCount.Size = new System.Drawing.Size(941, 20);
            this.lblLineCount.Spring = true;
            this.lblLineCount.Text = "Lines: 0";
            this.lblLineCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // serialPort
            // 
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // Main_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 725);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStripMain);
            this.Name = "Main_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AT Command Tester";
            this.Load += new System.EventHandler(this.Main_form_Load);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.tabLeft.ResumeLayout(false);
            this.tabConnection.ResumeLayout(false);
            this.groupPort.ResumeLayout(false);
            this.groupPort.PerformLayout();
            this.groupDiagnostics.ResumeLayout(false);
            this.groupDiagnostics.PerformLayout();
            this.tabSIM.ResumeLayout(false);
            this.groupSIM.ResumeLayout(false);
            this.groupSIM.PerformLayout();
            this.tabSMS.ResumeLayout(false);
            this.groupSMS.ResumeLayout(false);
            this.groupSMS.PerformLayout();
            this.tabUSSD.ResumeLayout(false);
            this.groupUSSD.ResumeLayout(false);
            this.groupUSSD.PerformLayout();
            this.tabCmdMode.ResumeLayout(false);
            this.groupCmdMode.ResumeLayout(false);
            this.groupCmdMode.PerformLayout();
            this.tabScript.ResumeLayout(false);
            this.groupScript.ResumeLayout(false);
            this.groupScript.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridScriptResults)).EndInit();
            this.panelRight.ResumeLayout(false);
            this.groupLogFilters.ResumeLayout(false);
            this.groupLogFilters.PerformLayout();
            this.panelCmd.ResumeLayout(false);
            this.panelCmd.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripButton btnSupport;
        private System.Windows.Forms.ToolStripButton btnSysInfo;
        private System.Windows.Forms.ToolStripButton btnClearLog;
        private System.Windows.Forms.ToolStripButton btnSaveLog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel lblLicense;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.TabControl tabLeft;
        private System.Windows.Forms.TabPage tabConnection;
        private System.Windows.Forms.TabPage tabSIM;
        private System.Windows.Forms.TabPage tabSMS;
        private System.Windows.Forms.TabPage tabUSSD;
        private System.Windows.Forms.TabPage tabNetwork;
        private System.Windows.Forms.TabPage tabGPS;
        private System.Windows.Forms.TabPage tabSignal;
        private System.Windows.Forms.TabPage tabCmdMode;
        private System.Windows.Forms.TabPage tabScript;
        private System.Windows.Forms.TabPage tabSnapshot;
        private System.Windows.Forms.GroupBox groupPort;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnFindPorts;
        private System.Windows.Forms.ComboBox cboFlow;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboStopBits;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboParity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboDataBits;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboBaud;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.GroupBox groupLogFilters;
        private System.Windows.Forms.CheckBox chkShowTX;
        private System.Windows.Forms.CheckBox chkShowRX;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusPort;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusBaud;
        private System.Windows.Forms.ToolStripStatusLabel lblLineCount;
        private System.Windows.Forms.ToolStripStatusLabel lblCtsRts;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Panel panelCmd;
        private System.Windows.Forms.CheckBox chkCRLF;
        private System.Windows.Forms.TextBox txtCmd;
        private System.Windows.Forms.GroupBox groupDiagnostics;
        private System.Windows.Forms.Button btnDiagRun;
        private System.Windows.Forms.TextBox txtDiagOutput;
        private System.Windows.Forms.GroupBox groupSIM;
        private System.Windows.Forms.Button btnSimCpin;
        private System.Windows.Forms.TextBox txtPin;
        private System.Windows.Forms.Button btnSimEnterPin;
        private System.Windows.Forms.Button btnSimReadIds;
        private System.Windows.Forms.TextBox txtSimOutput;
        private System.Windows.Forms.GroupBox groupSMS;
        private System.Windows.Forms.Label lblSmsPhone;
        private System.Windows.Forms.TextBox txtSmsPhone;
        private System.Windows.Forms.Button btnSmsSend;
        private System.Windows.Forms.Label lblSmsMsg;
        private System.Windows.Forms.TextBox txtSmsMsg;
        private System.Windows.Forms.TextBox txtSmsOut;
        private System.Windows.Forms.GroupBox groupUSSD;
        private System.Windows.Forms.Label lblUssd;
        private System.Windows.Forms.TextBox txtUssd;
        private System.Windows.Forms.Button btnUssdSend;
        private System.Windows.Forms.TextBox txtUssdOut;
        private System.Windows.Forms.GroupBox groupCmdMode;
        private System.Windows.Forms.TextBox txtCmdModeInput;
        private System.Windows.Forms.Button btnCmdModeSend;
        private System.Windows.Forms.CheckBox chkCmdModeCrLf;
        private System.Windows.Forms.ComboBox cboCmdSnippets;
        private System.Windows.Forms.ListBox lstCmdHistory;
        private System.Windows.Forms.GroupBox groupScript;
        private System.Windows.Forms.Button btnScriptOpen;
        private System.Windows.Forms.Button btnScriptSave;
        private System.Windows.Forms.Button btnScriptRun;
        private System.Windows.Forms.Button btnScriptStop;
        private System.Windows.Forms.Button btnScriptExport;
        private System.Windows.Forms.TextBox txtScriptEditor;
        private System.Windows.Forms.DataGridView gridScriptResults;
    }
}

