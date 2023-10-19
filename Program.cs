using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System.Configuration;
using System.Text.Json;
using WinFormsWebDav.Constants;
using WinFormsWebDav.Enums;
using WinFormsWebDav.Modes.Options;
using WinFormsWebDav.Services.Api;
using WinFormsWebDav.Services.Gateway.DocumentGateway;
using WinFormsWebDav.Services.Gateway.ProjectGW;

namespace WinFormsWebDav
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

            //Application.SetHighDpiMode(HighDpiMode.SystemAware);
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);

            WebDavInfo webDavInfo = null;

            //多个参数采用空格隔开的方式传递
            if (args.Length >= 1)
            {
                webDavInfo = new WebDavInfo()
                {
                    UserName = args[0],
                    Password = args[1],
                    MountPath = args[2]
                };
            }//多个参数采用对象的方式传递
            else if (args.Length == 1)
            {
                webDavInfo = JsonSerializer.Deserialize<WebDavInfo>(args[0]);
            }


            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            //创建服务容器
            var services = new ServiceCollection();
            //添加服务注册
            ConfigureServices(services);
            //先用DI容器生成 serviceProvider, 然后通过 serviceProvider 获取Main Form的注册实例
            var serviceProvider = services.BuildServiceProvider();

            var temp = serviceProvider.GetRequiredService<WebDavInfo>();
            if (webDavInfo != null)
            {
                temp.MountPath = webDavInfo.MountPath;
                temp.UserName = webDavInfo.UserName;
                temp.Password = webDavInfo.Password;
            }
            else
            {
                temp = webDavInfo;
            }

            //var formMain = serviceProvider.GetRequiredService<MainForm>();   //主动从容器中获取FormMain实例, 这是简洁写法

            var formMain = serviceProvider.GetRequiredService<FormMain>();

            Application.Run(formMain);
            //Application.Run(new WebDavForm(webDavInfo));
        }



        /// <summary>
        /// 注入服务
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureServices(ServiceCollection services)
        {
            services.AddHttpClient();

            //窗体
            services.AddScoped(typeof(WebDavForm));
            services.AddScoped(typeof(MainForm));
            services.AddScoped(typeof(FormMain));


            //用户控件
            services.AddScoped(typeof(FileLockAndUnLockUc));
            services.AddScoped(typeof(FileLockOrUnLock));
            services.AddScoped(typeof(AppWatcherUc));
            services.AddScoped(typeof(MicroSoftMessageQueuingUc));
            services.AddScoped(typeof(MicroSoftMessageQueuingUcNew));
            services.AddScoped(typeof(WebDavUc));

            //
            services.AddScoped<WebDavInfo>();

            //注入配置信息
            //services.AddSingleton<IConfiguration>(configuration);
            var builder = new ConfigurationBuilder();//创建config的builder
            builder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");//设置配置文件所在的路径加载配置文件信息
            var config = builder.Build();

            SetupOptions(services, config);
            SetupRefit(services, config);
            SetupServices(services);
        }



        /// <summary>
        /// 注册options
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        private static void SetupOptions(IServiceCollection services, IConfiguration config)
        {
            services.Configure<test>(config.GetSection("Test"));

            services.Configure<CloudPlatformOptions>(config.GetSection(OptionsPathConstants.CLOUD_PLATFORM));
            services.Configure<DefaultInfoOptions>(config.GetSection(OptionsPathConstants.DEFAULT_INFO));
            services.Configure<SystemOptions>(config.GetSection(OptionsPathConstants.SYSTEM));

            services.Configure<DefaultQueueOptions>(config.GetSection(OptionsPathConstants.DEFAULT_QUEUE));
            services.Configure<DefaultWebdavOptions>(config.GetSection(OptionsPathConstants.DEFAULT_WEBDAV));

            services.Configure<FileCheckOptions>(config.GetSection(OptionsPathConstants.FILE_CHECK));

        }


        /// <summary>
        /// 注册refit
        /// </summary>
        /// <param name="services"></param>
        private static void SetupRefit(IServiceCollection services, IConfiguration config)
        {
            var cloudPlatform = config.GetSection(OptionsPathConstants.CLOUD_PLATFORM).Get<CloudPlatformOptions>();
            services.AddRefitClient<IProjectApi>().ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri(cloudPlatform.BaseUrl);
                c.DefaultRequestHeaders.Add(CommonConstants.AUTHORIZATION, $"{TokenType.Token.ToString()} {cloudPlatform.Token}");
            });

            services.AddRefitClient<IDocumentApi>().ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri(cloudPlatform.BaseUrl);
                c.DefaultRequestHeaders.Add(CommonConstants.AUTHORIZATION, $"{TokenType.Token.ToString()} {cloudPlatform.Token}");
            });
        }

        /// <summary>
        /// 注册gw
        /// </summary>
        /// <param name="services"></param>
        private static void SetupServices(IServiceCollection services)
        {
            services.AddScoped<IProjectGW, ProjectGW>();
            services.AddScoped<IDocumentGateway, DocumentGateway>();
        }
    }
}