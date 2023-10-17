﻿using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Windows.Forms;
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
        /// 清除日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            rtbLog.Text = string.Empty;

            //DownloadFileAsRefit();

            //tvFiles.ImageList = imageList1;
            TreeNode RootNode1 = new TreeNode("根节点1");
            TreeNode ChildNode1 = new TreeNode("子节点1");
            TreeNode ChildNode2 = new TreeNode("子节点2");
            TreeNode ChildNode1_1 = new TreeNode("子节点1_1");
            TreeNode ChildNode1_2 = new TreeNode("子节点1_2");

            tvFiles.Nodes.Add(RootNode1);
            RootNode1.Nodes.AddRange(new TreeNode[] { ChildNode1, ChildNode2 });

            var ss = RootNode1.FullPath;


            //ChildNode1_1.FullPath = ss;
        }

        private void ShowMessage(object sender, EventArgs e)
        {
            // 修改其他控件的值
            rtbLog.Text += ((MessageEventArgs)e).Msg;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnCheckAllFile_ClickAsync(object sender, EventArgs e)
        {
            this.btnCheckAllFile.Enabled = false;
            var files = new List<Modes.Temp.File>();
            var projectList = await GetAllProject();

            for (int i = 0; i < projectList?.Count(); i++)
            {
                tvFiles.Nodes.Add(new TreeNode($"{projectList[i].Name}"));
                //await GetPathFiles(projectList[i], files, "tree");
            }

            MessageBox.Show(files.Count.ToString());

            ShowMessage(null, new MessageEventArgs { Msg = $"共获取文件:{files.Count.ToString()}\n" });
            files.ForEach(i =>
            {
                ShowMessage(null, new MessageEventArgs { Msg = $"{i.fullPath}\n" });
            });
            this.btnCheckAllFile.Enabled = true;
        }

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

                for (int i = 0; i < result?.data?.folders?.Count; i++)
                {
                    await GetPathFiles(project, files, $"{path}/{result?.data?.folders[i].name}");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// 
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
        /// 
        /// </summary>
        private async void DownloadFileAsRefit()
        {
            //var result = await _documentGateway.DownloadFile("bugtest", "1112.txt");
            var result = await _documentGateway.DownloadFile("tjPeoject", "111.txt");
            string sss = await result.Content.ReadAsStringAsync();
        }

        string filePath = $"C:\\bugtest\\files.txt";

        private async void btnInitTree_Click(object sender, EventArgs e)
        {
            this.btnInitTree.Enabled = false;
            var files = new List<Modes.Temp.File>();

            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                files = JsonConvert.DeserializeObject<List<Modes.Temp.File>>(jsonString);
            }
            else
            {
                var projectList = await GetAllProject();
                for (int i = 0; i < projectList?.Count(); i++)
                {
                    await GetPathFiles(projectList[i], files, "tree");
                }
                SaveToFile(files);
            }

            ShowMessage(null, new MessageEventArgs { Msg = $"共获取文件:{files.Count.ToString()}\n" });
            files.ForEach(i =>
            {
                ShowMessage(null, new MessageEventArgs { Msg = $"{i.fullPath}\n" });
            });
            this.btnInitTree.Enabled = true;
        }

        private void SaveToFile(List<Modes.Temp.File> files)
        {
            var json = JsonConvert.SerializeObject(files, Formatting.Indented);
            //判断Json字符串内容是否为空
            if (!string.IsNullOrEmpty(json))
            {
                //using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite, FileShare.ReadWrite))
                //{
                //    fs.Seek(0, SeekOrigin.Begin);
                //    fs.SetLength(0);
                //    //如果Json文件中有中文数据，可能会出现乱码的现象，那么需要加上如下代码
                //    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                //    using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                //    {
                //        sw.WriteLine(json);
                //    }
                //}
                File.WriteAllText(filePath, json);
            }
        }
    }
}
