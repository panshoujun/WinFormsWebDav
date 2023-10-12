using System.Diagnostics;

namespace WinFormsWebDav
{
    public partial class AppWatcherUc : UserControl
    {
        private delegate void SetTextEvent(string text);
        public AppWatcherUc()
        {
            InitializeComponent();
            ProcessMonitor.ProcessClosed += (s, e) => { ChangeLog("进程已被关闭\n"); };
        }

        private void ChangeLog(string str)
        {
            // query the control's(here is lstResults) InvokeRequired
            if (this.rtbLog.InvokeRequired)
            {
                //instansiate a delegate with the method
                SetTextEvent myDelegate = new SetTextEvent(ChangeLog);
                //Invoke delegate
                this.rtbLog.Invoke(myDelegate, str);
            }
            else
            {
                //InvokedRequired is false, so call the control directly
                this.rtbLog.Text += str;
            }
        }

        /// <summary>
        /// 清除日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btClear_Click(object sender, EventArgs e)
        {
            rtbLog.Text = string.Empty;
        }

        private void btnWatch_Click(object sender, EventArgs e)
        {
            //var processes = Process.GetProcessesByName(tbWatcher.Text).FirstOrDefault();
            //if (processes == null)
            //{
            //    MessageBox.Show("未找到进程");
            //}
            //ProcessMonitor.ProcessClosed = new EventHandler(sender, e){ testMethod("进程已被关闭"); };
            //var sss = Process.GetProcessesByName(tbWatcher.Text);
            var process = Process.GetProcessesByName(tbWatcher.Text).FirstOrDefault();
            if (process == null)
            {
                rtbLog.Text += "未找到进程.\n";
            }
            else
            {
                rtbLog.Text += "正在监控进程...\n";
                ProcessMonitor.MonitorForExit(process);
            }
        }
    }
}
