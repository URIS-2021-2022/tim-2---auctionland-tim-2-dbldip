﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Projekat.Data;
using Projekat.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekat
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

            services.AddControllers(setup =>
               setup.ReturnHttpNotAcceptable = true
           ).AddXmlDataContractSerializerFormatters() //Dodajemo podršku za XML tako da ukoliko klijent to traži u Accept header-u zahteva možemo da serializujemo payload u XML u odgovoru.
           .ConfigureApiBehaviorOptions(setupAction => //Deo koji se odnosi na podržavanje Problem Details for HTTP APIs
            {
                setupAction.InvalidModelStateResponseFactory = context =>
                {
                   //Kreiramo problem details objekat
                   ProblemDetailsFactory problemDetailsFactory = context.HttpContext.RequestServices
                      .GetRequiredService<ProblemDetailsFactory>();

                   //Prosleđujemo trenutni kontekst i ModelState, ovo prevodi validacione greške iz ModelState-a u RFC format
                   ValidationProblemDetails problemDetails = problemDetailsFactory.CreateValidationProblemDetails(
                      context.HttpContext,
                      context.ModelState);

                   //Ubacujemo dodatne podatke
                   problemDetails.Detail = "Pogledajte polje errors za detalje.";
                    problemDetails.Instance = context.HttpContext.Request.Path;

                   //po defaultu se sve vraća kao status 400 BadRequest, to je ok kada nisu u pitanju validacione greške,
                   //ako jesu hoćemo da koristimo status 422 UnprocessibleEntity
                   //tražimo info koji status kod da koristimo
                   var actionExecutiongContext = context as ActionExecutingContext;

                   //proveravamo da li postoji neka greška u ModelState-u, a takođe proveravamo da li su svi prosleđeni parametri dobro parsirani
                   //ako je sve ok parsirano ali postoje greške u validaciji hoćemo da vratimo status 422
                   if ((context.ModelState.ErrorCount > 0) &&
                      (actionExecutiongContext?.ActionArguments.Count == context.ActionDescriptor.Parameters.Count))
                    {
                        problemDetails.Type = "https://google.com"; //inače treba da stoji link ka stranici sa detaljima greške
                        problemDetails.Status = StatusCodes.Status422UnprocessableEntity;
                        problemDetails.Title = "Doslo je do greske prilikom validacije.";

                       //sve vraćamo kao UnprocessibleEntity objekat
                       return new UnprocessableEntityObjectResult(problemDetails)
                        {
                            ContentTypes = { "application/problem+json" }
                        };
                    };

                   //ukoliko postoji nešto što nije moglo da se parsira hoćemo da vraćamo status 400 kao i do sada
                   problemDetails.Status = StatusCodes.Status400BadRequest;
                    problemDetails.Title = "Doslo je do greske prilikom parsiranja poslatog sadrzaja.";
                    return new BadRequestObjectResult(problemDetails)
                    {
                        ContentTypes = { "application/problem+json" }
                    };
                };
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<ICommissionRepository, CommissionRepository>();
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApplication1", Version = "v1" });
            //});

            services.AddDbContext<CommissionContext>();

        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Projekat v1"));
            }

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