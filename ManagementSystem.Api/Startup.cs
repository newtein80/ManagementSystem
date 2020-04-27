using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ManagementSystem.Infra.Injections;
using ManagementSystem.Infra.Injections.InjectionTest;
using ManagementSystem.Application.Common.Interface;
using ManagementSystem.Api.Services;
using ManagementSystem.Application;
using System.Linq;
using NSwag.Generation.Processors.Security;

namespace ManagementSystem.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // �� �޼ҵ�� ��Ÿ�ӿ� ���� ȣ��˴ϴ�. �����̳ʿ� ���񽺸� �߰��Ϸ����� ����� ����Ͻʽÿ�.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication();
            services.AddInfra(Configuration);

            services.AddScoped<ICurrentUserService, CurrentUserService>();

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddScoped<IDependencyTest, DependencyTest>();

            // In production, React ������ �� ���丮���� �����˴ϴ�
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            services.AddOpenApiDocument(configure =>
            {
                configure.Title = "Management App API";
                configure.AddSecurity("JWT", Enumerable.Empty<string>(), new NSwag.OpenApiSecurityScheme
                {
                    Type = NSwag.OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = NSwag.OpenApiSecurityApiKeyLocation.Header,
                    Description = "Type into the textbox: Bearer {your JWT token}"
                });

                configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
            });
        }

        // �� �޼ҵ�� ��Ÿ�ӿ� ���� ȣ��˴ϴ�. �� ����� ����Ͽ� HTTP ��û ������ ������ �����Ͻʽÿ�.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseOpenApi();
                app.UseSwaggerUi3();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
