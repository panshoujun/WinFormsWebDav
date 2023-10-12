using System.Text;
using System.Text.Json;

namespace WinFormsWebDav
{
    public partial class FileLockAndUnLock : UserControl
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public FileLockAndUnLock(IHttpClientFactory httpClientFactory)
        {
            InitializeComponent();
            _httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// 锁定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnFileLock_Click(object sender, EventArgs e)
        {
            var client = _httpClientFactory.CreateClient();
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
            var client = _httpClientFactory.CreateClient();
            string url = $"http://qatest007.cscloud.cscad.net:6003/api/document/project/{tbProject.Text}/unlock-file/{tbFile.Text}";
            client.BaseAddress = new Uri(url);
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Put, client.BaseAddress);
            requestMessage.Headers.Add("Authorization", $"Token {tbPassword.Text}");

            var response = await client.SendAsync(requestMessage);
            var content = await response.Content.ReadAsStringAsync();
            rtbLog.Text += content;
            //MessageBox.Show(content);
        }
    }
}
