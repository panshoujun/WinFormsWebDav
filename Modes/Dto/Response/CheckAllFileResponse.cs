namespace WinFormsWebDav.Modes.Dto.Response
{
    /// <summary>
    /// 
    /// </summary>
    public class CheckAllFileResponse
    {
        public int Total { get; set; }

        public int SuccessCount { get { return SuccessFilePath.Count; } }

        public int FailCount { get { return FailFilePath.Count; } }

        public List<string> SuccessFilePath { get; set; } = new List<string>();

        public List<string> FailFilePath { get; set; } = new List<string>();
    }
}
