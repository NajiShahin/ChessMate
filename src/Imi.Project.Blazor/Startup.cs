using Imi.Project.Blazor.Core.Models;
using Imi.Project.Blazor.Services;
using Imi.Project.Blazor.Services.Hardcoded;
using Imi.Project.Blazor.Services.Api;
using Imi.Project.Blazor.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Syncfusion.Blazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Imi.Project.Blazor
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<ICRUDService<UserListItem, UserItem>, Services.Api.UsersService>();
            services.AddTransient<ICRUDService<EventListItem, EventItem>, Services.Api.EventService>();
            services.AddTransient<IGameService, Services.Api.GameService>();

            services.AddTransient<IStatisticsService, StatisticsService>();
            services.AddTransient<HttpClient>();
            services.AddSyncfusionBlazor();
            services.AddSignalR(e => {
                e.MaximumReceiveMessageSize = 65536;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
