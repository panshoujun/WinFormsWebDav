using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
using WinFormsWebDav.Constants;
using WinFormsWebDav.Modes;
using WinFormsWebDav.Utils;

namespace WinFormsWebDav
{
    public partial class FileWatchUcNew : UserControl
    {
        public event EventHandler ShowMessage;
        public FileWatchUcNew()
        {
            InitializeComponent();
        }

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

        public bool IsFileOpen(string filePath)
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

        private void btnFileWatch_Click(object sender, EventArgs e)
        {
            ShowMessage?.Invoke(this, new MessageEventArgs { Msg = $"开始监控:{tbFilePath.Text}\n" });

            Task.Run(() =>
            {
                while (true)
                {
                    if (!FileUtilsNew.IsFileOpen())
                    {
                        break;
                    }
                    Task.Delay(1000).Wait();
                }
                ShowMessage?.Invoke(this, new MessageEventArgs { Msg = $"文件已关闭\n" });
            });
        }

        private void btnFolderWatch_Click(object sender, EventArgs e)
        {
            ShowMessage?.Invoke(this, new MessageEventArgs { Msg = $"开始监控:{tbFolderPath.Text}\n" });

            StartWatch(tbFolderPath.Text, null);
        }

        private void btnFileWatch_ClickOld(object sender, EventArgs e)
        {
            //MessageBox.Show($"开始监控:{tbReadOnlyFile.Text}");
            //StartWatch(tbReadOnlyFile.Text, null);

            string filePath = "C:\\watchtest\\123.txt";

            //Task.Run(() =>
            //{
            //    while (true)
            //    {
            //        // 获取文件的句柄数
            //        int handleCount = GetHandleCount(filePath);

            //        if (handleCount == 0)
            //        {
            //            // 文件已关闭
            //            MessageBox.Show("文件已关闭");
            //            break;
            //        }
            //        else
            //        {
            //            // 文件仍然打开
            //        }

            //        Task.Delay(1000).Wait();
            //    }
            //});


            //Task.Run(() =>
            //{
            //    while (FileUtils.IsFileOpen(filePath))
            //    {
            //        Task.Delay(1000).Wait();
            //    }
            //    MessageBox.Show("文件已关闭");
            //});
            //FileUtils.IsFileOpen(filePath);


            Task.Run(() =>
            {
                while (true)
                {
                    if (!FileUtilsNew.IsFileOpen())
                    {
                        break;
                    }
                    Task.Delay(1000).Wait();
                }
                ShowMessage?.Invoke(this, new MessageEventArgs { Msg = $"文件已关闭\n" });
                //MessageBox.Show("文件已关闭");
            });
            FileUtilsNew.IsFileOpen();

        }

        public void StartWatch(string path, string filter)
        {
            FileSystemWatcher watcher = new FileSystemWatcher();

            watcher.Path = path;
            watcher.Filter = "*.*";   //设置监控文件的类型  "*.txt|*.doc|*.jpg";  
            watcher.IncludeSubdirectories = true;   //设置是否监控目录下的所有子目录
                                                    //watcher.Filter = filter;
                                                    //watcher.NotifyFilter = NotifyFilters.Size | NotifyFilters.LastWrite | NotifyFilters.FileName;   //设置文件的文件名、目录名及文件的大小改动会触发Changed事件  
            watcher.NotifyFilter = NotifyFilters.DirectoryName | NotifyFilters.FileName | NotifyFilters.LastWrite | NotifyFilters.CreationTime | NotifyFilters.LastAccess | NotifyFilters.Attributes | NotifyFilters.Size | NotifyFilters.Security;
            watcher.Changed += new FileSystemEventHandler(OnProcess);
            watcher.Created += new FileSystemEventHandler(OnProcess);
            watcher.Deleted += new FileSystemEventHandler(OnProcess);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);
            watcher.Error += new ErrorEventHandler(OnError);
            watcher.EnableRaisingEvents = true;
        }

        #region 监控事件

