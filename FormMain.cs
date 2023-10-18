using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net;
using WinFormsWebDav.Enums;
using WinFormsWebDav.Modes;
using WinFormsWebDav.Modes.Dto.Base;
using WinFormsWebDav.Modes.Dto.Response;
using WinFormsWebDav.Modes.Options;
using WinFormsWebDav.Services.Gateway.DocumentGateway;
using WinFormsWebDav.Services.Gateway.ProjectGW;

namespace WinFormsWebDav
{
    public partial class FormMain : Form
    {
        public delegate void setStatusDelegate(string requestInfo);

        //组件
        private readonly FileLockAndUnLockUc _fileLockAndUnLock;
        private readonly AppWatcherUc _appWatcherUc1;
        private readonly MicroSoftMessageQueuingUc _microSoftMessageQueuingUc1;
        private readonly WebDavUc _webdav;

        //参数
        private readonly test _test;
        private readonly SystemOptions _systemOptions;
        private readonly FileCheckOptions _fileCheckOptions;

        //gw
        private readonly IProjectGW _projectGW;
        private readonly IDocumentGateway _documentGateway;


        public FormMain(FileLockAndUnLockUc fileLockAndUnLock, AppWatcherUc appWatcherUc1, MicroSoftMessageQueuingUc microSoftMessageQueuingUc1, WebDavUc webdav,
            IProjectGW projectGW, IDocumentGateway documentGateway,
            IOptions<test> test, IOptions<SystemOptions> systemOptions, IOptions<FileCheckOptions> fileCheckOptions)
        {
            _projectGW = projectGW;
            _documentGateway = documentGateway;

            _test = test.Value;
            _systemOptions = systemOptions.Value;
            _fileCheckOptions = fileCheckOptions.Value;

            _fileLockAndUnLock = fileLockAndUnLock;
            _appWatcherUc1 = appWatcherUc1;
            _microSoftMessageQueuingUc1 = microSoftMessageQueuingUc1;
            _webdav = webdav;
            InitializeComponent();


            tvFiles.CheckBoxes = true;

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
        /// 展示消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowMessage(object sender, EventArgs e)
        {
            // 修改其他控件的值
            rtbLog.Text += ((MessageEventArgs)e).Msg;
        }

        /// <summary>
        /// 设置btn
        /// </summary>
        /// <param name="IsEnabled"></param>
        private void SetBtnEnabled(bool IsEnabled)
        {
            btnInitTree.Enabled = IsEnabled;
            btnCheckFile.Enabled = IsEnabled;
            btnDeleteFile.Enabled = IsEnabled;
        }

        /// <summary>
        /// 清除日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            rtbLog.Text = string.Empty;

            DownloadFileAsRefit("bugtest", "1112.txt");
        }

