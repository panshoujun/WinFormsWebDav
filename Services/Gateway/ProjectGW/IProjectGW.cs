using WinFormsWebDav.Modes.Dto.Base;
using WinFormsWebDav.Modes.Dto.Request;
using WinFormsWebDav.Modes.Dto.Response;

namespace WinFormsWebDav.Services.Gateway.ProjectGW
{
    public interface IProjectGW
    {
        Task<PagedApiResult<GetProjectResponse>> GetProjectAsync(string name, string status, int page = 1);

        Task<PagedApiResult<GetProjectResponse>> GetProjectNewAsync(GetProjectReq req);
    }
}