        private void OnProcess(object source, FileSystemEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Created)
            {
                OnCreated(source, e);

            }
            else if (e.ChangeType == WatcherChangeTypes.Changed)
            {
                OnChanged(source, e);

            }
            else if (e.ChangeType == WatcherChangeTypes.Deleted)
            {
                OnDeleted(source, e);

            }
            else
            {
                OnOther(source, e);
            }
        }

        private void OnCreated(object source, FileSystemEventArgs e)
        {

            ShowMessage?.Invoke(source, new MessageEventArgs { Msg = $"{e.FullPath} 新建\n" });

        }

        private void OnChanged(object source, FileSystemEventArgs e)
        {

            ShowMessage?.Invoke(source, new MessageEventArgs { Msg = $"{e.FullPath} 改变\n" });
        }

        private void OnDeleted(object source, FileSystemEventArgs e)
        {

            ShowMessage?.Invoke(source, new MessageEventArgs { Msg = $"{e.FullPath} 删除\n" });
        }

        private void OnRenamed(object source, RenamedEventArgs e)
        {

            ShowMessage?.Invoke(source, new MessageEventArgs { Msg = $"{e.FullPath} 重命名\n" });
        }
        private void OnOther(object source, FileSystemEventArgs e)
        {

            ShowMessage?.Invoke(source, new MessageEventArgs { Msg = $"{e.FullPath} 其他\n" });

        }
        private void OnError(object source, ErrorEventArgs e)
        {
            ShowMessage?.Invoke(source, new MessageEventArgs { Msg = $"{"错误" + e.GetException()}\n" });
        }

        #endregion

        private int GetHandleCount(string filePath)
        {
            try
            {
                using (FileStream fs = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite))
                {
                    SafeFileHandle handle = fs.SafeFileHandle;
                    return GetHandleCount(handle);
                }
            }
            catch
            {
                // 处理文件访问异常
                return -1;
            }
        }

        private int GetHandleCount(SafeFileHandle handle)
        {
            try
            {
                NativeMethods.FILE_HANDLE_BASIC_INFORMATION info;
                int result = NativeMethods.NtQueryInformationFile(handle.DangerousGetHandle(), out info, Marshal.SizeOf<NativeMethods.FILE_HANDLE_BASIC_INFORMATION>(), NativeMethods.FILE_INFORMATION_CLASS.FileBasicInformation);
                if (result != 0)
                {
                    return -1;
                }

                return (int)info.HandleCount;
            }
            catch
            {
                // 处理获取句柄数异常
                return -1;
            }
        }


        [DllImport("kernel32.dll")]
        public static extern IntPtr _lopen(string lpPathName, int iReadWrite);
        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(IntPtr hObject);
        public const int OF_READWRITE = 2;
        public const int OF_SHARE_DENY_NONE = 0x40;
        public readonly IntPtr HFILE_ERROR = new IntPtr(-1);
        private void button1_Click(object sender, EventArgs e)
        {
            string vFileName = "C:\\watchtest\\1.dwg";
            //if (!File.Exists(vFileName))
            //{
            //    MessageBox.Show("文件都不存在，你就不要拿来耍了");
            //    return;
            //}
            //IntPtr vHandle = _lopen(vFileName, OF_READWRITE | OF_SHARE_DENY_NONE);
            //if (vHandle == HFILE_ERROR)
            //{
            //    MessageBox.Show("文件被占用！");
            //    return;
            //}
            //CloseHandle(vHandle);
            //MessageBox.Show("没有被占用！");

            // 检查文件是否仍然打开
            bool isOpen = IsFileOpen(vFileName);
            if (!isOpen)
            {
                ShowMessage?.Invoke(sender, new MessageEventArgs { Msg = $"{MessageConstants.FILE_CLOSED}" });
            }
        }
    }

    internal static class NativeMethodsNew
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct FILE_HANDLE_BASIC_INFORMATION
        {
            public IntPtr HandleAttributes;
            public IntPtr HandleCount;
            public UInt64 PointerCount;
        }

        public enum FILE_INFORMATION_CLASS
        {
            FileBasicInformation = 4
        }

        [DllImport("ntdll.dll")]
        public static extern int NtQueryInformationFile(IntPtr FileHandle, out FILE_HANDLE_BASIC_INFORMATION FileInformation, int Length, FILE_INFORMATION_CLASS FileInformationClass);
    }


    //-------------------

}
