using Microsoft.AspNetCore.Hosting;
#if NETFRAMEWORK
using Microsoft.AspNetCore;
#else
using Microsoft.Extensions.Hosting;
#endif

namespace Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
#if NETFRAMEWORK
            CreateWebHostBuilder(args).Build().Run();
#else
            CreateHostBuilder(args).Build().Run();
#endif
        }

#if NETFRAMEWORK
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
#else
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
#endif
    }
}
