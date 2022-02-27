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
            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc("PublicBiddingMicroService",
                    new OpenApiInfo()
                    {
                        Title = "PublicBidding API",
                        Version = "1",
                        Description = "This API is used to create, update, delete and get all public biddings.",
                        Contact = new OpenApiContact
                        {
                            Name = "Milan Novcic",
                            Email = "novcic.milan17@uns.ac.rs",
                            Url = new Uri("https://github.com/novcicmilan")
                        }
                    });

                var xmlComments = $"{ Assembly.GetExecutingAssembly().GetName().Name }.xml";

                var xmlCommentsPath = Path.Combine(AppContext.BaseDirectory, xmlComments);

                setupAction.IncludeXmlComments(xmlCommentsPath);
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
                setupAction.SwaggerEndpoint("/swagger/PublicBiddingMicroService/swagger.json", "PublicBidding API");
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
