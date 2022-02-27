using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PublicBiddingAPI.Data;
using PublicBiddingAPI.Entities;
using PublicBiddingAPI.ServiceCalls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PublicBiddingAPI
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
            services.AddSwaggerGen(setup =>
            {

                setup.SwaggerDoc("v1",
                    new OpenApiInfo()
                    {
                        Title = "Public Bidding API",
                        Version = "v1",
                        Description = "Public Bidding API manages HTTP Request for public bidding data, it provides GET, POST, PUT,DELETE endpoints and authentication.",
                        Contact = new Microsoft.OpenApi.Models.OpenApiContact
                        {
                            Name = "Milan Novcic",
                            Email = "novcic.milan17@uns.ac.rs",
                            Url = new Uri("https://github.com/novcicmilan")
                        }
                    });
                var xmlComments = $"{ Assembly.GetExecutingAssembly().GetName().Name }.xml";
                var xmlCommentsPath = Path.Combine(AppContext.BaseDirectory, xmlComments);
                setup.IncludeXmlComments(xmlCommentsPath);
            });
            //ADDING AUTOMAPPER
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //ADDING DATABASE CONTEXT FOR MS
            services.AddDbContext<PublicBiddingContext>();
            //ADDING REPOSITORIES
            services.AddScoped<ITypeOfPublicBiddingRepository, TypeOfPublicBiddingRepository>();
            services.AddScoped<IPublicBiddingRepository, PublicBiddingRepository>();
            services.AddScoped<ILoggerService, LoggerService>();
            services.AddScoped<ILoggerService, LoggerServiceMock>();

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
                setupAction.SwaggerEndpoint("/swagger/v1/swagger.json", "publicBiddingApi");
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
