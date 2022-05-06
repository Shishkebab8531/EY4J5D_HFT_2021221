using EY4J5D_HFT_20211221.Repository;
using EY4J5D_HFT_2021221.Data;
using EY4J5D_HFT_2021221.Endpoint.Services;
using EY4J5D_HFT_2021221.Logic;
using EY4J5D_HFT_2021221.Models;
using EY4J5D_HFT_2021221.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EY4J5D_HFT_20211221.Endpoint
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();

            services.AddControllers();
            services.AddTransient<IModelLogic, ModelLogic>();
            services.AddTransient<IBrandLogic, BrandLogic>();
            services.AddTransient<IPurchaseLogic, PurchaseLogic>();

            services.AddTransient<IRepository<Model>, ModelRepository>();
            services.AddTransient<IRepository<Brand>, BrandRepository>();
            services.AddTransient<IRepository<Purchase>, PurchaseRepository>();

            services.AddTransient<CarDbContext, CarDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(x => x
                .AllowCredentials()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithOrigins("http://localhost:4859"));
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalRHub>("/hub");
            });
        }
    }
}
