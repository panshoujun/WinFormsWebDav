namespace WinFormsWebDav.Constants
{
    public class DocumentApiRouteConstants
    {
        /// <summary>
        /// 锁定文件
        /// </summary>
        public const string LOCK_FILE = "/api/document/project/{0}/lock-file/{1}";

        /// <summary>
        /// 解锁文件
        /// </summary>
        public const string UNLOCK_FILE = "/api/document/project/{0}/unlock-file/{1}";
    }
}
