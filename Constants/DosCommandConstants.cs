namespace WinFormsWebDav.Constants
{
    public class DosCommandConstants
    {
        /// <summary>
        /// 查看已使用盘符
        /// </summary>
        public const string GET_USED_DRIVE_LETTER = "net use";

        /// <summary>
        /// 挂载
        /// </summary>
        public const string MOUNT_WEBDAV = "net use * {0} /user:{1} {2}";

        /// <summary>
        /// 通过传入盘符挂载
        /// </summary>
        public const string MOUNT_WEBDAV_BY_DRIVE_LETTER = "net use {3}: {0} /user:{1} {2}";

        /// <summary>
        /// 解挂单个
        /// </summary>
        public const string UN_MOUNT_WEBDAV = "net use {0}: /del";

        /// <summary>
        /// 解挂所有
        /// </summary>
        public const string UN_MOUNT_ALL_WEBDAV = "net use * /del /y";
    }
}
