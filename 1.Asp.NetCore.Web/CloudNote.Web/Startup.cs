using CloudNote.Core;
using CloudNote.Core.SqlServer.Repositories;
using CloudNote.Domain.IRepositories;
using CloudNote.Service;
using CloudNote.Service.AuthorityApp;
using CloudNote.Service.DatumApp;
using CloudNote.Service.NoteApp;
using CloudNote.Service.PhotoApp;
using CloudNote.Service.RoleApp;
using CloudNote.Service.UserApp;
using CloudNote.Service.VideoApp;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudNote.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            MyMapper.Initialize();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddMvc();
            services.AddSession();
            services.AddDbContext<CloudNoteDbContext>(optios =>
             optios.UseSqlServer(Configuration.GetConnectionString("SqlServerString")));

            services.AddScoped<INoteRepository, NoteRepository>();
            services.AddScoped<INoteAppService, NoteAppService>();

            services.AddScoped<IVideoRepository, VideoRepository>();
            services.AddScoped<IVideoAppService, VideoAppService>();

            services.AddScoped<IPhotoRepository, PhotoRepository>();
            services.AddScoped<IPhotoAppService, PhotoAppService>();

            services.AddScoped<IDatumRepository, DatumRepository>();
            services.AddScoped<IDatumAppService, DatumAppService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserAppService, UserAppService>();

            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IUserRoleAppService, UserRoleAppService>();

            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleAppService, RoleAppService>();

            services.AddScoped<IAuthorityRepository, AuthorityRepository>();
            services.AddScoped<IAuthorityAppService, AuthorityAppService>();

            services.AddControllersWithViews();
            services.AddRazorPages().AddRazorRuntimeCompilation();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "AdminArea",
                    areaName: "Admin",                  
                    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
