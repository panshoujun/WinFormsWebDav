using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Text.Json;
using WinFormsWebDav.Modes.Options;

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
            WebDavInfo webDavInfo = null;

            //����������ÿո�����ķ�ʽ����
            if (args.Length >= 1)
            {
                webDavInfo = new WebDavInfo()
                {
                    UserName = args[0],
                    Password = args[1],
                    MountPath = args[2]
                };
            }//����������ö���ķ�ʽ����
            else if (args.Length == 1)
            {
                webDavInfo = JsonSerializer.Deserialize<WebDavInfo>(args[0]);
            }


            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            //������������
            var services = new ServiceCollection();
            //��ӷ���ע��
            ConfigureServices(services);
            //����DI�������� serviceProvider, Ȼ��ͨ�� serviceProvider ��ȡMain Form��ע��ʵ��
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

            var formMain = serviceProvider.GetRequiredService<MainForm>();   //�����������л�ȡFormMainʵ��, ���Ǽ��д��

            Application.Run(formMain);
            //Application.Run(new WebDavForm(webDavInfo));
        }

        /// <summary>
        /// ע�����
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureServices(ServiceCollection services)
        {
            //����ע�����ʹ��Scrutor�����Լ���װ
            //services.AddScoped<YlbBio>();//

            services.AddHttpClient();

            //����
            services.AddScoped(typeof(WebDavForm));
            services.AddScoped(typeof(MainForm));

            //�û��ؼ�
            services.AddScoped(typeof(FileLockAndUnLock));
            services.AddScoped(typeof(FileLockOrUnLock));

            //
            services.AddScoped<WebDavInfo>();

            //ע��������Ϣ
            //services.AddSingleton<IConfiguration>(configuration);
            var builder = new ConfigurationBuilder();//����config��builder
            builder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");//���������ļ����ڵ�·�����������ļ���Ϣ
            var config = builder.Build();
            services.Configure<test>(config.GetSection("Test"));
        }
    }
}