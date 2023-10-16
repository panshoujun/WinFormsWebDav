using Microsoft.Extensions.Options;
using System.Net;
using WinFormsWebDav.Modes;
using WinFormsWebDav.Modes.Dto.Response;
using WinFormsWebDav.Modes.Options;
using WinFormsWebDav.Services.Gateway.DocumentGateway;
using WinFormsWebDav.Services.Gateway.ProjectGW;

namespace WinFormsWebDav
{
    public partial class FormMain : Form
    {
        public delegate void setStatusDelegate(string requestInfo);

        public static SystemOptions staticSystemOptions = new SystemOptions();

        //组件
        private readonly FileLockAndUnLockUc _fileLockAndUnLock;
        private readonly AppWatcherUc _appWatcherUc1;
        private readonly MicroSoftMessageQueuingUc _microSoftMessageQueuingUc1;
        private readonly WebDavUc _webdav;

        //参数
        private readonly test _test;
        private readonly SystemOptions _systemOptions;

        //
        private readonly IProjectGW _projectGW;
        private readonly IDocumentGateway _documentGateway;


        public FormMain(FileLockAndUnLockUc fileLockAndUnLock, AppWatcherUc appWatcherUc1, MicroSoftMessageQueuingUc microSoftMessageQueuingUc1, WebDavUc webdav,
            IProjectGW projectGW, IDocumentGateway documentGateway,
            IOptions<test> test, IOptions<SystemOptions> systemOptions)
        {
            _projectGW = projectGW;
            _documentGateway = documentGateway;

            _test = test.Value;
            _systemOptions = systemOptions.Value;
            _fileLockAndUnLock = fileLockAndUnLock;
            _appWatcherUc1 = appWatcherUc1;
            _microSoftMessageQueuingUc1 = microSoftMessageQueuingUc1;
            _webdav = webdav;
            InitializeComponent();


            tbWebdav.Controls.Add(_webdav);
            tbWebdav.Location = new Point(4, 33);
            tbWebdav.Name = "Webdav";
            tbWebdav.Padding = new Padding(3);
            tbWebdav.Size = new Size(1382, 653);
            tbWebdav.TabIndex = 0;
            tbWebdav.Text = "WebDav";
            tbWebdav.UseVisualStyleBackColor = true;

            // 
            // webDav1
            // 
            _webdav.Location = new Point(42, 15);
            _webdav.Name = "webDav";
            _webdav.Size = new Size(650, 550);
            _webdav.TabIndex = 0;

            //InitData();

            _webdav.SomeEvent += ShowMessage;
        }

        /// <summary>
        /// 清除日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            rtbLog.Text = string.Empty;
        }

        private void ShowMessage(object sender, EventArgs e)
        {
            // 修改其他控件的值
            rtbLog.Text += ((MessageEventArgs)e).Msg;
        }

        private async void btnCheckAllFile_ClickAsync(object sender, EventArgs e)
        {
            var files = new List<Modes.Temp.File>();
            var projectList = await GetAllProject();

            await GetPathFiles(projectList.FirstOrDefault(), files, "tree");

            files.ForEach(i =>
            {
                ShowMessage(null, new MessageEventArgs { Msg = $"{i.fullPath}\n" });
            });
        }

        //List<Modes.Temp.File> allFiles = new List<Modes.Temp.File>();

        /// <summary>
        /// 获取所有项目
        /// </summary>
        /// <returns></returns>
        public async Task<List<GetProjectResponse>> GetAllProject()
        {
            int page = 1;
            List<GetProjectResponse> allProjects = new List<GetProjectResponse>();

            while (true)
            {
                var projests = await _projectGW.GetProjectAsync(new Modes.Dto.Request.GetProjectReq { page = page });

                if (projests == null || projests.Code != (int)HttpStatusCode.OK)
                {
                    ShowMessage(null, new MessageEventArgs { Msg = $"{projests?.Message}\n" });
                    break;
                }

                allProjects.AddRange(projests.Data);

                if (page >= projests.TotalPages)
                {
                    break;
                }
                page++;
            }

            return allProjects;
        }

        /// <summary>
        /// 获取文件
        /// </summary>
        /// <param name="project"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public async Task GetPathFiles(GetProjectResponse project, List<Modes.Temp.File> files, string path = "tree")
        {
            try
            {
                var result = await _documentGateway.GetFolderSubItems(project.Id, path);

                if (result?.data?.files.Count > 0)
                {
                    files.AddRange(result.data.files);
                }

                result?.data?.folders.ForEach(async i =>
                {
                    await GetPathFiles(project, files, $"{path}/{i.name}");
                });
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
