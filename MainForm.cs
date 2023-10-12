using Microsoft.Extensions.Options;
using System.Windows.Forms;
using WinFormsWebDav.Modes.Options;

namespace WinFormsWebDav
{
    public partial class MainForm : Form
    {
        private readonly FileLockAndUnLock _fileLockAndUnLock;

        private readonly test _test;
        public MainForm(FileLockAndUnLock fileLockAndUnLock, IOptions<test> test)
        {
            _test = test.Value;
            _fileLockAndUnLock = fileLockAndUnLock;
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
