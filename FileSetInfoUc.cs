using WinFormsWebDav.Base;

namespace WinFormsWebDav
{
    public partial class FileSetInfoUc : BaseUserControl
    {
        public FileSetInfoUc()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        protected override void InitData()
        {

        }

        /// <summary>
        /// 显示消息
        /// </summary>
        /// <param name="msg"></param>
        protected override void ShowMessage(string msg)
        {
            if (MainForm.staticSystemOptions.IsShowMessageBox)
                MessageBox.Show(msg);

            if (MainForm.staticSystemOptions.IsWriteLog)
                rtbLog.Text += $"{msg}\n";
        }

        /// <summary>
        /// 设置为只读
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetReadOnly_Click(object sender, EventArgs e)
        {
            try
            {
                var filePath = btReadOnlyFile.Text;
                File.SetAttributes(filePath, FileAttributes.ReadOnly);
            }
            catch (Exception ex)
            {

                ShowMessage(ex.Message);
            }

        }

        /// <summary>
        /// 取消只读
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelReadOnly_Click(object sender, EventArgs e)
        {
            try
            {
                var filePath = btReadOnlyFile.Text;
                File.SetAttributes(filePath, FileAttributes.Normal);
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }
    }
}
