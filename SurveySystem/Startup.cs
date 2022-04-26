using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SurveySystem.Common.Mapping;
using SurveySystem.Data;
using SurveySystem.Data.Interfaces;
using SurveySystem.Repositories;
using SurveySystem.Repositories.Interfaces;
using SurveySystem.Services;
using SurveySystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveySystem
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
            services.AddHttpClient();

            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

          //  IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapperConfig);

            services.AddMvc();

            services.AddTransient(typeof(IElementRepository), typeof(ElementRepository));
            services.AddTransient(typeof(IElementService), typeof(ElementService));
            services.AddTransient(typeof(IAnswerRepository), typeof(AnswerRepository));
            services.AddTransient(typeof(IAnswerService), typeof(AnswerService));

            services.AddSingleton(typeof(ISurveyContext), typeof(SurveyContext));
            services.AddTransient<SurveyContext>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Survey APIs",
                    Version = "v1",
                    Description = "Description for the API goes here.",
                    Contact = new OpenApiContact
                    {
                        Name = "Yacell Borges",
                        Email = string.Empty
                    },
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SurveyContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                dbContext.Database.EnsureCreated();
            }

            app.UseCors(o =>
            {
                o.WithOrigins("http://localhost:3000");
                o.WithOrigins("http://192.168.0.125:3000");
                o.AllowAnyHeader();
                o.AllowAnyMethod();
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Survey API V1");

                // To serve SwaggerUI at application's root page, set the RoutePrefix property to an empty string.
                c.RoutePrefix = string.Empty;
            });

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
