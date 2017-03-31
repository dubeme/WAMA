using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WAMA.Core.Models;
using WAMA.Core.Models.Provider;
using WAMA.Core.Models.Service;
using WAMA.Core.Providers;
using WAMA.Core.Services;
using WAMA.Web.Model;

namespace WAMA.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc().AddMvcOptions(options =>
            {
                options.ModelBinderProviders.Insert(0, new WamaModelBinderProvider());
            });

            services.AddTransient<DbContextOptions>(serviceProvider =>
            {
                var connection = @"Server=(localdb)\mssqllocaldb;Database=wama.db;User Id=wama.dev;Password=BAD_P455W0RD;";

                return (new DbContextOptionsBuilder<WamaDbContext>())
                    .UseSqlServer(connection)
                    .Options;
            });

            services.AddTransient<IDbContextProvider, DbContextProvider>();
            services.AddTransient<ICheckInService, CheckInService>();
            services.AddTransient<ICSVService, CSVService>();
            services.AddTransient<IUserAccountService, UserAccountService>();
            services.AddTransient<ICertificationService, CertificationService>();
            services.AddTransient<IWaiverService, WaiverService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                // TODO: Update link to custom error page
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new
                    {
                        Controller = "CheckIn",
                        Action = "Index"
                    });
            });
        }
    }
}