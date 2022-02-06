using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using PISBusinessLogic.ViewModels;

namespace PISCourseworkARMAccountant
{
    public class Program
    {
        public static UserViewModel Accountant = null;
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseKestrel().UseUrls("http://localhost:5003", "http://192.168.234.186:5003")
 .UseIISIntegration().UseStartup<Startup>();
                });
    }
}
