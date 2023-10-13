using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;
using WinFormsWebDav.Base;
using WinFormsWebDav.Constants;
using WinFormsWebDav.Modes.Options;

namespace WinFormsWebDav
{
    public partial class FileLockAndUnLock : BaseUserControl
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly CloudPlatformOptions _cloudPlatformOptions;
        public FileLockAndUnLock(IHttpClientFactory httpClientFactory, IOptions<CloudPlatformOptions> cloudPlatformOptions)
        {
            InitializeComponent();
            _httpClientFactory = httpClientFactory;
            _cloudPlatformOptions = cloudPlatformOptions.Value;

            InitData();
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        protected override void InitData()
        {
            tbPassword.Text = _cloudPlatformOptions.Token;
        }

        /// <summary>
        /// 显示消息
        /// </summary>
        /// <param name="msg"></param>
        protected override void ShowMessage(string msg)
        {
            //base.ShowMessage(msg);
            rtbLog.Text += msg;
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

            ShowMessage(content);
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

            ShowMessage(content);
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
    }
}
