using Microsoft.Extensions.Options;
using System.Diagnostics;
using WinFormsWebDav.Base;
using WinFormsWebDav.Constants;
using WinFormsWebDav.Modes;
using WinFormsWebDav.Modes.Options;

namespace WinFormsWebDav
{
    public partial class AppWatcherUcNew : BaseUserControlNew
    {
        public event EventHandler ShowMessage;
        private readonly DefaultInfoOptions _defaultInfoOptions;

        public AppWatcherUcNew(IOptions<DefaultInfoOptions> defaultInfoOptions)
        {
            InitializeComponent();

            _defaultInfoOptions = defaultInfoOptions.Value;

            //ProcessMonitor.ProcessClosed += (s, e) => { ShowMessageLocal($"{MessageConstants.PROCESS_SHUT_DOWN}\n"); };
            ProcessMonitor.ProcessClosed += (s, e) => { ShowMessage?.Invoke(this, new MessageEventArgs { Msg = $"{MessageConstants.PROCESS_SHUT_DOWN}\n" }); };

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
        /// 监控应用程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWatch_Click(object sender, EventArgs e)
        {
            var process = Process.GetProcessesByName(tbWatcher.Text).FirstOrDefault();
            if (process == null)
            {
                ShowMessage?.Invoke(this, new MessageEventArgs { Msg = $"{MessageConstants.PROCESS_NOT_FOUND}\n" });
            }
            else
            {
                ShowMessage?.Invoke(this, new MessageEventArgs { Msg = $"{MessageConstants.MONITORING_PROCESS}\n" });
                ProcessMonitor.MonitorForExit(process);
            }
        }
    }
}
