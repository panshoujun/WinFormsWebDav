namespace WinFormsWebDav.Modes.Dto.Response.Document
{
    public class GetFileVersionResponse
    {
        public Guid Id { get; set; }

        public long Version { get; set; }

        public long ContentLength { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Token { get; set; }
    }
}
