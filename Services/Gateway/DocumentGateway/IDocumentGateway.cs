using WinFormsWebDav.Modes.Dto.Base;
using WinFormsWebDav.Modes.Dto.Response.Document;
using WinFormsWebDav.Modes.Temp;

namespace WinFormsWebDav.Services.Gateway.DocumentGateway
{
    public interface IDocumentGateway
    {
        Task<ApiResult<GetFolderSubItemsResponse>> GetFolderSubItemsOld(Guid projectId, string path);

        Task<Rootobject> GetFolderSubItems(Guid projectId, string path);
    }
}
