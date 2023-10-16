namespace WinFormsWebDav.Modes.Dto.Response.Document
{
    public class GetFolderSubItemsResponse
    {
        //public GetFolderResponse? CurrentFolder;

        public GetFolderResponse[] folders;

        //public IList<GetFileResponse>? Files;
    }

    public class GetFolderResponse
    {
        public string id { get; set; }
        public string projectId { get; set; }
        public string name { get; set; }
        public string fullPath { get; set; }
        public string parentId { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public object projectResponse { get; set; }
    }

    public class GetFileResponse : GetFolderResponse
    {
        public long ContentLength { get; set; }

        public long LatestVersion { get; set; }

        public bool IsLocked { get; set; }
    }

    public class GetFileVersionsResponse : GetFileResponse
    {
        public List<GetFileVersionResponse>? FileVersions { get; set; }
    }
}
