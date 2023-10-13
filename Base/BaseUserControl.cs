namespace WinFormsWebDav.Base
{
    public class BaseUserControl : UserControl
    {
        /// <summary>
        /// 显示消息
        /// </summary>
        /// <param name="msg"></param>
        protected virtual void ShowMessage(string msg)
        {
            MessageBox.Show(msg);
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        protected virtual void InitData() { }
    }
}
