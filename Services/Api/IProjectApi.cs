using Refit;
using WinFormsWebDav.Modes.Dto.Base;
using WinFormsWebDav.Modes.Dto.Request;
using WinFormsWebDav.Modes.Dto.Response;

namespace WinFormsWebDav.Services.Api
{
    public interface IProjectApi
    {
        [Get("/api/project/project")]
        Task<PagedApiResult<GetProjectResponse>> GetProjectAsync(string name, string status, int page = 1);

        [Get("/api/project/project")]
        Task<PagedApiResult<GetProjectResponse>> GetProjectNewAsync(GetProjectReq req);
    }
}
