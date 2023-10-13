using Microsoft.Extensions.Options;
using System.Windows.Forms;
using WinFormsWebDav.Modes.Options;

namespace WinFormsWebDav
{
    public partial class MainForm : Form
    {
        private readonly FileLockAndUnLock _fileLockAndUnLock;
        private readonly AppWatcherUc _appWatcherUc1;

        private readonly test _test;
        public MainForm(FileLockAndUnLock fileLockAndUnLock, AppWatcherUc appWatcherUc1, IOptions<test> test)
        {
            _test = test.Value;
            _fileLockAndUnLock = fileLockAndUnLock;
            _appWatcherUc1 = appWatcherUc1;
            InitializeComponent();
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
