using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CurrencyApi.Workers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CurrencyApi
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddHostedService<CurrencyWorkerService>();
            services.AddSingleton<HttpClient>();
            services.AddMemoryCache();
            services.AddSwaggerDocument();
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:4200/");
                                  });
            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                
                endpoints.MapControllers();
            });
            //app.UseOpenApi(config =>
            //{
            //    config.PostProcess = (document, req) =>
            //    {
            //        document.Info.Version = "v1";
            //        document.Info.Title = "Currency Api";
            //    };
            //});
            app.UseOpenApi();
            app.UseSwaggerUi3();

            //app.UseSwaggerUi3(config => config.TransformToExternalPath = (internalRoute, request) =>
            //{
            //    if (internalRoute.StartsWith("/") == true && internalRoute.StartsWith(request.PathBase) == false)
            //    {
            //        return request.PathBase + internalRoute;
            //    }
            //    else
            //    {
            //        return internalRoute;
            //    }
            //});

        }
    }
}
