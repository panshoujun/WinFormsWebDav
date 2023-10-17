namespace WinFormsWebDav.Modes.Dto.Response
{
    /// <summary>
    /// 
    /// </summary>
    public class CheckAllFileResponse
    {
        public int Total { get; set; }

        public int SuccessCount { get; set; }

        public int FailCount { get; set; }

        public List<string> SuccessFilePath { get; set; } = new List<string>();

        public List<string> FailFilePath { get; set; } = new List<string>();
    }
}
