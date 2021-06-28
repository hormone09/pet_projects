using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Portal.Server;
using Portal.Data;
using Portal.Models;
using Portal.Interfaces;
using Portal.Repository;

namespace Portal
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();
            services.AddControllersWithViews();
            services.AddCors(options => options.AddDefaultPolicy(
                builder => builder.AllowAnyOrigin()));
            services.AddTransient<IUpdate, RepUpdate>();
            services.AddTransient<IStudent, RepStudent>();
            services.AddTransient<ITeacher, RepTeacher>();

            services.AddDbContext<AplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DbConnection"))).AddIdentity<User, Role>
                    (config =>
                    {
                        config.Password.RequireDigit = false;
                        config.Password.RequireLowercase = false;
                        config.Password.RequireNonAlphanumeric = false;
                        config.Password.RequireUppercase = false;
                        config.Password.RequiredLength = 6;
                    })
                    .AddEntityFrameworkStores<AplicationDbContext>();

            services.ConfigureApplicationCookie(config =>
            {
                config.LoginPath = "/Account/Login";
                config.AccessDeniedPath = "/Home/AccessDenied";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseRouting();
            app.UseCors();
            app.UseStaticFiles();
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<NotificationHub>("/notifications");
                endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=RedirectOnController}");
            });
        }
    }
}
