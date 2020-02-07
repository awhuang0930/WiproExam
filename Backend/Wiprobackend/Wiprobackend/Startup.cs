using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Wiprobackend.DomainModels;
using Wiprobackend.Repo;
using Wiprobackend.Services;

namespace Wiprobackend
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Wipro",
                    Version = "v1",
                    Description = "Wipro"
                });
            });

            services.AddCors(cx =>
            {
                cx.AddPolicy("Wipro", builder =>
                {
                    builder.AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowAnyOrigin()
                           .AllowCredentials()
                    ;
                });

                cx.AddPolicy("AnyGET", builder =>
                {
                    builder.AllowAnyHeader()
                           .WithMethods("GET")
                           .AllowAnyOrigin();
                });

                cx.AddPolicy("AnyPOST", builder =>
                {
                    builder.AllowAnyHeader()
                           .WithMethods("POST")
                           .AllowAnyOrigin();
                });
            });


            services.AddDbContext<WiprotestContext>();
            WiprotestContext.ConnectionString = Configuration.GetConnectionString("Database");

            services.AddScoped(typeof(ITrainingRepository), typeof(TrainingRepository));
            services.AddScoped(typeof(ITrainingService), typeof(TrainingService));

            services.AddCors();
            services.AddSingleton<IConfiguration>(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Use(async (ctx, next) =>
            {
                await next();
                if (ctx.Response.StatusCode == 204)
                {
                    ctx.Response.ContentLength = 0;
                }
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Wipro");
            });

            app.UseCors("Wipro");

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
