using aulao.orm.api.Middleware;
using aulao.orm.domain.Interfaces;
using aulao.orm.infra;
using aulao.orm.infra.Persistence;
using aulao.orm.infra.Transaction;
using aulao.orm.service;
using aulao.orm.service.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace aulao.orm.api
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
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Chillibeans API",
                    Version = "v1",
                    Description = "Description for the API goes here.",
                    Contact = new OpenApiContact
                    {
                        Name = "Meu Site",
                        Email = string.Empty,
                        Url = new Uri("https://meusite.com/"),
                    },
                });
            });

            //injeção da infraestrutura
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration["ConnectionSQL"]));
            services.AddScoped<IServiceBase, ServiceBase>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            //injeção dos serviços 
            services.AddTransient<ICorService, CorService>();
            services.AddTransient<ILenteGrauService, LenteGrauService>();
            services.AddTransient<ILenteCaracteristicaService, LenteCaracteristicaService>();
            services.AddTransient<ILenteService, LenteService>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Chillibeans API V1");
            });

            app.UseUnitOfWork();
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
