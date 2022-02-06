using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using PISBusinessLogic.ViewModels;

namespace PISCourseworkARMReader
{
    public class Program
    {
        public static UserViewModel Reader = null;
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseKestrel().UseUrls("http://localhost:5004", "http://192.168.1.112:5004")
 .UseIISIntegration().UseStartup<Startup>();
                });
    }
}
