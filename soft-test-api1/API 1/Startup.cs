using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Soft.InterestRate.Domain.entities;
using Soft.InterestRate.Domain.Services.Concrete;
using Soft.InterestRate.Domain.Services.Interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace Soft.InterestRate.Api
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
            #region Assembly Info
            services.AddControllers();

            var assembly = GetType().Assembly;
            var assemblyInfo = assembly.GetName();

            var descriptionAttribute = assembly
                 .GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false)
                 .OfType<AssemblyDescriptionAttribute>()
                 .FirstOrDefault();
            var productAttribute = assembly
                 .GetCustomAttributes(typeof(AssemblyProductAttribute), false)
                 .OfType<AssemblyProductAttribute>()
                 .FirstOrDefault();
            var copyrightAttribute = assembly
                 .GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false)
                 .OfType<AssemblyCopyrightAttribute>()
                 .FirstOrDefault();
            #endregion

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = productAttribute.Product,
                        Version = assemblyInfo.Version.ToString(),
                        Description = descriptionAttribute.Description,
                        Contact = new Microsoft.OpenApi.Models.OpenApiContact
                        {
                            Name = copyrightAttribute.Copyright,
                            Url = new Uri(@"https://github.com/willimar/crud.api"),
                            Email = "willimar in the gmail",
                        },
                        TermsOfService = null,
                        License = new Microsoft.OpenApi.Models.OpenApiLicense()
                        {
                            Name = "GNU GENERAL PUBLIC LICENSE",
                            Url = new Uri(@"https://github.com/willimar/crud.api/blob/master/LICENSE")
                        }
                    });
                c.EnableAnnotations();
            });

            #region Dependences

            services.AddScoped<IService<InterestRateEntity>, InterestRateService>();
            services.AddSingleton<InterestRateEntity>(r => new InterestRateEntity() { Value = 0.01M });

            #endregion

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddOptions();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            #region Assembly Info
            var assembly = GetType().Assembly;
            var productAttribute = assembly
                 .GetCustomAttributes(typeof(AssemblyProductAttribute), false)
                 .OfType<AssemblyProductAttribute>()
                 .FirstOrDefault();
            var assemblyInfo = assembly.GetName();
            #endregion

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    $"{productAttribute.Product} v{assemblyInfo.Version}");

            });


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);
        }
    }
}
