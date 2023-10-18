using Refit;
using System.IO;
using WinFormsWebDav.Modes.Dto.Base;
using WinFormsWebDav.Modes.Dto.Response.Document;
using WinFormsWebDav.Modes.Temp;

namespace WinFormsWebDav.Services.Api
{
    public interface IDocumentApi
    {
        [Get("/api/document/project/{projectId}/{path}")]
        Task<ApiResult<GetFolderSubItemsResponse>> GetFolderSubItemsOld(Guid projectId, string path);

        [Get("/api/document/project/{projectId}/{**path}")]
        Task<Rootobject> GetFolderSubItems(Guid projectId, string path);


        [Get("/api/document/file/download")]
        Task<HttpResponseMessage> DownloadFile(string projectName, string path);

        [Delete("/api/document/project/{projectId}/file/{path}")]
        Task<HttpResponseMessage> DeleteFile(Guid projectId, string path);
    }
}
