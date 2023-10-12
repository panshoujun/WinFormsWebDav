using System.Runtime.InteropServices;

namespace WinFormsWebDav.Utils
{
    public class FileUtils
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr FindFirstChangeNotification(string lpPathName, bool bWatchSubtree, int dwNotifyFilter);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool FindNextChangeNotification(IntPtr hChangeHandle);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool FindCloseChangeNotification(IntPtr hChangeHandle);

        [DllImport("kernel32.dll")]
        private static extern uint WaitForSingleObject(IntPtr hHandle, uint dwMilliseconds);

        private const int INVALID_HANDLE_VALUE = -1;
        private const uint INFINITE = 0xFFFFFFFF;

        public static bool IsFileOpen(string filePath)
        {
            try
            {
                using (FileStream fs = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    return false;
                }
            }
            catch (IOException)
            {
                return true;
            }
        }
    }


    public class FileUtilsNew
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr _lopen(string lpPathName, int iReadWrite);
        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(IntPtr hObject);
        public const int OF_READWRITE = 2;
        public const int OF_SHARE_DENY_NONE = 0x40;
        public static readonly IntPtr HFILE_ERROR = new IntPtr(-1);
        public static bool IsFileOpen(string vFileName = @"C:\watchtest\123.txt")
        {

            if (!File.Exists(vFileName))
            {
                //MessageBox.Show("文件都不存在，你就不要拿来耍了");
                return false;
            }
            IntPtr vHandle = _lopen(vFileName, OF_READWRITE | OF_SHARE_DENY_NONE);
            if (vHandle == HFILE_ERROR)
            {
                //MessageBox.Show("文件被占用！");
                return true;
            }
            CloseHandle(vHandle);
            //MessageBox.Show("没有被占用！");
            return false;
        }
    }
}
