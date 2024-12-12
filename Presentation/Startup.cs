using Desafio.Spassu.TJRJ.Application.Application;
using Desafio.Spassu.TJRJ.Application.Interfaces;
using Desafio.Spassu.TJRJ.Domain.Interfaces.Service;
using Desafio.Spassu.TJRJ.Infrastructure.Context;
using Desafio.Spassu.TJRJ.Infrastructure.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Desafio.Spassu.TJRJ.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            //var connectionString = Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("String de conexão 'DefaultConnection' não localizada.");
            //services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

            services.AddSingleton(typeof(IGenericService<>), typeof(GenericRepository<>));
            services.AddSingleton<IAssuntoService, AssuntoRepository>();
            services.AddSingleton<IAutorService, AutorRepository>();
            services.AddSingleton<ILivroService, LivroRepository>();

            services.AddSingleton<IAutorApp, AppAutor>();
            services.AddSingleton<IAssuntoApp, AppAssunto>();
            services.AddSingleton<ILivroApp, AppLivro>();

            services.AddControllersWithViews();

            //services.AddFastReport();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseFastReport();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
