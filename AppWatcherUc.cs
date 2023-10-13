using Microsoft.Extensions.Options;
using System.Diagnostics;
using WinFormsWebDav.Base;
using WinFormsWebDav.Constants;
using WinFormsWebDav.Modes.Options;

namespace WinFormsWebDav
{
    public partial class AppWatcherUc : BaseUserControl
    {
        private readonly DefaultInfoOptions _defaultInfoOptions;
        private delegate void SetTextEvent(string text);
        public AppWatcherUc(IOptions<DefaultInfoOptions> defaultInfoOptions)
        {
            InitializeComponent();

            _defaultInfoOptions = defaultInfoOptions.Value;
            ProcessMonitor.ProcessClosed += (s, e) => { ShowMessage($"{MessageConstants.PROCESS_SHUT_DOWN}\n"); };

            InitData();
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        protected override void InitData()
        {
            base.InitData();
            tbWatcher.Text = _defaultInfoOptions.WatcherProcess;
        }

        /// <summary>
        /// 显示消息
        /// </summary>
        /// <param name="msg"></param>
        protected override void ShowMessage(string msg)
        {
            //base.ShowMessage(msg);
            if (this.rtbLog.InvokeRequired)
            {
                //instansiate a delegate with the method
                SetTextEvent myDelegate = new SetTextEvent(ShowMessage);
                //Invoke delegate
                this.rtbLog.Invoke(myDelegate, msg);
            }
            else
            {
                //InvokedRequired is false, so call the control directly
                this.rtbLog.Text += msg;
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

        /// <summary>
        /// 监控应用程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                ShowMessage($"{MessageConstants.PROCESS_NOT_FOUND}\n");
            }
            else
            {
                ShowMessage($"{MessageConstants.MONITORING_PROCESS}\n");
                ProcessMonitor.MonitorForExit(process);
            }
        }
    }
}
