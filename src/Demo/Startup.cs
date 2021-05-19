using Microsoft.AspNetCore.Builder;
#if !NETFRAMEWORK
using Microsoft.Extensions.Hosting;
#endif
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Demo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
#if NETFRAMEWORK
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
#else
            services.AddControllers();
#endif

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
#if NETFRAMEWORK
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
#else
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
#endif
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Demo v1"));
            }

#if NETFRAMEWORK
            app.UseMvc();
#else
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
#endif
        }
    }
}
