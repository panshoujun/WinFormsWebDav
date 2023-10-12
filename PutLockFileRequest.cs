namespace WinFormsWebDav
{
    public class PutLockFileRequest
    {
        public long TimeoutSeconds { get; set; }

        public bool ForceChangeLock { get; set; }
    }
}
