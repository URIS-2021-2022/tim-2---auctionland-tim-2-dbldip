﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using CommissionWebAPI.Data;
using CommissionWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommissionWebAPI.ServiceCalls;
using System.Reflection;
using System.IO;

namespace CommissionWebAPI
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


            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<ICommissionRepository, CommissionRepository>();
            services.AddScoped<ILoggerService, LoggerServiceMock>();
            services.AddSwaggerGen(setup =>
            {
                /*var securitySchema = new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };*/

                //setup.AddSecurityDefinition("Bearer", securitySchema);

                /* var securityRequirement = new OpenApiSecurityRequirement
                 {
                     { securitySchema, new[] { "Bearer" } }
                 };*/

                //setup.AddSecurityRequirement(securityRequirement);

                setup.SwaggerDoc("v1",
                    new OpenApiInfo()
                    {
                        Title = "Commission API",
                        Version = "v1",
                        Description = "API Commission omogućava unos i pregled podataka o komisijama.",
                        Contact = new Microsoft.OpenApi.Models.OpenApiContact
                        {
                            Name = "Nikola Bikar",
                            Email = "nikolabikar1@gmail.com",
                            Url = new Uri(Configuration["Swagger:Github"])
                        }
                    });
                //Korisitmo refleksiju za dobijanje XML fajla za komentarima
                var xmlComments = $"{ Assembly.GetExecutingAssembly().GetName().Name }.xml";
                var xmlCommentsPath = Path.Combine(AppContext.BaseDirectory, xmlComments);
                setup.IncludeXmlComments(xmlCommentsPath);
            });


            services.AddDbContextPool<CommissionContext>(options => options.UseSqlServer(Configuration.GetConnectionString("CommissionDB")));
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(setupAction => {
                setupAction.SwaggerEndpoint("/swagger/v1/swagger.json", "Commission API");
                setupAction.RoutePrefix = "";
                });


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
