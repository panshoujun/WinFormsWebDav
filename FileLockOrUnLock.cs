using System.Text;
using System.Text.Json;

namespace WinFormsWebDav
{
    public partial class FileLockOrUnLock : UserControl
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public FileLockOrUnLock()
        {
            InitializeComponent();
            //var services = new ServiceCollection();
            //services.AddHttpClient();
            //var serviceProvider = services.BuildServiceProvider();
            //_httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();
            //_httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// 锁定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnFileLock_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();//  _httpClientFactory.CreateClient();
            string url = $"http://qatest007.cscloud.cscad.net:6003/api/document/project/{tbProject.Text}/lock-file/{tbFile.Text}";
            client.BaseAddress = new Uri(url);
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Put, client.BaseAddress);
            requestMessage.Content = new StringContent(JsonSerializer.Serialize(new PutLockFileRequest { ForceChangeLock = true, TimeoutSeconds = 60 }), Encoding.UTF8, "application/json");
            requestMessage.Headers.Add("Authorization", $"Token {tbPassword.Text}");

            var response = await client.SendAsync(requestMessage);
            var content = await response.Content.ReadAsStringAsync();
            rtbLog.Text += content;
            //MessageBox.Show(content);
        }

        /// <summary>
        /// 解锁
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnFileUnLock_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();// _httpClientFactory.CreateClient();
            string url = $"http://qatest007.cscloud.cscad.net:6003/api/document/project/{tbProject.Text}/unlock-file/{tbFile.Text}";
            client.BaseAddress = new Uri(url);
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Put, client.BaseAddress);
            requestMessage.Headers.Add("Authorization", $"Token {tbPassword.Text}");

            var response = await client.SendAsync(requestMessage);
            var content = await response.Content.ReadAsStringAsync();
            rtbLog.Text += content;
            //MessageBox.Show(content);
        }

        /// <summary>
        /// 清除日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btClear_Click(object sender, EventArgs e)
        {
            rtbLog.Text = string.Empty;
        }
    }
}
