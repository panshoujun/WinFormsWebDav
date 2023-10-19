using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Drawing;
using System.Linq;
using System.Net;
using WinFormsWebDav.Constants;
using WinFormsWebDav.Enums;
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

        //组件
        private readonly FileLockAndUnLockUcNew _fileLockAndUnLock;
        private readonly AppWatcherUc _appWatcherUc1;
        private readonly MicroSoftMessageQueuingUcNew _microSoftMessageQueuingUc1;
        private readonly WebDavUc _webdav;

        //参数
        private readonly SystemOptions _systemOptions;
        private readonly FileCheckOptions _fileCheckOptions;

        //gw
        private readonly IProjectGW _projectGW;
        private readonly IDocumentGateway _documentGateway;


        public FormMain(FileLockAndUnLockUcNew fileLockAndUnLock, AppWatcherUc appWatcherUc1, MicroSoftMessageQueuingUcNew microSoftMessageQueuingUc1, WebDavUc webdav,
            IProjectGW projectGW, IDocumentGateway documentGateway,
            IOptions<SystemOptions> systemOptions, IOptions<FileCheckOptions> fileCheckOptions)
        {
            _projectGW = projectGW;
            _documentGateway = documentGateway;

            _systemOptions = systemOptions.Value;
            _fileCheckOptions = fileCheckOptions.Value;

            _fileLockAndUnLock = fileLockAndUnLock;
            _appWatcherUc1 = appWatcherUc1;
            _microSoftMessageQueuingUc1 = microSoftMessageQueuingUc1;
            _webdav = webdav;
            InitializeComponent();
            InitComponent();
            #region 选中联动 有问题
            tvFiles.MouseClick += treeView1_MouseClick;
            //tvFiles.AfterCheck += skinTreeView1_AfterCheck;
            //tvFiles.DrawMode = TreeViewDrawMode.OwnerDrawText;
            //tvFiles.DrawNode += ClassTreeList_DrawNode;
            #endregion

            tvFiles.CheckBoxes = true;
        }

        private void InitComponent()
        {
            //msmq
            tbMSMQ.Controls.Add(_microSoftMessageQueuingUc1);
            tbMSMQ.Location = new Point(4, 33);
            tbMSMQ.Name = "tabPage4";
            tbMSMQ.Padding = new Padding(3);
            tbMSMQ.Size = new Size(1382, 653);
            tbMSMQ.Text = "MSMQ";
            tbMSMQ.UseVisualStyleBackColor = true;
            _microSoftMessageQueuingUc1.ShowMessage += ShowMessage;

            //webdav
            tbWebdav.Controls.Add(_webdav);
            tbWebdav.Location = new Point(4, 33);
            tbWebdav.Name = "Webdav";
            tbWebdav.Padding = new Padding(3);
            tbWebdav.Size = new Size(1382, 653);
            tbWebdav.Text = "WebDav";
            tbWebdav.UseVisualStyleBackColor = true;
            _webdav.ShowMessage += ShowMessage;

            //fileSetInfo
            fileSetInfo.ShowMessage += ShowMessage;

            //FileLockAndUnLock
            tbFileLockAndUnLock.Controls.Add(_fileLockAndUnLock);
            tbFileLockAndUnLock.Location = new Point(4, 33);
            tbFileLockAndUnLock.Name = "FileLockAndUnLock";
            tbFileLockAndUnLock.Padding = new Padding(3);
            tbFileLockAndUnLock.Size = new Size(1382, 653);
            tbFileLockAndUnLock.Text = "FileLockAndUnLock";
            tbFileLockAndUnLock.UseVisualStyleBackColor = true;
            _fileLockAndUnLock.ShowMessage += ShowMessage;
        }


        /// <summary>
        /// 展示消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowMessage(object sender, EventArgs e)
        {
            var type = ((MessageEventArgs)e).MessageType;

            // 修改其他控件的值
            if (type == ShowMessageTypeEnums.All || type == ShowMessageTypeEnums.LogTxt)
            {
                rtbLog.Text += ((MessageEventArgs)e).Msg;
            }

            if (type == ShowMessageTypeEnums.All || type == ShowMessageTypeEnums.MessageBox)
            {
                MessageBox.Show(((MessageEventArgs)e).Msg);
            }
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

            CreateTree(files);

            var resp = await CheckFiles(files);

            SetNodeChecked(tvFiles.Nodes[0], resp, projects);

            SaveToFile(resp, _fileCheckOptions.FilesCheckResultPath);

            SetBtnEnabled(true);

            ShowMessage(null, new MessageEventArgs { Msg = MessageConstants.FILE_CHECKED });
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
                ShowMessage(null, new MessageEventArgs { Msg = MessageConstants.CHECK_FILE_FIRST, MessageType = ShowMessageTypeEnums.MessageBox });
                SetBtnEnabled(true);
                return;
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

            var projects = await GetAllProject();
            var files = await GetAllFile(projects);

            ShowMessage(null, new MessageEventArgs { Msg = $"共获取文件:{files.Count.ToString()}\n" });

            CreateTree(files);

            SetBtnEnabled(true);
        }

        private void CreateTree(List<Modes.Temp.File> files)
        {
            tvFiles.Nodes.Clear();
            InitTree(files);
            SetNodeCount(tvFiles.Nodes[0], files, true);
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
                                ShowMessage(null, new MessageEventArgs { Msg = MessageConstants.DOWNLOAD_COMPLETED, MessageType = ShowMessageTypeEnums.MessageBox });
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
            try
            {
                var result = await _documentGateway.DeleteFile(Guid.Parse(project), path);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        /// <summary>
        /// 设置node是否选中
        /// </summary>
        /// <param name="node"></param>
        /// <param name="checkAllFile"></param>
        /// <param name="projects"></param>
        private void SetNodeChecked(TreeNode node, CheckAllFileResponse checkAllFile, List<GetProjectResponse> projects)
        {
            foreach (TreeNode item in node.Nodes)
            {
                var tag = item.Tag.ToString();
                if (!tag.Equals(NodeTypeEnums.File.ToString()))
                {
                    SetNodeChecked(item, checkAllFile, projects);
                }

                var split = item.Name.Split("/").Skip(1).ToArray();
                split[0] = projects.Where(p => p.Name == split.FirstOrDefault()).FirstOrDefault().Id.ToString();
                if (checkAllFile.FailFilePath.Any(p => p.Equals(string.Join("/", split))))
                {
                    item.Checked = true;
                }
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
                node.Text = $"{node.Text}({sum})";

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
                if (file.projectName != item.Text)
                    continue;

                var split = file.fullPath.Split('/').SkipLast(1);
                var path = $"{_fileCheckOptions.RootNodePath}/{file.projectName}";
                if (split.Any())
                    path += $"/{string.Join($"/", split)}";

                if (path.Contains(item.Name))
                    count++;
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
                filePartent?.Nodes.Add(new TreeNode { Text = nodeTxt, Tag = NodeTypeEnums.File.ToString(), Name = $"{nodePath}/{nodeTxt}" });
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
                var path = string.Join("\\", filePath.Split("\\").SkipLast(1));
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

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

            if (File.Exists(_fileCheckOptions.FilesCheckResultPath))
            {
                string jsonString = await File.ReadAllTextAsync(_fileCheckOptions.FilesCheckResultPath);
                resp = JsonConvert.DeserializeObject<CheckAllFileResponse>(jsonString);
                return resp;
            }

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

        #region 选中联动有问题
        #region
        private void treeView1_MouseClick(object sender, MouseEventArgs e)
        {
            TreeNode node = tvFiles.GetNodeAt(new Point(e.X, e.Y));
            if (node != null)
            {
                ChangeChild(node, node.Checked);//影响子节点
                ChangeParent(node);//影响父节点
            }
        }

        //递归子节点跟随其全选或全不选
        private void ChangeChild(TreeNode node, bool state)
        {
            node.Checked = state;
            foreach (TreeNode tn in node.Nodes)
                ChangeChild(tn, state);
        }

        //递归父节点跟随其全选或全不选
        private void ChangeParent(TreeNode node)
        {
            if (node.Parent != null)
            {
                //兄弟节点被选中的个数
                int brotherNodeCheckedCount = 0;
                //遍历该节点的兄弟节点
                foreach (TreeNode tn in node.Parent.Nodes)
                {
                    if (tn.Checked == true)
                        brotherNodeCheckedCount++;
                }
                //兄弟节点全没选，其父节点也不选
                if (brotherNodeCheckedCount == 0)
                {
                    node.Parent.Checked = false;
                    ChangeParent(node.Parent);
                }
                //兄弟节点只要有一个被选，其父节点也被选
                if (brotherNodeCheckedCount >= 1)
                {
                    node.Parent.Checked = true;
                    ChangeParent(node.Parent);
                }
            }
        }
        #endregion

        #region
        //取消节点选中状态之后，取消所有父节点的选中状态
        private void setParentNodeCheckedState(TreeNode currNode, bool state)
        {
            TreeNode parentNode = currNode.Parent; //获得当前节点的父节点
            parentNode.Checked = state; //设置父节点的选中状态
            if (state == false) //当状态设置为false 
            {
                int flag = 0;
                foreach (TreeNode broNode in parentNode.Nodes) //判断该父节点的子节点中，是否有半勾选状态的选项
                {
                    if (broNode.Checked || broNode.ToolTipText.Equals("部分勾选"))
                    {
                        flag = 1;
                    }
                }
                if (flag == 1) // 有设置父节点为半勾选状态
                {
                    parentNode.ToolTipText = "部分勾选";
                    parentNode.Checked = false;
                }
                else
                {   //设置父节点状态为 未勾选
                    parentNode.ToolTipText = "";
                    parentNode.Checked = true;
                    parentNode.Checked = false;  //需要改变节点的Checked状态，才能重新绘制控件；
                }
            }
            else
            {   //当父节点设置为选中状态时
                int flag = 0;
                foreach (TreeNode broNode in parentNode.Nodes)//判断该父节点的子节点下是否有未选中的节点。
                {
                    if (!broNode.Checked)
                    {
                        flag = 1;
                    }
                }
                if (flag == 1)
                {
                    parentNode.ToolTipText = "部分勾选";
                    parentNode.Checked = false;
                }
                else
                {
                    parentNode.ToolTipText = "";
                    parentNode.Checked = true;
                }
            }
            if (currNode.Parent.Parent != null) //如果父节点之上还有父节点
            {
                setParentNodeCheckedState(currNode.Parent, state); //递归调用
            }
        }

        //选中节点之后，选中节点的所有子节点
        private void setChildNodeCheckedState(TreeNode currNode, bool state)
        {
            TreeNodeCollection nodes = currNode.Nodes; //获取所有子节点
            if (nodes.Count > 0) //存在子节点
                foreach (TreeNode tn in nodes)
                {
                    tn.Checked = state;
                    tn.ToolTipText = "";
                    setChildNodeCheckedState(tn, state);//递归调用子节点的子节点
                }
        }

        private void skinTreeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse) //鼠标点击
            {
                //textBox1.Text = e.Node.Text;
                if (e.Node.Checked) //选中
                {
                    e.Node.ToolTipText = "";
                    //选中节点之后，选中节点的所有子节点
                    setChildNodeCheckedState(e.Node, true);
                    if (e.Node.Parent != null)
                    {
                        setParentNodeCheckedState(e.Node, true);
                    }
                }
                else  //取消选中
                {
                    e.Node.ToolTipText = "";
                    //取消节点选中状态之后，取消所有子节点的选中状态
                    setChildNodeCheckedState(e.Node, false);
                    //如果节点存在父节点，取消父节点的选中状态
                    if (e.Node.Parent != null)
                    {
                        setParentNodeCheckedState(e.Node, false);
                    }
                }
            }
        }

        private void ClassTreeList_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            if (e.Bounds.Location.X <= 0)
            {
                return;
            }
            var treeview = sender as TreeView;
            var brush = Brushes.Black; //黑色
            if (e.Node.ToolTipText.EndsWith("部分勾选") && e.Node.Checked == false)
            {  //判断为半勾选状态
                var location = e.Node.Bounds.Location;
                location.Offset(-20, 3);
                var size = new Size(20, 20);
                e.Graphics.FillRectangle(Brushes.Blue, new Rectangle(location, size)); //这里绘制的是正方形
            }
            //绘制文本
            e.Graphics.DrawString(e.Node.Text, treeview.Font, brush, e.Bounds.Left, e.Bounds.Top);
        }
        #endregion
        #endregion
    }
}

