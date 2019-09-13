using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TDSTecnologia.Site.Core.Entities;
using TDSTecnologia.Site.Infrastructure.Data;
using TDSTecnologia.Site.Infrastructure.Repository;
using TDSTecnologia.Site.Infrastructure.Services;
using Microsoft.AspNetCore.Identity.UI;
using TDSTecnologia.Site.Infrastructure.Integrations.Email;
using Microsoft.Extensions.Logging;

namespace TDSTecnologia.Site.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private readonly ILogger _logger;

        public Startup(IConfiguration configuration, ILogger<Startup> logger)
        {
            Configuration = configuration;
            _logger = logger;
            _logger.LogInformation("ARQUIVO: " + Configuration.GetValue<string>("Arquivo"));
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddEntityFrameworkNpgsql()
                    .AddDbContext<AppContexto>(options => options.UseNpgsql(Databases.Instance.Conexao));
            services.AddScoped<CursoRespository, CursoRespository>();
            services.AddScoped<CursoService, CursoService>();
            services.AddScoped<PermissaoService, PermissaoService>();
            services.AddScoped<UsuarioService, UsuarioService>();

            services.AddIdentity<Usuario, Permissao>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<AppContexto>();

            services.Configure<ConfiguracoesEmail>(Configuration.GetSection("ConfiguracoesEmail"));
            services.AddScoped<IEmail, Email>();

            services.AddLogging();
            services.AddSingleton<ILoggerFactory, LoggerFactory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void ConfigureDevelopment(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStatusCodePages();
            app.UseMvcWithDefaultRoute();
            app.UseStaticFiles();
            app.UseAuthentication();

            _logger.LogInformation("AMBIENTE: " + env.EnvironmentName);
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureStagingServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddEntityFrameworkNpgsql()
                    .AddDbContext<AppContexto>(options => options.UseNpgsql(Databases.Instance.Conexao));
            services.AddScoped<CursoRespository, CursoRespository>();
            services.AddScoped<CursoService, CursoService>();
            services.AddScoped<PermissaoService, PermissaoService>();
            services.AddScoped<UsuarioService, UsuarioService>();

            services.AddIdentity<Usuario, Permissao>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<AppContexto>();

            services.Configure<ConfiguracoesEmail>(Configuration.GetSection("ConfiguracoesEmail"));
            services.AddScoped<IEmail, Email>();

            services.AddLogging();
            services.AddSingleton<ILoggerFactory, LoggerFactory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void ConfigureStaging(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStatusCodePages();
            app.UseMvcWithDefaultRoute();
            app.UseStaticFiles();
            app.UseAuthentication();

            _logger.LogInformation("AMBIENTE: " + env.EnvironmentName);
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureProductionServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddEntityFrameworkNpgsql()
                    .AddDbContext<AppContexto>(options => options.UseNpgsql(Databases.Instance.Conexao));
            services.AddScoped<CursoRespository, CursoRespository>();
            services.AddScoped<CursoService, CursoService>();
            services.AddScoped<PermissaoService, PermissaoService>();
            services.AddScoped<UsuarioService, UsuarioService>();

            services.AddIdentity<Usuario, Permissao>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<AppContexto>();

            services.Configure<ConfiguracoesEmail>(Configuration.GetSection("ConfiguracoesEmail"));
            services.AddScoped<IEmail, Email>();

            services.AddLogging();
            services.AddSingleton<ILoggerFactory, LoggerFactory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void ConfigureProduction(IApplicationBuilder app, IHostingEnvironment env)
        {

            _logger.LogInformation("AMBIENTE: " + env.EnvironmentName);
            app.UseStatusCodePagesWithReExecute("/Erros/{0}");
            app.UseMvcWithDefaultRoute();
            app.UseStaticFiles();
            app.UseAuthentication();

        }
    }
}
