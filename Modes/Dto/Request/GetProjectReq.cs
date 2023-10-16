namespace WinFormsWebDav.Modes.Dto.Request
{
    public class GetProjectReq
    {
        public string name { get; set; }
        public string status { get; set; }

        public int page { get; set; } = 1;
    }
}
