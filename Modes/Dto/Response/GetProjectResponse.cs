namespace WinFormsWebDav.Modes.Dto.Response
{
    public class GetProjectResponse
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public int Priority { get; set; }

        public string? CurrentStatus { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool HasIcon { get; set; }
    }
}
