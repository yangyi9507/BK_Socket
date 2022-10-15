using LisRead;
using LisRead.IOCPSocket;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BK_Tool
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            this.Load += FrmMain_Load;
        }

        UDPSocket _UDPSocket = null;
        TcpSocketServer _TcpServer = null;
        TcpSocketClient _TcpClient = null;


        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.Text = this.sysNotifyIcon.Text = Application.ProductName + "(" + Application.ProductVersion + ")";

            this.btnConnect.Click += BtnConnect_Click;
            this.btnSend.Click += BtnSend_Click;
            this.tbbClear.Click += TbbClear_Click;
            this.tbbSave.Click += TbbSave_Click;
            this.mnuAbout.Click += MnuAbout_Click;
            this.btnClear.Click += BtnClear_Click;
            this.btnSelect.Click += BtnSelect_Click;
            this.mnuShow.Click += MnuShow_Click;
            this.sysNotifyIcon.DoubleClick += SysNotifyIcon_DoubleClick;
            this.FormClosing += FrmMain_FormClosing;
            this.mnuCheckUpdate.Click += MnuCheckUpdate_Click;


            this.cbxProtocolType.Items.Clear();
            this.cbxProtocolType.Items.Add("TCP Server");
            this.cbxProtocolType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbxProtocolType.SelectedIndexChanged += CbxSocketType_SelectedIndexChanged;
            this.cbxProtocolType.Text = "TCP Server";

            this.cbxReceiveEncoding.Items.Clear();
            //this.cbxReceiveEncoding.Items.Add(System.Text.Encoding.Default.BodyName.ToUpper());
            this.cbxReceiveEncoding.Items.Add(System.Text.Encoding.UTF8.BodyName.ToUpper());
            this.cbxReceiveEncoding.Items.Add(System.Text.Encoding.ASCII.BodyName.ToUpper());
            this.cbxReceiveEncoding.Items.Add("16进制");
            this.cbxReceiveEncoding.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbxReceiveEncoding.Text = System.Text.Encoding.UTF8.BodyName.ToUpper();

            this.cbxSendEncoding.Items.Clear();
            //this.cbxSendEncoding.Items.Add(System.Text.Encoding.Default.BodyName.ToUpper());
            this.cbxSendEncoding.Items.Add(System.Text.Encoding.UTF8.BodyName.ToUpper());
            this.cbxSendEncoding.Items.Add(System.Text.Encoding.ASCII.BodyName.ToUpper());
            this.cbxSendEncoding.Items.Add("16进制");
            this.cbxSendEncoding.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbxSendEncoding.Text = System.Text.Encoding.UTF8.BodyName.ToUpper();

            this.txtResult.Dock = DockStyle.Fill;

        }

        private void MnuCheckUpdate_Click(object sender, EventArgs e)
        {
            //检查更新
            //AppUpdaterBLL.CheckUpdate();
        }

        private void SysNotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.Activate();
        }

        private void MnuShow_Click(object sender, EventArgs e)
        {
            this.Show();
            this.Activate();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.sysNotifyIcon.Visible = false;
            this.sysNotifyIcon.Dispose();

            if (this._UDPSocket != null)
                this._UDPSocket.Dispose();

            if (this._TcpClient != null)
                this._TcpClient.Dispose();
            if (this._TcpServer != null)
                this._TcpServer.Dispose();
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "文本文件|*.log;*.txt";
            if (dialog.ShowDialog() != DialogResult.OK)
                return;
            this.txtSendContent.Text = System.IO.File.ReadAllText(dialog.FileName);
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            this.txtSendContent.Text = "";
        }

        private void MnuAbout_Click(object sender, EventArgs e)
        {
            //new AboutBox().ShowDialog();
        }

        private void TbbSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "文本文件|*.log;*.txt";
            if (dialog.ShowDialog() != DialogResult.OK)
                return;
            System.IO.File.WriteAllText(dialog.FileName, this.txtResult.Text, Encoding.UTF8);
        }

        private void TbbClear_Click(object sender, EventArgs e)
        {
            this.txtResult.Text = "";
        }

        private void CbxSocketType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbxProtocolType.Text.ToLower() == "TCP Server".ToLower()
                || this.cbxProtocolType.Text.ToLower() == "UDP".ToLower())
            {
                this.labIPString.Text = "（2）本地IP地址";
                this.labPort.Text = "（3）本地端口号";
            }
            else
            {
                this.labIPString.Text = "（2）服务器IP地址";
                this.labPort.Text = "（3）服务器端口号";
            }
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            this.btnConnect.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (this.btnConnect.Text == "连接")
                {
                    if (this.txtIPString.Text.Trim() == "")
                    {
                        WinMessageBox.Show("IP地址不能为空！");
                        this.txtIPString.Focus();
                        return;
                    }
                    if (this.txtPort.Text.Trim() == "")
                    {
                        WinMessageBox.Show("端口号不能为空！");
                        this.txtPort.Focus();
                        return;
                    }
                    if (this.cbxProtocolType.Text.ToLower() == "UDP".ToLower())
                    {
                        this._UDPSocket = new UDPSocket(this.txtIPString.Text.Trim(), int.Parse(this.txtPort.Text));
                        //this._UDPSocket.ReceiveEncoding = System.Text.Encoding.GetEncoding(this.cbxReceiveEncoding.Text);
                        this._UDPSocket.ReceiveData += UDPSocket_ReceiveData;
                        if (this._UDPSocket.StartReceive() == false)
                        {
                            WinMessageBox.Show("连接服务器失败！");
                            this.sysStatusLabel2.Text = "连接服务器失败！";
                            return;
                        }
                        this.panelUDPSocket.Visible = true;
                    }
                    else if (this.cbxProtocolType.Text.ToLower() == "TCP Server".ToLower())
                    {
                        this._TcpServer = new TcpSocketServer();
                        //this._TcpServer.ReceiveEncoding = System.Text.Encoding.GetEncoding(this.cbxReceiveEncoding.Text);
                        this._TcpServer.RemoteConnect += TcpServer_RemoteConnect;
                        this._TcpServer.ReceiveData += TcpServer_ReceiveData;
                        this._TcpServer.RemoteClose += TcpServer_RemoteClose;
                        if (this._TcpServer.Start(this.txtIPString.Text.Trim(), int.Parse(this.txtPort.Text)) == false)
                        {
                            WinMessageBox.Show("连接服务器失败！");
                            this.sysStatusLabel2.Text = "连接服务器失败！";
                            return;
                        }

                        this.LoadConnect();
                        this.panelTcpServer.Visible = true;
                    }
                    else if (this.cbxProtocolType.Text.ToLower() == "TCP Client".ToLower())
                    {
                        this._TcpClient = new TcpSocketClient();
                        //this._TcpClient.ReceiveEncoding = System.Text.Encoding.GetEncoding(this.cbxReceiveEncoding.Text);
                        this._TcpClient.RemoteClose += TcpClient_RemoteClose;
                        if (this._TcpClient.Connect(this.txtIPString.Text.Trim(), int.Parse(this.txtPort.Text)) == false)
                        {
                            WinMessageBox.Show("连接服务器失败！");
                            this.sysStatusLabel2.Text = "连接服务器失败！";
                            return;
                        }

                        this._TcpClient.ReceiveData += TcpClient_ReceiveData;
                        if (this._TcpClient.StartReceive() == false)
                            return;

                        this.txtLocalIpString.Text = this._TcpClient.Socket.LocalEndPoint.ToString();
                        this.panelTcpClient.Visible = true;
                    }
                    this.txtResult.Text = "";
                    this.cbxProtocolType.Enabled = false;
                    //this.cbxProtocolType.ReadOnly = true;
                    this.cbxProtocolType.BackColor = System.Drawing.SystemColors.Info;
                    this.txtIPString.ReadOnly = true;
                    this.txtIPString.BackColor = System.Drawing.SystemColors.Info;
                    this.txtPort.ReadOnly = true;
                    this.txtPort.BackColor = System.Drawing.SystemColors.Info;

                    this.btnConnect.Text = "断开";
                }
                else
                {
                    if (this._UDPSocket != null)
                        this._UDPSocket.Close();
                    if (this._TcpClient != null)
                        this._TcpClient.Close();
                    if (this._TcpServer != null)
                        this._TcpServer.Close();

                    this.btnConnect.Text = "连接";
                    this.panelUDPSocket.Visible = false;
                    this.panelTcpServer.Visible = false;
                    this.panelTcpClient.Visible = false;
                    this.cbxProtocolType.Enabled = true;
                    this.cbxProtocolType.BackColor = System.Drawing.SystemColors.Window;
                    this.txtIPString.ReadOnly = false;
                    this.txtIPString.BackColor = System.Drawing.SystemColors.Window;
                    this.txtPort.ReadOnly = false;
                    this.txtPort.BackColor = System.Drawing.SystemColors.Window;
                }
            }
            finally
            {
                this.btnConnect.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

        private void TcpServer_RemoteConnect()
        {
            if (this._TcpServer == null)
                return;
            this.LoadConnect();
        }

        private void LoadConnect()
        {
            this.cbxConntects.Invoke((EventHandler)delegate
            {
                this.cbxConntects.Items.Clear();
                this.cbxConntects.Items.Add("所有远程连接");
                foreach (var item in this._TcpServer.Sessions.Keys)
                {
                    this.cbxConntects.Items.Add(item);
                }
                this.cbxConntects.Text = "所有远程连接";
                this.cbxConntects.DropDownStyle = ComboBoxStyle.DropDownList;
            });
        }

        private void TcpServer_ReceiveData(IPEndPoint remote, byte[] buffer, int count)
        {
            this.AppendText(remote, buffer, count);
        }

        private void TcpServer_RemoteClose(string key)
        {
            if (this._TcpServer == null)
                return;

            this.LoadConnect();
        }


        private void TcpClient_ReceiveData(System.Net.IPEndPoint remote, byte[] buffer, int count)
        {
            this.AppendText(remote, buffer, count);
        }

        private void TcpClient_RemoteClose(string key)
        {
            this.btnConnect.PerformClick();
        }

        private void UDPSocket_ReceiveData(System.Net.IPEndPoint remote, byte[] buffer, int length)
        {
            this.AppendText(remote, buffer, length);
        }

        private void AppendText(System.Net.IPEndPoint remote, byte[] buffer, int length)
        {
            if (buffer == null || length <= 0 || buffer.Length < length)
                return;

            this.txtResult.Invoke((EventHandler)delegate
            {
                string data = string.Empty;
                if (this.cbxReceiveEncoding.Text == "16进制")
                    data = this.ByteToHex(buffer, 0, length);
                else
                    data = System.Text.Encoding.GetEncoding(this.cbxReceiveEncoding.Text).GetString(buffer, 0, length);
                if (this.ckbAppendAddress.Checked)
                    this.txtResult.AppendText("[" + remote.ToString() + "]");
                if (this.ckbAppendTime.Checked)
                    this.txtResult.AppendText("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff") + "]");
                this.txtResult.AppendText(data);

                if (ConfigurationManager.AppSettings["Equid"].ToString() == "TDDB")
                {
                    TDDBDataHandle dataHandle = new TDDBDataHandle();
                    txtSendContent.Text = dataHandle.ChuLiOneHL7(data);

                    if (this.SendData() == false)
                        return;
                    this.sysStatusLabel2.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff") + "-发送成功";
                }
                else if (ConfigurationManager.AppSettings["Equid"].ToString() == "SFL")
                {
                    SFLDataHandle dataHandle = new SFLDataHandle();
                    dataHandle.ChuLiOneHL7(data);                    
                }


                if (this.ckbAppendN.Checked)
                    this.txtResult.AppendText("\n");
                this.txtResult.ScrollToCaret();
            });
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            this.btnSend.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (this.btnSend.Text == "发送")
                {
                    if (this.SendData() == false)
                        return;
                    this.sysStatusLabel2.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff") + "-发送成功";

                    //循环发送
                    if (this.cbxLoopSend.Checked)
                    {
                        int interval = 1000;
                        int.TryParse(this.txtLoopInterval.Text, out interval);
                        if (interval < 100)
                            interval = 100;

                        this._SysTimer = new System.Timers.Timer();
                        this._SysTimer.Interval = interval;
                        this._SysTimer.Elapsed += _SysTimer_Elapsed;
                        this._SysTimer.Start();

                        this.btnSend.Text = "停止发送";
                    }
                }
                else
                {
                    if (this._Worker != null && this._Worker.IsBusy)
                        this._Worker.CancelAsync();

                    this._SysTimer.Stop();
                    this.btnSend.Text = "发送";
                }
            }
            catch (Exception ex)
            {
                Logger.Error("发送数据异常：" + ex.ToString());
                MessageBox.Show("发送数据异常：" + ex.Message, "异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.btnSend.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }
        private System.Timers.Timer _SysTimer = null;
        private BackgroundWorker _Worker = null;

        private void _SysTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (this._Worker != null && this._Worker.IsBusy)
            {
                Logger.Info("发送线程还在运行!");
                this.sysStatusLabel2.Text = "发送线程还在运行!";
                return;
            }
            this._Worker = new BackgroundWorker();
            this._Worker.WorkerReportsProgress = true;
            this._Worker.WorkerSupportsCancellation = true;
            this._Worker.DoWork += _Worker_DoWork;
            this._Worker.RunWorkerAsync();
        }

        private void _Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.SendData();
        }

        private bool SendData()
        {
            if (this.txtSendContent.Text.Trim() == "")
            {
                this.sysStatusLabel2.Text = "发送内容不能为空!";
                this.txtSendContent.Focus();
                return false;
            }
            byte[] bytes = new byte[0];
            if (this.cbxSendEncoding.Text == "16进制")
                bytes = this.HexToByte(this.txtSendContent.Text);
            else
                bytes = System.Text.Encoding.GetEncoding(this.cbxSendEncoding.Text).GetBytes(this.txtSendContent.Text);
            if (this.cbxProtocolType.Text.ToLower() == "UDP".ToLower())
            {
                if (this._UDPSocket == null || this._UDPSocket.Socket == null)
                {
                    WinMessageBox.Show("请先连接服务端！");
                    return false;
                }
                if (this.txtRemoteIPString.Text.Trim() == "")
                {
                    WinMessageBox.Warning("目标主机不能为空!");
                    this.txtRemoteIPString.Focus();
                    return false;
                }
                if (this.txtRemotePort.Text.Trim() == "")
                {
                    WinMessageBox.Warning("主机端口不能为空!");
                    this.txtRemotePort.Focus();
                    return false;
                }

                this._UDPSocket.SendTo(this.txtRemoteIPString.Text, int.Parse(this.txtRemotePort.Text), bytes);
            }
            else if (this.cbxProtocolType.Text.ToLower() == "TCP Server".ToLower())
            {
                if (this._TcpServer == null || this._TcpServer.Socket == null)
                {
                    WinMessageBox.Show("请先连接服务端！");
                    return false;
                }

                if (this._TcpServer.Sessions.Count <= 0)
                {
                    WinMessageBox.Warning("当前没有连接对象！");
                    return false;
                }
                if (this.cbxConntects.Text == "所有远程连接")
                {
                    this._TcpServer.SendTo(bytes);
                }
                else
                {
                    if (this._TcpServer.Sessions.ContainsKey(this.cbxConntects.Text) == false)
                    {
                        WinMessageBox.Show("当前没有连接对象！" + this.cbxConntects.Text);
                        return false;
                    }
                    var session = this._TcpServer.Sessions[this.cbxConntects.Text];
                    //this._TcpServer.SendTo(session.Client.RemoteEndPoint, bytes);//发送失败
                    this._TcpServer.SendTo(session, bytes);
                }
            }
            else if (this.cbxProtocolType.Text.ToLower() == "TCP Client".ToLower())
            {
                if (this._TcpClient == null || this._TcpClient.Socket == null)
                {
                    WinMessageBox.Show("请先连接服务端！");
                    return false;
                }

                this._TcpClient.Send(bytes);
            }
            return true;
        }

        /// <summary>
        /// 字节数组转16进制字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public string ByteToHex(byte[] bytes, int start, int count)
        {
            StringBuilder result = new StringBuilder();
            try
            {
                if (bytes != null)
                {
                    for (int i = start; i < count; i++)
                    {
                        if (bytes.Length < i)
                            break;
                        //两个16进制用空格隔开,方便看数据
                        if (i == start)
                            result.Append(bytes[i].ToString("X2"));
                        else
                            result.Append(" " + bytes[i].ToString("X2"));
                    }
                }
                return result.ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }

        /// <summary>
        /// 字符串转16进制格式,不够自动前面补零
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public byte[] HexToByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");//清除空格
            if ((hexString.Length % 2) != 0)//奇数个
                hexString = hexString + " ";

            byte[] result = new byte[(hexString.Length) / 2];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Convert.ToByte(hexString.Substring(i * 2, 2).Replace(" ", ""), 16);
            }
            return result;
        }
    }
}
