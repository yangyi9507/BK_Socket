
namespace BK_Tool
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.labPort = new System.Windows.Forms.Label();
            this.txtIPString = new System.Windows.Forms.TextBox();
            this.labIPString = new System.Windows.Forms.Label();
            this.cbxProtocolType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gbxResult = new System.Windows.Forms.GroupBox();
            this.txtResult = new System.Windows.Forms.RichTextBox();
            this.panelTcpClient = new System.Windows.Forms.Panel();
            this.txtLocalIpString = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panelUDPSocket = new System.Windows.Forms.Panel();
            this.txtRemotePort = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRemoteIPString = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelTcpServer = new System.Windows.Forms.Panel();
            this.cbxConntects = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtSendContent = new System.Windows.Forms.RichTextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.sysNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.sysContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuShow = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.sysToolBar = new System.Windows.Forms.ToolStrip();
            this.tbbHelper = new System.Windows.Forms.ToolStripDropDownButton();
            this.mnuCheckUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tbbSave = new System.Windows.Forms.ToolStripButton();
            this.tbbClear = new System.Windows.Forms.ToolStripButton();
            this.sysStatusBar = new System.Windows.Forms.StatusStrip();
            this.sysStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ckbAppendAddress = new System.Windows.Forms.CheckBox();
            this.ckbAppendN = new System.Windows.Forms.CheckBox();
            this.cbxReceiveEncoding = new System.Windows.Forms.ComboBox();
            this.ckbAppendTime = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbxSendEncoding = new System.Windows.Forms.ComboBox();
            this.cbxLoopSend = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtLoopInterval = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.LinkLabel();
            this.btnSelect = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gbxResult.SuspendLayout();
            this.panelTcpClient.SuspendLayout();
            this.panelUDPSocket.SuspendLayout();
            this.panelTcpServer.SuspendLayout();
            this.panel3.SuspendLayout();
            this.sysContextMenu.SuspendLayout();
            this.sysToolBar.SuspendLayout();
            this.sysStatusBar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.labPort);
            this.groupBox1.Controls.Add(this.txtIPString);
            this.groupBox1.Controls.Add(this.labIPString);
            this.groupBox1.Controls.Add(this.cbxProtocolType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(8, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(284, 290);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "网络设置";
            // 
            // txtPort
            // 
            this.txtPort.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtPort.Location = new System.Drawing.Point(4, 181);
            this.txtPort.Margin = new System.Windows.Forms.Padding(4);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(276, 28);
            this.txtPort.TabIndex = 8;
            this.txtPort.Text = "18099";
            // 
            // labPort
            // 
            this.labPort.Dock = System.Windows.Forms.DockStyle.Top;
            this.labPort.Location = new System.Drawing.Point(4, 147);
            this.labPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labPort.Name = "labPort";
            this.labPort.Size = new System.Drawing.Size(276, 34);
            this.labPort.TabIndex = 7;
            this.labPort.Text = "（2）服务器商端口(Port)";
            this.labPort.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtIPString
            // 
            this.txtIPString.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtIPString.Location = new System.Drawing.Point(4, 119);
            this.txtIPString.Margin = new System.Windows.Forms.Padding(4);
            this.txtIPString.Name = "txtIPString";
            this.txtIPString.Size = new System.Drawing.Size(276, 28);
            this.txtIPString.TabIndex = 6;
            this.txtIPString.Text = "127.0.0.1";
            // 
            // labIPString
            // 
            this.labIPString.Dock = System.Windows.Forms.DockStyle.Top;
            this.labIPString.Location = new System.Drawing.Point(4, 85);
            this.labIPString.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labIPString.Name = "labIPString";
            this.labIPString.Size = new System.Drawing.Size(276, 34);
            this.labIPString.TabIndex = 5;
            this.labIPString.Text = "（2）服务器IP地址(IP)";
            this.labIPString.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxProtocolType
            // 
            this.cbxProtocolType.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxProtocolType.FormattingEnabled = true;
            this.cbxProtocolType.Location = new System.Drawing.Point(4, 59);
            this.cbxProtocolType.Margin = new System.Windows.Forms.Padding(4);
            this.cbxProtocolType.Name = "cbxProtocolType";
            this.cbxProtocolType.Size = new System.Drawing.Size(276, 26);
            this.cbxProtocolType.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(4, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 34);
            this.label1.TabIndex = 3;
            this.label1.Text = "（1）协议类型";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(45, 231);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(180, 48);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "连接";
            this.btnConnect.UseVisualStyleBackColor = true;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(113, 6);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gbxResult);
            this.panel2.Controls.Add(this.splitter1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(300, 33);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(8, 3, 8, 0);
            this.panel2.Size = new System.Drawing.Size(981, 725);
            this.panel2.TabIndex = 11;
            // 
            // gbxResult
            // 
            this.gbxResult.Controls.Add(this.txtResult);
            this.gbxResult.Controls.Add(this.panelTcpClient);
            this.gbxResult.Controls.Add(this.panelUDPSocket);
            this.gbxResult.Controls.Add(this.panelTcpServer);
            this.gbxResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxResult.Location = new System.Drawing.Point(8, 3);
            this.gbxResult.Margin = new System.Windows.Forms.Padding(4);
            this.gbxResult.Name = "gbxResult";
            this.gbxResult.Padding = new System.Windows.Forms.Padding(4);
            this.gbxResult.Size = new System.Drawing.Size(965, 620);
            this.gbxResult.TabIndex = 11;
            this.gbxResult.TabStop = false;
            this.gbxResult.Text = "网络数据接收(Recieve Data)";
            // 
            // txtResult
            // 
            this.txtResult.BackColor = System.Drawing.SystemColors.Info;
            this.txtResult.Location = new System.Drawing.Point(4, 26);
            this.txtResult.Margin = new System.Windows.Forms.Padding(4);
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(850, 262);
            this.txtResult.TabIndex = 7;
            this.txtResult.Text = "";
            // 
            // panelTcpClient
            // 
            this.panelTcpClient.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelTcpClient.Controls.Add(this.txtLocalIpString);
            this.panelTcpClient.Controls.Add(this.label10);
            this.panelTcpClient.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelTcpClient.Location = new System.Drawing.Point(4, 451);
            this.panelTcpClient.Margin = new System.Windows.Forms.Padding(4);
            this.panelTcpClient.Name = "panelTcpClient";
            this.panelTcpClient.Size = new System.Drawing.Size(957, 55);
            this.panelTcpClient.TabIndex = 6;
            this.panelTcpClient.Visible = false;
            // 
            // txtLocalIpString
            // 
            this.txtLocalIpString.BackColor = System.Drawing.SystemColors.Info;
            this.txtLocalIpString.Location = new System.Drawing.Point(111, 15);
            this.txtLocalIpString.Margin = new System.Windows.Forms.Padding(4);
            this.txtLocalIpString.Name = "txtLocalIpString";
            this.txtLocalIpString.ReadOnly = true;
            this.txtLocalIpString.Size = new System.Drawing.Size(223, 28);
            this.txtLocalIpString.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 20);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 18);
            this.label10.TabIndex = 2;
            this.label10.Text = "本地主机：";
            // 
            // panelUDPSocket
            // 
            this.panelUDPSocket.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelUDPSocket.Controls.Add(this.txtRemotePort);
            this.panelUDPSocket.Controls.Add(this.label9);
            this.panelUDPSocket.Controls.Add(this.txtRemoteIPString);
            this.panelUDPSocket.Controls.Add(this.label3);
            this.panelUDPSocket.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelUDPSocket.Location = new System.Drawing.Point(4, 506);
            this.panelUDPSocket.Margin = new System.Windows.Forms.Padding(4);
            this.panelUDPSocket.Name = "panelUDPSocket";
            this.panelUDPSocket.Size = new System.Drawing.Size(957, 55);
            this.panelUDPSocket.TabIndex = 5;
            this.panelUDPSocket.Visible = false;
            // 
            // txtRemotePort
            // 
            this.txtRemotePort.Location = new System.Drawing.Point(452, 12);
            this.txtRemotePort.Margin = new System.Windows.Forms.Padding(4);
            this.txtRemotePort.Name = "txtRemotePort";
            this.txtRemotePort.Size = new System.Drawing.Size(122, 28);
            this.txtRemotePort.TabIndex = 14;
            this.txtRemotePort.Text = "8088";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(345, 16);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 18);
            this.label9.TabIndex = 3;
            this.label9.Text = "目标端口：";
            // 
            // txtRemoteIPString
            // 
            this.txtRemoteIPString.FormattingEnabled = true;
            this.txtRemoteIPString.Location = new System.Drawing.Point(111, 12);
            this.txtRemoteIPString.Margin = new System.Windows.Forms.Padding(4);
            this.txtRemoteIPString.Name = "txtRemoteIPString";
            this.txtRemoteIPString.Size = new System.Drawing.Size(223, 26);
            this.txtRemoteIPString.TabIndex = 2;
            this.txtRemoteIPString.Text = "127.0.0.1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 16);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "目标主机：";
            // 
            // panelTcpServer
            // 
            this.panelTcpServer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelTcpServer.Controls.Add(this.cbxConntects);
            this.panelTcpServer.Controls.Add(this.label2);
            this.panelTcpServer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelTcpServer.Location = new System.Drawing.Point(4, 561);
            this.panelTcpServer.Margin = new System.Windows.Forms.Padding(4);
            this.panelTcpServer.Name = "panelTcpServer";
            this.panelTcpServer.Size = new System.Drawing.Size(957, 55);
            this.panelTcpServer.TabIndex = 4;
            this.panelTcpServer.Visible = false;
            // 
            // cbxConntects
            // 
            this.cbxConntects.FormattingEnabled = true;
            this.cbxConntects.Location = new System.Drawing.Point(111, 14);
            this.cbxConntects.Margin = new System.Windows.Forms.Padding(4);
            this.cbxConntects.Name = "cbxConntects";
            this.cbxConntects.Size = new System.Drawing.Size(223, 26);
            this.cbxConntects.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "连接对象：";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(8, 623);
            this.splitter1.Margin = new System.Windows.Forms.Padding(4);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(965, 8);
            this.splitter1.TabIndex = 10;
            this.splitter1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtSendContent);
            this.panel3.Controls.Add(this.btnSend);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(8, 631);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(965, 94);
            this.panel3.TabIndex = 0;
            // 
            // txtSendContent
            // 
            this.txtSendContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSendContent.Location = new System.Drawing.Point(0, 0);
            this.txtSendContent.Margin = new System.Windows.Forms.Padding(4);
            this.txtSendContent.Name = "txtSendContent";
            this.txtSendContent.Size = new System.Drawing.Size(853, 94);
            this.txtSendContent.TabIndex = 2;
            this.txtSendContent.Text = "";
            // 
            // btnSend
            // 
            this.btnSend.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSend.Location = new System.Drawing.Point(853, 0);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(112, 94);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // sysNotifyIcon
            // 
            this.sysNotifyIcon.ContextMenuStrip = this.sysContextMenu;
            this.sysNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("sysNotifyIcon.Icon")));
            this.sysNotifyIcon.Text = "notifyIcon1";
            this.sysNotifyIcon.Visible = true;
            // 
            // sysContextMenu
            // 
            this.sysContextMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.sysContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuShow,
            this.toolStripMenuItem1,
            this.mnuExit});
            this.sysContextMenu.Name = "sysContextMenu";
            this.sysContextMenu.Size = new System.Drawing.Size(117, 70);
            // 
            // mnuShow
            // 
            this.mnuShow.Name = "mnuShow";
            this.mnuShow.Size = new System.Drawing.Size(116, 30);
            this.mnuShow.Text = "显示";
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(116, 30);
            this.mnuExit.Text = "退出";
            // 
            // sysToolBar
            // 
            this.sysToolBar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.sysToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbHelper,
            this.tbbSave,
            this.tbbClear});
            this.sysToolBar.Location = new System.Drawing.Point(300, 0);
            this.sysToolBar.Name = "sysToolBar";
            this.sysToolBar.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.sysToolBar.Size = new System.Drawing.Size(981, 33);
            this.sysToolBar.TabIndex = 8;
            this.sysToolBar.Text = "toolStrip1";
            // 
            // tbbHelper
            // 
            this.tbbHelper.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tbbHelper.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCheckUpdate,
            this.mnuAbout});
            this.tbbHelper.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbHelper.Name = "tbbHelper";
            this.tbbHelper.Size = new System.Drawing.Size(64, 28);
            this.tbbHelper.Text = "帮助";
            this.tbbHelper.Visible = false;
            // 
            // mnuCheckUpdate
            // 
            this.mnuCheckUpdate.Name = "mnuCheckUpdate";
            this.mnuCheckUpdate.Size = new System.Drawing.Size(182, 34);
            this.mnuCheckUpdate.Text = "检查更新";
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(182, 34);
            this.mnuAbout.Text = "关于";
            // 
            // tbbSave
            // 
            this.tbbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbSave.Name = "tbbSave";
            this.tbbSave.Size = new System.Drawing.Size(137, 28);
            this.tbbSave.Text = "保存数据(Save)";
            // 
            // tbbClear
            // 
            this.tbbClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbClear.Name = "tbbClear";
            this.tbbClear.Size = new System.Drawing.Size(142, 28);
            this.tbbClear.Text = "清除显示(Clear)";
            // 
            // sysStatusBar
            // 
            this.sysStatusBar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.sysStatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sysStatusLabel2});
            this.sysStatusBar.Location = new System.Drawing.Point(300, 758);
            this.sysStatusBar.Name = "sysStatusBar";
            this.sysStatusBar.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.sysStatusBar.Size = new System.Drawing.Size(981, 22);
            this.sysStatusBar.TabIndex = 9;
            // 
            // sysStatusLabel2
            // 
            this.sysStatusLabel2.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.sysStatusLabel2.Name = "sysStatusLabel2";
            this.sysStatusLabel2.Size = new System.Drawing.Size(958, 15);
            this.sysStatusLabel2.Spring = true;
            this.sysStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(8, 3, 8, 8);
            this.panel1.Size = new System.Drawing.Size(300, 780);
            this.panel1.TabIndex = 10;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ckbAppendAddress);
            this.groupBox4.Controls.Add(this.ckbAppendN);
            this.groupBox4.Controls.Add(this.cbxReceiveEncoding);
            this.groupBox4.Controls.Add(this.ckbAppendTime);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(8, 293);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(8);
            this.groupBox4.Size = new System.Drawing.Size(284, 171);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "接收区设置";
            this.groupBox4.Visible = false;
            // 
            // ckbAppendAddress
            // 
            this.ckbAppendAddress.AutoSize = true;
            this.ckbAppendAddress.Checked = true;
            this.ckbAppendAddress.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbAppendAddress.Location = new System.Drawing.Point(16, 63);
            this.ckbAppendAddress.Margin = new System.Windows.Forms.Padding(4);
            this.ckbAppendAddress.Name = "ckbAppendAddress";
            this.ckbAppendAddress.Size = new System.Drawing.Size(178, 22);
            this.ckbAppendAddress.TabIndex = 18;
            this.ckbAppendAddress.Text = "自动附加远程地址";
            this.ckbAppendAddress.UseVisualStyleBackColor = true;
            this.ckbAppendAddress.Visible = false;
            // 
            // ckbAppendN
            // 
            this.ckbAppendN.AutoSize = true;
            this.ckbAppendN.Checked = true;
            this.ckbAppendN.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbAppendN.Location = new System.Drawing.Point(16, 129);
            this.ckbAppendN.Margin = new System.Windows.Forms.Padding(4);
            this.ckbAppendN.Name = "ckbAppendN";
            this.ckbAppendN.Size = new System.Drawing.Size(196, 22);
            this.ckbAppendN.TabIndex = 17;
            this.ckbAppendN.Text = "自动附加换行分隔符";
            this.ckbAppendN.UseVisualStyleBackColor = true;
            this.ckbAppendN.Visible = false;
            // 
            // cbxReceiveEncoding
            // 
            this.cbxReceiveEncoding.FormattingEnabled = true;
            this.cbxReceiveEncoding.Location = new System.Drawing.Point(102, 24);
            this.cbxReceiveEncoding.Margin = new System.Windows.Forms.Padding(4);
            this.cbxReceiveEncoding.Name = "cbxReceiveEncoding";
            this.cbxReceiveEncoding.Size = new System.Drawing.Size(169, 26);
            this.cbxReceiveEncoding.TabIndex = 16;
            // 
            // ckbAppendTime
            // 
            this.ckbAppendTime.AutoSize = true;
            this.ckbAppendTime.Checked = true;
            this.ckbAppendTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbAppendTime.Location = new System.Drawing.Point(16, 96);
            this.ckbAppendTime.Margin = new System.Windows.Forms.Padding(4);
            this.ckbAppendTime.Name = "ckbAppendTime";
            this.ckbAppendTime.Size = new System.Drawing.Size(178, 22);
            this.ckbAppendTime.TabIndex = 11;
            this.ckbAppendTime.Text = "自动附加接收时间";
            this.ckbAppendTime.UseVisualStyleBackColor = true;
            this.ckbAppendTime.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 28);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 18);
            this.label12.TabIndex = 3;
            this.label12.Text = "编码格式";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbxSendEncoding);
            this.groupBox3.Controls.Add(this.cbxLoopSend);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtLoopInterval);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.btnClear);
            this.groupBox3.Controls.Add(this.btnSelect);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(8, 602);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(8);
            this.groupBox3.Size = new System.Drawing.Size(284, 170);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "发送区设置";
            this.groupBox3.Visible = false;
            // 
            // cbxSendEncoding
            // 
            this.cbxSendEncoding.FormattingEnabled = true;
            this.cbxSendEncoding.Location = new System.Drawing.Point(99, 24);
            this.cbxSendEncoding.Margin = new System.Windows.Forms.Padding(4);
            this.cbxSendEncoding.Name = "cbxSendEncoding";
            this.cbxSendEncoding.Size = new System.Drawing.Size(172, 26);
            this.cbxSendEncoding.TabIndex = 16;
            // 
            // cbxLoopSend
            // 
            this.cbxLoopSend.AutoSize = true;
            this.cbxLoopSend.Location = new System.Drawing.Point(14, 63);
            this.cbxLoopSend.Margin = new System.Windows.Forms.Padding(4);
            this.cbxLoopSend.Name = "cbxLoopSend";
            this.cbxLoopSend.Size = new System.Drawing.Size(160, 22);
            this.cbxLoopSend.TabIndex = 15;
            this.cbxLoopSend.Text = "数据流循环发送";
            this.cbxLoopSend.UseVisualStyleBackColor = true;
            this.cbxLoopSend.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(231, 96);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 18);
            this.label8.TabIndex = 14;
            this.label8.Text = "毫秒";
            this.label8.Visible = false;
            // 
            // txtLoopInterval
            // 
            this.txtLoopInterval.Location = new System.Drawing.Point(102, 92);
            this.txtLoopInterval.Margin = new System.Windows.Forms.Padding(4);
            this.txtLoopInterval.Name = "txtLoopInterval";
            this.txtLoopInterval.Size = new System.Drawing.Size(122, 28);
            this.txtLoopInterval.TabIndex = 13;
            this.txtLoopInterval.Text = "1000";
            this.txtLoopInterval.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 96);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 18);
            this.label7.TabIndex = 12;
            this.label7.Text = "发送间隔";
            this.label7.Visible = false;
            // 
            // btnClear
            // 
            this.btnClear.AutoSize = true;
            this.btnClear.Location = new System.Drawing.Point(147, 136);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(80, 18);
            this.btnClear.TabIndex = 10;
            this.btnClear.TabStop = true;
            this.btnClear.Text = "清除输入";
            this.btnClear.Visible = false;
            // 
            // btnSelect
            // 
            this.btnSelect.AutoSize = true;
            this.btnSelect.Location = new System.Drawing.Point(12, 136);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(80, 18);
            this.btnSelect.TabIndex = 9;
            this.btnSelect.TabStop = true;
            this.btnSelect.Text = "文件载入";
            this.btnSelect.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 28);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 18);
            this.label6.TabIndex = 3;
            this.label6.Text = "编码格式";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1281, 780);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.sysToolBar);
            this.Controls.Add(this.sysStatusBar);
            this.Controls.Add(this.panel1);
            this.Name = "FrmMain";
            this.Text = "调试工具";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.gbxResult.ResumeLayout(false);
            this.panelTcpClient.ResumeLayout(false);
            this.panelTcpClient.PerformLayout();
            this.panelUDPSocket.ResumeLayout(false);
            this.panelUDPSocket.PerformLayout();
            this.panelTcpServer.ResumeLayout(false);
            this.panelTcpServer.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.sysContextMenu.ResumeLayout(false);
            this.sysToolBar.ResumeLayout(false);
            this.sysToolBar.PerformLayout();
            this.sysStatusBar.ResumeLayout(false);
            this.sysStatusBar.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label labPort;
        private System.Windows.Forms.TextBox txtIPString;
        private System.Windows.Forms.Label labIPString;
        private System.Windows.Forms.ComboBox cbxProtocolType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox gbxResult;
        private System.Windows.Forms.RichTextBox txtResult;
        private System.Windows.Forms.Panel panelTcpClient;
        private System.Windows.Forms.TextBox txtLocalIpString;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panelUDPSocket;
        private System.Windows.Forms.TextBox txtRemotePort;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox txtRemoteIPString;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelTcpServer;
        private System.Windows.Forms.ComboBox cbxConntects;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RichTextBox txtSendContent;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.NotifyIcon sysNotifyIcon;
        private System.Windows.Forms.ContextMenuStrip sysContextMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuShow;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStrip sysToolBar;
        private System.Windows.Forms.ToolStripDropDownButton tbbHelper;
        private System.Windows.Forms.ToolStripMenuItem mnuCheckUpdate;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.ToolStripButton tbbSave;
        private System.Windows.Forms.ToolStripButton tbbClear;
        private System.Windows.Forms.StatusStrip sysStatusBar;
        private System.Windows.Forms.ToolStripStatusLabel sysStatusLabel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox ckbAppendAddress;
        private System.Windows.Forms.CheckBox ckbAppendN;
        private System.Windows.Forms.ComboBox cbxReceiveEncoding;
        private System.Windows.Forms.CheckBox ckbAppendTime;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbxSendEncoding;
        private System.Windows.Forms.CheckBox cbxLoopSend;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtLoopInterval;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.LinkLabel btnClear;
        private System.Windows.Forms.LinkLabel btnSelect;
        private System.Windows.Forms.Label label6;
    }
}