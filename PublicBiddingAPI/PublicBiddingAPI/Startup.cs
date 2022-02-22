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
                        //Često treba da dodamo neke dodatne informacije
                        Description = "Pomocu ovog API-ja moze da se kreira javno nadmetanje, da se vrsi modifikacija kao i pregled kreiranih javnih nadmetanja i statusa i tipova javnih nadmetanja.",
                        Contact = new OpenApiContact
                        {
                            Name = "Milan Novcic",
                            Email = "novcic.milan17@uns.ac.rs",
                            Url = new Uri("https://github.com/novcicmilan")
                        }
                    });

                //Pomocu refleksije dobijamo ime XML fajla sa komentarima (ovako smo ga nazvali u Project -> Properties)
                var xmlComments = $"{ Assembly.GetExecutingAssembly().GetName().Name }.xml";

                //Pravimo putanju do XML fajla sa komentarima
                var xmlCommentsPath = Path.Combine(AppContext.BaseDirectory, xmlComments);

                //Govorimo swagger-u gde se nalazi dati xml fajl sa komentarima
                setupAction.IncludeXmlComments(xmlCommentsPath);
            });
            //ADDING AUTOMAPPER
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //ADDING DATABASE CONTEXT FOR MS
            services.AddDbContext<PublicBiddingContext>();
            //ADDING REPOSITORIES
            services.AddScoped<ITypeOfPublicBiddingRepository, TypeOfPublicBiddingRepository>();
            services.AddScoped<IPublicBiddingRepository, PublicBiddingRepository>();

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
                //Podesavamo endpoint gde Swagger UI moze da pronadje OpenAPI specifikaciju
                setupAction.SwaggerEndpoint("/swagger/PublicBiddingMicroService/swagger.json", "PublicBidding API");
                setupAction.RoutePrefix = ""; //Dokumentacija ce sada biti dostupna na root-u (ne mora da se pise /swagger)
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
