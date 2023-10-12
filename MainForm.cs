using Microsoft.Extensions.Options;
using WinFormsWebDav.Modes.Options;

namespace WinFormsWebDav
{
    public partial class MainForm : Form
    {
        private readonly test _test;
        public MainForm(IOptions<test> test)
        {
            InitializeComponent();
            _test = test.Value;
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
