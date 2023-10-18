using System.Net;

namespace WinFormsWebDav.Modes.Dto.Response
{
    public class DeleteAllFileResponse
    {
        public int Total { get; set; }

        public int SuccessCount { get { return FileResult.Count(p => p.Item2 == (int)HttpStatusCode.OK); } }

        public int FailCount { get { return FileResult.Count(p => p.Item2 != (int)HttpStatusCode.OK); } }

        public List<(string, int)> FileResult { get; set; } = new List<(string, int)>();
    }
}
