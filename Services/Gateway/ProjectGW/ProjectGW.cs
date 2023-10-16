using WinFormsWebDav.Modes.Dto.Base;
using WinFormsWebDav.Modes.Dto.Request;
using WinFormsWebDav.Modes.Dto.Response;
using WinFormsWebDav.Services.Api;

namespace WinFormsWebDav.Services.Gateway.ProjectGW
{
    public class ProjectGW : IProjectGW
    {
        private readonly IProjectApi _projectApi;

        public ProjectGW(IProjectApi projectApi)
        {
            _projectApi = projectApi;
        }

        public async Task<PagedApiResult<GetProjectResponse>> GetProjectAsync(string name, string status, int page = 1)
        {
            try
            {
                var result = await _projectApi.GetProjectAsync(name, status);
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        public async Task<PagedApiResult<GetProjectResponse>> GetProjectNewAsync(GetProjectReq req)
        {
            try
            {
                var result = await _projectApi.GetProjectNewAsync(req);
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
