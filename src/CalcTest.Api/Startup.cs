
using AutoMapper;
using CalcTest.DI;
using CalcTest.Service.Automapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.Swagger;

namespace CalcTest.Api
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
            services.AddMvc();
            services.AddDependencies();
            services.AddAutoMapper(typeof(AutoMapperConfig));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "API cálculo de juros compostos",
                    Description = "Teste para Cálculo de juros compostos",
                    Contact = new Contact
                    {
                        Name = "Bruno max",
                        Email = "bruno.max@outlook.com",
                        Url = "https://github.com/maxbruno/calctest"
                    }
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API cálculo de juros compostos");
            });
        }
    }
}
