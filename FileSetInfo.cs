namespace WinFormsWebDav
{
    public partial class FileSetInfo : UserControl
    {
        public FileSetInfo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 设置为只读
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetReadOnly_Click(object sender, EventArgs e)
        {
            var filePath = btReadOnlyFile.Text;
            File.SetAttributes(filePath, FileAttributes.ReadOnly);
        }

        /// <summary>
        /// 取消只读
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelReadOnly_Click(object sender, EventArgs e)
        {
            var filePath = btReadOnlyFile.Text;
            File.SetAttributes(filePath, FileAttributes.Normal);
        }
    }
}
