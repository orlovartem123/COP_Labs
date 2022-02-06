using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using PISBusinessLogic.ViewModels;

namespace PISCourseworkARMLibrarian
{
    public class Program
    {
        public static UserViewModel Librarian = null;
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseKestrel().UseUrls("http://localhost:5002", "http://192.168.234.186:5002")
.UseIISIntegration().UseStartup<Startup>();
                });
    }
}
