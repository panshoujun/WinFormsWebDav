using System.Diagnostics;

namespace WinFormsWebDav
{
    public static class ProcessMonitor
    {
        public static event EventHandler ProcessClosed;

        public static void MonitorForExit(Process process)
        {
            Thread thread = new(() =>
            {
                process.WaitForExit();
                OnProcessClosed(EventArgs.Empty);
            });
            thread.Start();
        }

        private static void OnProcessClosed(EventArgs e)
        {
            if (ProcessClosed != null)
            {
                ProcessClosed(null, e);
            }
        }
    }
}