        /// <summary>
        /// 文件检查
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnCheckFile_Click(object sender, EventArgs e)
        {
            SetBtnEnabled(false);

            var projects = await GetAllProject();
            var files = await GetAllFile(projects);

            tbAllFileCount.Text = files.Count.ToString();

            var resp = await CheckFiles(files);

            SaveToFile(resp, _fileCheckOptions.FilesCheckResultPath);

            //ShowMessage(null, new MessageEventArgs { Msg = $"检测文件结果:{JsonConvert.SerializeObject(resp, Formatting.Indented)}\n" });

            SetBtnEnabled(true);
            MessageBox.Show("所有文件检测完成");
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnDeleteFile_Click(object sender, EventArgs e)
        {
            SetBtnEnabled(false);
            CheckAllFileResponse checkAllFile = new CheckAllFileResponse();
            DeleteAllFileResponse deleteAllFile = new DeleteAllFileResponse();
            if (File.Exists(_fileCheckOptions.FilesCheckResultPath))
            {
                string jsonString = await File.ReadAllTextAsync(_fileCheckOptions.FilesCheckResultPath);
                checkAllFile = JsonConvert.DeserializeObject<CheckAllFileResponse>(jsonString);
            }
            else
            {
                MessageBox.Show("请先检查文件");
            }

            for (int i = 0; i < 5; i++)//checkAllFile.FailFilePath.Count
            {
                var split = checkAllFile.FailFilePath[i].Split("/");
                var path = string.Join("/", split.Skip(1));
                var result = await DeleteFileAsRefit(split[0], path);
                if (result != null)
                {
                    deleteAllFile.Total++;
                    deleteAllFile.FileResult.Add((checkAllFile.FailFilePath[i], (int)result.StatusCode));
                }
            }

            SaveToFile(deleteAllFile, _fileCheckOptions.FilesDeleteResultPath);
            SetBtnEnabled(true);
            ShowMessage(null, new MessageEventArgs { Msg = $"删除文件结果:{JsonConvert.SerializeObject(deleteAllFile, Formatting.Indented)}\n" });
        }

        /// <summary>
        /// 初始化tree
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnInitTree_ClickNew(object sender, EventArgs e)
        {
            SetBtnEnabled(false);

            tvFiles.Nodes.Clear();
            this.btnInitTree.Enabled = false;

            var projects = await GetAllProject();
            var files = await GetAllFile(projects);

            ShowMessage(null, new MessageEventArgs { Msg = $"共获取文件:{files.Count.ToString()}\n" });

            InitTree(files);

            SetNodeCount(tvFiles.Nodes[0], files, true);

            SetBtnEnabled(true);
        }

        /// <summary>
        /// 获取所有项目
        /// </summary>
        /// <returns></returns>
        private async Task<List<GetProjectResponse>> GetAllProject()
        {
            if (File.Exists(_fileCheckOptions.ProjectsPath))
            {
                string jsonString = await File.ReadAllTextAsync(_fileCheckOptions.ProjectsPath);
                return JsonConvert.DeserializeObject<List<GetProjectResponse>>(jsonString);
            }

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

            SaveToFile(allProjects, _fileCheckOptions.ProjectsPath);
            return allProjects;
        }

        /// <summary>
        /// 获取所有文件
        /// </summary>
        /// <param name="projects"></param>
        /// <returns></returns>
        private async Task<List<Modes.Temp.File>> GetAllFile(List<GetProjectResponse> projects)
        {
            var files = new List<Modes.Temp.File>();

            if (File.Exists(_fileCheckOptions.FilesPath))
            {
                string jsonString = await File.ReadAllTextAsync(_fileCheckOptions.FilesPath);
                files = JsonConvert.DeserializeObject<List<Modes.Temp.File>>(jsonString);
                files?.ForEach(f =>
                {
                    f.projectName = projects?.Where(p => p.Id.ToString().Equals(f.projectId))?.FirstOrDefault()?.Name;
                });
                return files;
            }

            for (int i = 0; i < projects?.Count(); i++)
            {
                await GetPathFiles(projects[i], files, "tree");
            }

            files.ForEach(f => f.projectName = projects.Where(p => p.Id.ToString().Equals(f.projectId)).FirstOrDefault().Name);

            SaveToFile(files, _fileCheckOptions.FilesPath);

            return files;
        }

        /// <summary>
        /// 获取文件
        /// </summary>
        /// <param name="project"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public async Task GetPathFiles(GetProjectResponse project, List<Modes.Temp.File> files, string path = "tree")
        {
            var result = await _documentGateway.GetFolderSubItems(project.Id, path);

            if (result?.data?.files.Count > 0)
            {
                files.AddRange(result.data.files);
            }

            for (int i = 0; i < result?.data?.folders?.Count; i++)
            {
                await GetPathFiles(project, files, $"{path}/{result?.data?.folders[i].name}");
            }
        }

        #region 文件下载
        /// <summary>
        /// 文件下载(WebClient)
        /// </summary>
        private void DownloadFileAsWebClient()
        {
            string url = "http://qatest007.cscloud.cscad.net:6003/api/document/file/download?path=1112.txt&projectName=bugtest";
            string savaPath = $"C:\\bugtest\\1112.txt";
            using (var webClient = new WebClient())
            {
                webClient.Headers.Add("Authorization", "Token cst_Ju490XH68A5dOXRFY71JiJHzQmZyHzAWwk7aaEmzESbdu5vNDYGE8KnuUrkB");
                Uri urlValue = new Uri(url);
                webClient.DownloadFileAsync(urlValue, savaPath);
            }
        }

        /// <summary>
        /// 文件下载(WebRequest)
        /// </summary>
        private void DownloadFileAsWebClientAsWebRequest()
        {
            string url = "http://qatest007.cscloud.cscad.net:6003/api/document/file/download?path=1112.txt&projectName=bugtest";
            string savePath = $"C:\\bugtest\\1112.txt";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.Headers.Add("Authorization", "Token cst_Ju490XH68A5dOXRFY71JiJHzQmZyHzAWwk7aaEmzESbdu5vNDYGE8KnuUrkB");
            request.Timeout = 10000;
            request.UserAgent = "WinformDownloader";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream stream = response.GetResponseStream();

            //progressBar1.Minimum = 0;
            //progressBar1.Maximum = (int)response.ContentLength;
            //progressBar1.Value = 0;

            FileStream fileStream = new FileStream(savePath, FileMode.Create);

            int length = 0;
            byte[] buffer = new byte[1024];
            while ((length = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                fileStream.Write(buffer, 0, length);
                //progressBar1.Value += length;
            }

            fileStream.Close();
            stream.Close();
            response.Close();
        }

        /// <summary>
        /// 文件下载(HttpClient)
        /// </summary>
        private async void DownloadFileAsHttpClient()
        {
            string savePath = $"C:\\bugtest\\1112.txt";
            using (HttpClient http = new HttpClient())
            {
                http.DefaultRequestHeaders.Add("Authorization", "Token cst_Ju490XH68A5dOXRFY71JiJHzQmZyHzAWwk7aaEmzESbdu5vNDYGE8KnuUrkB");
                var httpResponseMessage = await http.GetAsync("http://qatest007.cscloud.cscad.net:6003/api/document/file/download?path=111.txt.txt&projectName=tjPeoject", HttpCompletionOption.ResponseHeadersRead);//发送请求
                var contentLength = httpResponseMessage.Content.Headers.ContentLength;//读取文件大小
                using (var stream = await httpResponseMessage.Content.ReadAsStreamAsync())//读取文件流
                {
                    var readLength = 1024000;//1000K  每次读取大小
                    byte[] bytes = new byte[readLength];
                    int writeLength;
                    while ((writeLength = stream.Read(bytes, 0, readLength)) > 0)//分块读取文件流
                    {
                        using (FileStream fs = new FileStream(savePath, FileMode.Append, FileAccess.Write))//使用追加方式打开一个文件流
                        {
                            fs.Write(bytes, 0, writeLength);//追加写入文件
                            contentLength -= writeLength;
                            if (contentLength == 0)//如果写入完成 给出提示
                                MessageBox.Show("下载完成");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 文件下载(Refit)
        /// </summary>
        private async Task<Tuple<bool, string>> DownloadFileAsRefit(string project, string path)
        {
            //var result = await _documentGateway.DownloadFile("bugtest", "1112.txt");
            string msg = string.Empty;
            try
            {
                var result = await _documentGateway.DownloadFile(project, path);
                if (result != null && result.IsSuccessStatusCode && result.StatusCode == HttpStatusCode.OK)
                {
                    return new Tuple<bool, string>(true, msg);
                }
                else
                {
                    msg = await result.Content.ReadAsStringAsync();
                    return new Tuple<bool, string>(false, msg);
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return new Tuple<bool, string>(true, msg);
            }

        }
        #endregion

        /// <summary>
        /// 文件删除
        /// </summary>
        /// <param name="project"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        private async Task<HttpResponseMessage> DeleteFileAsRefit(string project, string path)
        {
            //var result = await _documentGateway.DownloadFile("bugtest", "1112.txt");
            string msg = string.Empty;
            try
            {
                var result = await _documentGateway.DeleteFile(Guid.Parse(project), path);
                return result;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return null;
            }

        }

        /// <summary>
        /// 设置节点文件数量
        /// </summary>
        /// <param name="node"></param>
        /// <param name="projects"></param>
        /// <param name="files"></param>
        /// <param name="sum"></param>
        private void SetNodeCount(TreeNode node, List<Modes.Temp.File> files, bool IsSet = false)
        {
            int sum = 0;
            foreach (TreeNode item in node.Nodes)
            {
                var tag = item.Tag.ToString();
                if (tag.Equals(NodeTypeEnums.File.ToString()))
                    continue;

                var count = GetFileCount(files, item);
                sum += count;

                item.Text = $"{item.Text}({count})";
                SetNodeCount(item, files);
            }

            if (IsSet)
            {
                node.Text = $"{node.Text}({sum})";
            }
        }

        /// <summary>
        /// 获取节点文件数量
        /// </summary>
        /// <param name="projects"></param>
        /// <param name="files"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        private int GetFileCount(List<Modes.Temp.File> files, TreeNode item)
        {
            var count = 0;

            foreach (var file in files)
            {
                if (file.projectId != item.ToolTipText)
                {
                    continue;
                }

                var split = file.fullPath.Split('/').SkipLast(1);
                var path = $"{_fileCheckOptions.RootNodePath}/{file.projectName}";
                if (split.Any())
                {
                    path += "/";
                    path += string.Join($"/", split);
                }

                if (path.Contains(item.Name))
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// 初始化tree
        /// </summary>
        /// <param name=""></param>
        /// <param name="files"></param>
        private void InitTree(List<Modes.Temp.File> files)
        {
            tvFiles.Nodes.Add(new TreeNode() { Text = _fileCheckOptions.RootNodeText, Name = _fileCheckOptions.RootNodePath, Tag = _fileCheckOptions.RootNodePath });

            for (int i = 0; i < files.Count; i++)
            {
                var nodePath = _fileCheckOptions.RootNodePath;
                var pathItems = $"{files[i].projectName}/{files[i].fullPath}".Split("/");

                for (int j = 0; j < pathItems.Length - 1; j++)
                {
                    nodePath += $"/{pathItems[j]}";

                    var node = tvFiles.Nodes.Find(nodePath, true).FirstOrDefault();
                    if (node == null)
                    {
                        var partent = tvFiles.Nodes.Find(nodePath.Substring(0, nodePath.Length - pathItems[j].Length - 1), true).FirstOrDefault();
                        partent?.Nodes.Add(new TreeNode { Text = $"{pathItems[j]}", Tag = nodePath, Name = nodePath, ToolTipText = files[i].projectId });
                    }
                }

                var filePartent = tvFiles.Nodes.Find(nodePath, true).FirstOrDefault();
                var nodeTxt = $"{pathItems[pathItems.Length - 1]}";
                filePartent?.Nodes.Add(new TreeNode { Text = nodeTxt, Tag = NodeTypeEnums.File.ToString(), Name = $"{nodePath}{nodeTxt}" });
            }

        }

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="filePath"></param>
        private void SaveToFile(object obj, string filePath)
        {
            var json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            //判断Json字符串内容是否为空
            if (!string.IsNullOrEmpty(json))
            {
                File.WriteAllText(filePath, json);
            }
        }

        /// <summary>
        /// 检查文件是否可以下载
        /// </summary>
        /// <param name="projects"></param>
        /// <param name="files"></param>
        /// <returns></returns>
        private async Task<CheckAllFileResponse> CheckFiles(List<Modes.Temp.File> files)
        {
            CheckAllFileResponse resp = new CheckAllFileResponse();

            resp.Total = files.Count;

            for (int i = 0; i < files.Count; i++)
            {
                var result = await DownloadFileAsRefit(files[i].projectName, files[i].fullPath);
                if (result.Item1)
                {
                    resp.SuccessFilePath.Add($"{files[i].projectId}/{files[i].fullPath}");
                    ShowMessage(null, new MessageEventArgs { Msg = $"{files[i].projectId}/{files[i].fullPath}可以下载\n" });
                    File.AppendAllText(_fileCheckOptions.CanDownloadFilePath, $"{files[i].projectId}/{files[i].fullPath}\n");
                    resp.SuccessCount++;
                    tbCanDown.Text = resp.SuccessCount.ToString();
                }
                else
                {
                    resp.FailFilePath.Add($"{files[i].projectId}/{files[i].fullPath}");
                    ShowMessage(null, new MessageEventArgs { Msg = $"{files[i].projectId}/{files[i].fullPath}文件无法下载\n" });
                    File.AppendAllText(_fileCheckOptions.CanNotDownloadFilePath, $"{files[i].projectId}/{files[i].fullPath}\n");
                    resp.FailCount++;
                    tbCanNotDown.Text = resp.FailCount.ToString();
                }
                tbResidue.Text = (resp.Total - resp.FailCount - resp.SuccessCount).ToString();
            }
            return resp;
        }

        #region  弃用
        /// <summary>
        /// 初始化tree
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnInitTree_Click(object sender, EventArgs e)
        {
            tvFiles.Nodes.Clear();
            this.btnInitTree.Enabled = false;

            var projects = await GetAllProject();
            var files = await GetAllFile(projects);


            TreeNode rootNode = new TreeNode("根节点");
            tvFiles.Nodes.Add(rootNode);
            for (int i = 0; i < projects.Count; i++)
            {
                TreeNode treeNode = new TreeNode(projects[i].Name);
                treeNode.Tag = projects[i].Id.ToString();
                treeNode.Name = projects[i].Id.ToString();
                rootNode.Nodes.Add(treeNode);
            }

            ShowMessage(null, new MessageEventArgs { Msg = $"共获取文件:{files.Count.ToString()}\n" });
            files.ForEach(async i =>
            {
                //ShowMessage(null, new MessageEventArgs { Msg = $"{i.fullPath}\n" });

                var pathItems = i.fullPath.Split("/");
                if (pathItems.Length == 1)
                {
                    var node = tvFiles.Nodes.Find(i.projectId, true).FirstOrDefault();
                    if (node != null)
                    {
                        var result = await DownloadFileAsRefit(projects.Where(p => p.Id.ToString().Equals(i.projectId)).FirstOrDefault().Name, i.fullPath);
                        node.Nodes.Add(new TreeNode { Text = $"{i.name}", Checked = result.Item1 });
                        if (result.Item1)
                        {
                            ShowMessage(null, new MessageEventArgs { Msg = $"{i.fullPath}文件无法下载:{result.Item2}\n" });
                        }
                    }
                }
                else
                {
                    var nodePath = $"{i.projectId}";
                    for (int j = 0; j < pathItems.Length - 1; j++)
                    {
                        nodePath += $"/{pathItems[j]}";
                        var next = tvFiles.Nodes.Find(nodePath, true).FirstOrDefault();
                        if (next == null)
                        {
                            var partent = tvFiles.Nodes.Find(nodePath.Substring(0, nodePath.Length - pathItems[j].Length - 1), true).FirstOrDefault();
                            if (partent != null)
                            {
                                partent.Nodes.Add(new TreeNode { Text = $"{pathItems[j]}", Tag = nodePath, Name = nodePath });
                            }
                            else
                            {
                                MessageBox.Show($"aaa{nodePath}");
                            }
                        }
                    }

                    var nextLastPartent = tvFiles.Nodes.Find(nodePath, true).FirstOrDefault();
                    if (nextLastPartent != null)
                    {
                        var result = await DownloadFileAsRefit(projects.Where(p => p.Id.ToString().Equals(i.projectId)).FirstOrDefault().Name, i.fullPath);
                        nextLastPartent.Nodes.Add(new TreeNode { Text = $"{pathItems[pathItems.Length - 1]}", Tag = nodePath += $"/{pathItems[pathItems.Length - 1]}", Name = nodePath += $"/{pathItems[pathItems.Length - 1]}", Checked = result.Item1 });
                        if (result.Item1)
                        {
                            ShowMessage(null, new MessageEventArgs { Msg = $"{i.fullPath}文件无法下载:{result.Item2}\n" });
                        }
                    }
                    else
                    {
                        MessageBox.Show($"bbb{nodePath}");
                    }

                }

            });
            this.btnInitTree.Enabled = true;
        }
        #endregion
    }

}

