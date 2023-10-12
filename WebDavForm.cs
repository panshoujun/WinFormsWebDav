using MSMQ.Messaging;
using System;
using System.Diagnostics;
using System.Management;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using WinFormsWebDav.Constants;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace WinFormsWebDav
{
    public partial class WebDavForm : Form
    {
        private readonly WebDavInfo _webDavInfo;
        private readonly IHttpClientFactory _httpClientFactory;

        private delegate void SetTextEvent(string text);
        public WebDavForm(WebDavInfo webDavInfo, IHttpClientFactory httpClientFactory)
        {
            //MessageBox.Show(JsonSerializer.Serialize(webDavInfo));
            _webDavInfo = webDavInfo;
            _httpClientFactory = httpClientFactory;

            InitializeComponent();
            //Control.CheckForIllegalCrossThreadCalls = false; //����ʱ ȡ�����̼߳��
            InitComponentData();
            ProcessMonitor.ProcessClosed += (s, e) => { testMethod("�����ѱ��ر�"); };
            var ss = GetCPUSerialNumber();
        }

        /// <summary>
        /// ��ʼ���������
        /// </summary>
        private void InitComponentData()
        {
            //cbDriveLetter.Items.Add("");
            for (int i = 'A'; i <= 'Z'; i++)
            {
                cbDriveLetter.Items.Add((char)i);
            }

            if (_webDavInfo != null && string.IsNullOrEmpty(_webDavInfo.MountPath) && !string.IsNullOrEmpty(_webDavInfo.UserName) && !string.IsNullOrEmpty(_webDavInfo.Password))
            {
                rtbPath.Text = _webDavInfo.MountPath;
                tbUserName.Text = _webDavInfo.UserName;
                tbPassword.Text = _webDavInfo.Password;
                MountWebDAV(rtbPath.Text, tbUserName.Text, tbPassword.Text);
            }

            tbServiceAddress.Text = MessageQueueConstants.DEFAULT_SERVICE_ADDRESS;
            tbQueueName.Text = MessageQueueConstants.DEFAULT_QUEUE_NAME;
            rtbMessage.Text = MessageQueueConstants.DEFAULT_BODY;
        }

        /// <summary>
        /// ִ�в���
        /// </summary>
        /// <param name="doscommand"></param>
        private Tuple<bool, string> DoProcess(string doscommand)
        {
            Tuple<bool, string> result = new Tuple<bool, string>(false, string.Empty);

            Process proc = new Process();
            try
            {
                proc.StartInfo.FileName = "cmd.exe";
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardInput = true;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.CreateNoWindow = true;
                proc.Start();
                proc.StandardInput.WriteLine(doscommand);
                proc.StandardInput.AutoFlush = true; // ǰ��һ��������Ƿ�ִ�гɹ���ִ�к���(exit)��������ִ��exit����������ReadToEnd()���������
                proc.StandardInput.WriteLine("exit");

                //���޵ȴ�
                //proc.WaitForExit();

                ////���ߵȴ�
                //while (!proc.HasExited)
                //{
                //    proc.WaitForExit(200);
                //}

                ////���ȴ�3��
                proc.WaitForExit(3000);
                //proc.Kill();
                string msg = proc.StandardOutput.ReadToEnd();
                string errormsg = proc.StandardError.ReadToEnd();
                proc.StandardError.Close();
                proc.StandardOutput.Close();
                if (string.IsNullOrEmpty(errormsg))
                {
                    result = new Tuple<bool, string>(true, msg);
                }
                else
                {
                    result = new Tuple<bool, string>(false, errormsg);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                proc.Close();
                proc.Dispose();
                if (cbIsAutoClose.SelectedIndex == 1)
                {
                    this.Close();
                }
            }

            return result;
        }

        /// <summary>
        /// mount����Զ�̼����
        /// </summary>
        /// <param name="path"></param>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        private bool MountWebDAV(string path = "http://qatest007.cscloud.cscad.net:6003/api/document/webdav", string userName = "admin", string passWord = "cst_Ju490XH68A5dOXRFY71JiJHzQmZyHzAWwk7aaEmzESbdu5vNDYGE8KnuUrkB")
        {
            string doscommand = string.Format(DosCommandConstants.MOUNT_WEBDAV, rtbPath.Text, tbUserName.Text, tbPassword.Text);
            Tuple<bool, string> result;
            string? driveLetter = null;
            if (cbDriveLetter.SelectedIndex >= 0)
            {
                driveLetter = cbDriveLetter.Text;

                ////��һ����֤��ѡ�̷��Ƿ���Թ���,��Ҫ�ɲ�Ҫ��
                //var tempResult = DoProcess(DosCommandConstants.GET_USED_DRIVE_LETTER);
                //if (!tempResult.Item1)
                //{
                //    rtbLog.Text += tempResult.Item2;
                //    return false;
                //}

                //var list = GetDiskDriveList(tempResult.Item2, RegexPatternConstants.GET_USED_DRIVE_LETTER, "DiskDrive");
                //if (list.Contains(driveLetter))
                //{
                //    rtbLog.Text += $"{driveLetter}�Ѵ���,�޷�����\n";
                //    return false;
                //}

                doscommand = string.Format(DosCommandConstants.MOUNT_WEBDAV_BY_DRIVE_LETTER, rtbPath.Text, tbUserName.Text, tbPassword.Text, cbDriveLetter.Text);
            }

            result = DoProcess(doscommand);
            if (result.Item1)
            {
                rtbLog.Text += result.Item2;
                rtbLog.Text += $"�����̷�Ϊ:\n{driveLetter ?? GetDiskDriveList(result.Item2, RegexPatternConstants.GET_MOUNT_DISK_DRIVE, "DiskDrive").FirstOrDefault()}\n";
            }
            else
            {
                rtbLog.Text += result.Item2;
            }

            return result.Item1;
        }

        /// <summary>
        /// ��ȡ�����б�
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pattern"></param>
        /// <param name="group"></param>
        /// <returns></returns>
        private List<string> GetDiskDriveList(string input, string pattern, string group)
        {
            List<string> list = new List<string>();
            Regex reg = new Regex(pattern);
            var matchs = reg.Matches(input);
            if (matchs.Count > 0)
            {
                list.AddRange(matchs.Select(p => p.Groups[group].Value));
            }
            return list;
        }

        /// <summary>
        /// ��ȡ�����б�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btGetWebDavList_Click(object sender, EventArgs e)
        {
            var result = DoProcess(DosCommandConstants.GET_USED_DRIVE_LETTER);

            if (!result.Item1)
            {
                rtbLog.Text += result.Item2;
                return;
            }

            var list = GetDiskDriveList(result.Item2, RegexPatternConstants.GET_USED_DRIVE_LETTER, "DiskDrive");
            rtbLog.Text += $"�����б�:\n{string.Join('\n', list)}\n";
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btMountWebdav_Click(object sender, EventArgs e)
        {
            MountWebDAV(rtbPath.Text, tbUserName.Text, tbPassword.Text);
        }

        /// <summary>
        /// ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btUnMountWebDav_Click(object sender, EventArgs e)
        {
            string doscommand = DosCommandConstants.UN_MOUNT_ALL_WEBDAV;
            if (cbDriveLetter.SelectedIndex >= 0)
            {
                doscommand = string.Format(DosCommandConstants.UN_MOUNT_WEBDAV, cbDriveLetter.Text);
            }

            var result = DoProcess(doscommand);

            rtbLog.Text += result.Item2;


        }

        /// <summary>
        /// �����־
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btClear_Click(object sender, EventArgs e)
        {
            rtbLog.Text = string.Empty;
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnSend_Click(object sender, EventArgs e)
        {
            var client = _httpClientFactory.CreateClient();
            string url = $"http://qatest007.cscloud.cscad.net:6003/api/document/project/{tbProject.Text}/lock-file/{tbFile.Text}";
            client.BaseAddress = new Uri(url);
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Put, client.BaseAddress);
            requestMessage.Content = new StringContent(JsonSerializer.Serialize(new PutLockFileRequest { ForceChangeLock = true, TimeoutSeconds = 60 }), Encoding.UTF8, "application/json");
            requestMessage.Headers.Add("Authorization", $"Token {tbPassword.Text}");

            var response = await client.SendAsync(requestMessage);
            var content = await response.Content.ReadAsStringAsync();
            rtbLog.Text += content;
            //MessageBox.Show(content);
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnUnLock_Click(object sender, EventArgs e)
        {
            var client = _httpClientFactory.CreateClient();
            string url = $"http://qatest007.cscloud.cscad.net:6003/api/document/project/{tbProject.Text}/unlock-file/{tbFile.Text}";
            client.BaseAddress = new Uri(url);
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Put, client.BaseAddress);
            requestMessage.Headers.Add("Authorization", $"Token {tbPassword.Text}");

            var response = await client.SendAsync(requestMessage);
            var content = await response.Content.ReadAsStringAsync();
            rtbLog.Text += content;
            //MessageBox.Show(content);
        }

        /// <summary>
        /// ����Ϊֻ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetReadOnly_Click(object sender, EventArgs e)
        {
            var filePath = btReadOnlyFile.Text;
            File.SetAttributes(filePath, FileAttributes.ReadOnly);
        }

        /// <summary>
        /// ȡ��ֻ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelReadOnly_Click(object sender, EventArgs e)
        {
            var filePath = btReadOnlyFile.Text;
            File.SetAttributes(filePath, FileAttributes.Normal);
        }


        private string GetCPUSerialNumber()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
                var sss = searcher.Get();
                string cpuSerialNumber = "";
                foreach (ManagementObject mo in searcher.Get())
                {
                    cpuSerialNumber = mo["ProcessorId"].ToString().Trim();
                    break;
                }
                return cpuSerialNumber;
            }
            catch
            {
                return "";
            }
        }

        private void btnWatch_Click(object sender, EventArgs e)
        {
            //var processes = Process.GetProcessesByName(tbWatcher.Text).FirstOrDefault();
            //if (processes == null)
            //{
            //    MessageBox.Show("δ�ҵ�����");
            //}
            //ProcessMonitor.ProcessClosed = new EventHandler(sender, e){ testMethod("�����ѱ��ر�"); };
            var sss = Process.GetProcessesByName(tbWatcher.Text);
            var process = Process.GetProcessesByName(tbWatcher.Text).FirstOrDefault();
            if (process == null)
            {
                rtbLog.Text += "δ�ҵ�����.";
            }
            else
            {
                rtbLog.Text += "���ڼ�ؽ���...";
                ProcessMonitor.MonitorForExit(process);
            }
            //Console.ReadKey();
        }

        private void testMethod(string str)
        {
            // query the control's(here is lstResults) InvokeRequired
            if (this.rtbLog.InvokeRequired)
            {
                //instansiate a delegate with the method
                SetTextEvent myDelegate = new SetTextEvent(testMethod);
                //Invoke delegate
                this.rtbLog.Invoke(myDelegate, str);
            }
            else
            {
                //InvokedRequired is false, so call the control directly
                this.rtbLog.Text += str;
            }
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            string queue = $"{tbServiceAddress.Text}\\{tbQueueName.Text}";
            if (!MessageQueue.Exists(queue))
            {
                using var msmq = MessageQueue.Create(queue, true);
            }
            using var mqSend = new MessageQueue(queue);
            using var msg = new MSMQ.Messaging.Message(rtbMessage.Text, new XmlMessageFormatter(new Type[] { typeof(string) }));
            if (int.TryParse(tbExpirationTime.Text, out int time) && time > 0)
            {
                msg.TimeToBeReceived = TimeSpan.FromSeconds(time);
            }
            if (mqSend.Transactional)
            {
                using var msgTransaction = new MessageQueueTransaction();
                msgTransaction.Begin();
                mqSend.Send(msg, msgTransaction);
                msgTransaction.Commit();
            }
            else
            {
                mqSend.Send(msg);
            }
            MessageBox.Show($"���ͳɹ�:{rtbMessage.Text}");
        }

        private void tbnReceive_Click(object sender, EventArgs e)
        {
            string queue = $"{tbServiceAddress.Text}\\{tbQueueName.Text}";
            using var mqReceive = new MessageQueue(queue)
            {
                Formatter = new XmlMessageFormatter(new Type[] { typeof(string) })
            };
            var msg = mqReceive.Receive();
            var bodyReceive = msg.Body as string;
            MessageBox.Show(bodyReceive);
        }

        private void �˵�1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("asdf");
        }



        //private bool MountWebDAVOld(string path = "http://qatest007.cscloud.cscad.net:6003/api/document/webdav", string userName = "admin", string passWord = "cst_Ju490XH68A5dOXRFY71JiJHzQmZyHzAWwk7aaEmzESbdu5vNDYGE8KnuUrkB")
        //{
        //    bool Flag = false;
        //    Process proc = new Process();
        //    try
        //    {
        //        proc.StartInfo.FileName = "cmd.exe";
        //        proc.StartInfo.UseShellExecute = false;
        //        proc.StartInfo.RedirectStandardInput = true;
        //        proc.StartInfo.RedirectStandardOutput = true;
        //        proc.StartInfo.RedirectStandardError = true;
        //        proc.StartInfo.CreateNoWindow = true;
        //        proc.Start();
        //        string doscommand = string.Format(DosCommandConstants.MOUNT_WEBDAV, path, userName, passWord);//$"net use * {path} /user:{userName} {passWord}";
        //        //string dosLine = @"net use " + disk + ": " + path + " " + passWord + " /User:" + userName;
        //        //string dosLine = @"net use " + path + " /User:" + userName + " " + passWord + " /PERSISTENT:YES";
        //        proc.StandardInput.WriteLine(doscommand);
        //        proc.StandardInput.AutoFlush = true;
        //        // ǰ��һ��������Ƿ�ִ�гɹ���ִ�к���(exit)��������ִ��exit����������ReadToEnd()���������
        //        proc.StandardInput.WriteLine("exit");
        //        while (!proc.HasExited)
        //        {
        //            proc.WaitForExit(200);
        //        }
        //        string msg = proc.StandardOutput.ReadToEnd();
        //        string errormsg = proc.StandardError.ReadToEnd();
        //        proc.StandardError.Close();
        //        proc.StandardOutput.Close();
        //        if (string.IsNullOrEmpty(errormsg))
        //        {
        //            Flag = true;
        //            rtbLog.Text += msg;
        //            rtbLog.Text += GetDiskDrive(msg);
        //        }
        //        else
        //        {
        //            rtbLog.Text += errormsg;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        proc.Close();
        //        proc.Dispose();
        //        if (cbIsAutoClose.SelectedIndex == 1)
        //        {
        //            this.Close();
        //        }
        //    }


        //    return Flag;
        //}

    }
}