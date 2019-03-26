using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SD.Application.Commands;
using SD.Application.Queries;
using SD.Application.Services;
using SD.Domain.Interfaces.Services;
using Swashbuckle.AspNetCore.Swagger;

namespace SD.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddScoped<IContaCorrenteService, ContaCorrenteService>()
                .AddScoped<ILancamentoService, LancamentoService>()
                .AddScoped<ITransferenciaCommand, TransferenciaCommand>()
                .AddScoped<IContaCorrenteQuery, ContaCorrenteQuery>()
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services
                .AddSwaggerGen(x =>
                {
                    x.SwaggerDoc("v1", new Info() { Title = "Superdigital API", Version = "v1" });
                });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Superdigital API v1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
