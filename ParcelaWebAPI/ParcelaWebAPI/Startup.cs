
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ParcelaWebAPI.Data;
using ParcelaWebAPI.Entities;
using ParcelaWebAPI.ServiceCalls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ParcelaWebAPI
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
            services.AddScoped<IParcelRepository, ParcelRepository>();
            services.AddScoped<IParcelPartRepository, ParcelPartRepository>();
            services.AddScoped<IParcelUserRepository, ParcelUserRepository>();
            services.AddScoped<IProtectedZoneRepository, ProtectedZoneRepository>();
            services.AddScoped<ICadastralMunicipalityRepository, CadastralMunicipalityRepository>();
            services.AddDbContext<ParcelContext>();
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
                        Title = "Parcela API",
                        Version = "v1",
                        Description = "API Parcela omogucava unos i pregled podataka o parcelama.",
                        Contact = new Microsoft.OpenApi.Models.OpenApiContact
                        {
                            Name = "Andrija Tasic",
                            Email = "andrija.tasic@uns.ac.rs",
                            Url = new Uri(Configuration["Swagger:Github"])
                        }
                    });
                //Korisitmo refleksiju za dobijanje XML fajla za komentarima
                var xmlComments = $"{ Assembly.GetExecutingAssembly().GetName().Name }.xml";
                var xmlCommentsPath = Path.Combine(AppContext.BaseDirectory, xmlComments);
                setup.IncludeXmlComments(xmlCommentsPath);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

            app.UseSwagger();
            app.UseSwaggerUI(setupAction =>
            {
                setupAction.SwaggerEndpoint("/swagger/v1/swagger.json", "Parcela API");
                setupAction.RoutePrefix = "";
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
