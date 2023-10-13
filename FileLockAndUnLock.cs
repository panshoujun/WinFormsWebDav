using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;
using WinFormsWebDav.Constants;
using WinFormsWebDav.Modes.Options;

namespace WinFormsWebDav
{
    public partial class FileLockAndUnLock : UserControl
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly CloudPlatformOptions _cloudPlatformOptions;
        public FileLockAndUnLock(IHttpClientFactory httpClientFactory, IOptions<CloudPlatformOptions> cloudPlatformOptions)
        {
            InitializeComponent();
            _httpClientFactory = httpClientFactory;
            _cloudPlatformOptions = cloudPlatformOptions.Value;
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitData()
        {
            tbPassword.Text = _cloudPlatformOptions.Token;
        }

        /// <summary>
        /// 锁定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnFileLock_Click(object sender, EventArgs e)
        {
            var client = _httpClientFactory.CreateClient();
            string url = string.Format($"{_cloudPlatformOptions.BaseUrl}{DocumentApiRouteConstants.LOCK_FILE}", tbProject.Text, tbFile.Text);
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
            string url = string.Format($"{_cloudPlatformOptions.BaseUrl}{DocumentApiRouteConstants.UNLOCK_FILE}", tbProject.Text, tbFile.Text);
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
