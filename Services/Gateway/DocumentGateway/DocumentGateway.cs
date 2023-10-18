﻿using WinFormsWebDav.Modes.Dto.Base;
using WinFormsWebDav.Modes.Dto.Response.Document;
using WinFormsWebDav.Modes.Temp;
using WinFormsWebDav.Services.Api;
using WinFormsWebDav.Services.Gateway.ProjectGW;

namespace WinFormsWebDav.Services.Gateway.DocumentGateway
{
    public class DocumentGateway : IDocumentGateway
    {
        private IDocumentApi _documentApi;

        public DocumentGateway(IDocumentApi documentApi)
        {
            _documentApi = documentApi;
        }

        public async Task<ApiResult<GetFolderSubItemsResponse>> GetFolderSubItemsOld(Guid projectId, string path)
        {
            try
            {
                return await _documentApi.GetFolderSubItemsOld(projectId, path);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Rootobject> GetFolderSubItems(Guid projectId, string path)
        {
            try
            {
                return await _documentApi.GetFolderSubItems(projectId, path);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<HttpResponseMessage> DownloadFile(string projectName, string path)
        {
            return await _documentApi.DownloadFile(projectName, path);
        }

        public async Task<HttpResponseMessage> DeleteFile(Guid projectId, string path)
        {
            return await _documentApi.DeleteFile(projectId, path);
        }
    }
}
