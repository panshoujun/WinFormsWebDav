namespace WinFormsWebDav.Constants
{
    public class RegexPatternConstants
    {
        /// <summary>
        /// 查看已使用盘符正则表达式
        /// </summary>
        public const string GET_USED_DRIVE_LETTER = "\\s+(?<DiskDrive>[A-Z]):\\s+";

        /// <summary>
        /// 获取挂载驱动器正则表达式
        /// </summary>
        public const string GET_MOUNT_DISK_DRIVE = "驱动器.*(?<DiskDrive>[A-Z]):.*现在连接到";
    }
}
