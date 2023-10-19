using Microsoft.Extensions.Options;
using WinFormsWebDav.Modes.Options;

namespace WinFormsWebDav
{
    public partial class MainForm : Form
    {
        public static SystemOptions staticSystemOptions = new SystemOptions();

        //组件
        private readonly FileLockAndUnLockUc _fileLockAndUnLock;
        private readonly AppWatcherUc _appWatcherUc1;
        private readonly MicroSoftMessageQueuingUc _microSoftMessageQueuingUc1;
        private readonly WebDavUc _webdav;

        //参数
        private readonly test _test;
        private readonly SystemOptions _systemOptions;
        public MainForm(FileLockAndUnLockUc fileLockAndUnLock, AppWatcherUc appWatcherUc1, MicroSoftMessageQueuingUc microSoftMessageQueuingUc1, WebDavUc webdav,
            IOptions<test> test, IOptions<SystemOptions> systemOptions)
        {
            _test = test.Value;
            _systemOptions = systemOptions.Value;
            _fileLockAndUnLock = fileLockAndUnLock;
            _appWatcherUc1 = appWatcherUc1;
            _microSoftMessageQueuingUc1 = microSoftMessageQueuingUc1;
            _webdav = webdav;
            InitializeComponent();
            InitData();
        }

        private void InitData()
        {
            cbIsShowMessageBox.Checked = _systemOptions.IsShowMessageBox;
            cbIsWriteLog.Checked = _systemOptions.IsWriteLog;
        }

        private void webDavToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void msLockAndUnLock_Click(object sender, EventArgs e)
        {

        }

        private void msFileReadOnly_Click(object sender, EventArgs e)
        {

        }

        private void msMSMQ_Click(object sender, EventArgs e)
        {

        }

        private void cbIsShowMessageBox_CheckedChanged(object sender, EventArgs e)
        {
            staticSystemOptions.IsShowMessageBox = cbIsShowMessageBox.Checked;
        }

        private void cbIsWriteLog_CheckedChanged(object sender, EventArgs e)
        {
            staticSystemOptions.IsWriteLog = cbIsWriteLog.Checked;
        }
    }
}
