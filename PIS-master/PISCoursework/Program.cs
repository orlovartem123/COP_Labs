using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using PISBusinessLogic.ViewModels;

namespace PISCoursework
{
    public class Program
    {
        public static UserViewModel Librarian = null;
        public static UserViewModel Reader = null;
        public static UserViewModel Accountant = null;
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseKestrel().UseUrls("http://localhost:5000", "http://192.168.130.186:5000")
.UseIISIntegration().UseStartup<Startup>();
                });
    }
}
