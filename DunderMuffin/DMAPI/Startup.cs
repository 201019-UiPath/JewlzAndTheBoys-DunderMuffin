using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using DMDB.Models;
using DMDB;
using DMLib;

namespace DMAPI
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
            services.AddCors(options=> {
               options.AddPolicy(name: MyAllowSpecificOrigins,
                   builder =>
                   {
                       builder.WithOrigins("*")
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                   });
            });

            services.AddControllers();
            services.AddDbContext<DMContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DMDB")));

            
            services.AddScoped<IInventoryItemRepo, DBRepo>();
            services.AddScoped<ILocationRepo, DBRepo>();
            services.AddScoped<IProductRepo, DBRepo>();
            services.AddScoped<IEmployeeRepo, DBRepo>();

           
            services.AddScoped<InventoryItemServices>();
            services.AddScoped<LocationServices>();
            services.AddScoped<ProductServices>();
            services.AddScoped<EmployeeServices>();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
