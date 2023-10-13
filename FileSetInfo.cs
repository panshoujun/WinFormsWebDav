using WinFormsWebDav.Base;
using WinFormsWebDav.Modes.Options;

namespace WinFormsWebDav
{
    public partial class FileSetInfo : BaseUserControl
    {
        public FileSetInfo()
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
            //base.ShowMessage(msg);
            rtbLog.Text += msg;
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

                throw;
            }

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
