using Microsoft.Extensions.Options;
using System.Windows.Forms;
using WinFormsWebDav.Modes.Options;

namespace WinFormsWebDav
{
    public partial class MainForm : Form
    {
        //组件
        private readonly FileLockAndUnLock _fileLockAndUnLock;
        private readonly AppWatcherUc _appWatcherUc1;
        private readonly MicroSoftMessageQueuingUc _microSoftMessageQueuingUc1;

        //参数
        private readonly test _test;
        private readonly SystemOptions _systemOptions;
        public MainForm(FileLockAndUnLock fileLockAndUnLock, AppWatcherUc appWatcherUc1, MicroSoftMessageQueuingUc microSoftMessageQueuingUc1,
            IOptions<test> test, IOptions<SystemOptions> systemOptions)
        {
            _test = test.Value;
            _systemOptions = systemOptions.Value;
            _fileLockAndUnLock = fileLockAndUnLock;
            _appWatcherUc1 = appWatcherUc1;
            _microSoftMessageQueuingUc1 = microSoftMessageQueuingUc1;
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
    }
}
