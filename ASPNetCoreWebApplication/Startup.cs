using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNetCoreWebApplication.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using ASPNetCoreWebApplication.Services;

namespace ASPNetCoreWebApplication
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddXmlSerializerFormatters();
            //services.AddDbContext<ProductsDbContext>(option => option.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=ProductsDb;"));
            //services.AddScoped<IProduct, ProductRepository>();
            services.AddSwaggerGen(x => x.SwaggerDoc("whatever", new Swashbuckle.AspNetCore.Swagger.Info { Title = "This is Title", Version = "This is Version" }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ProductsDbContext productsDbContext)
        {
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
            productsDbContext.Database.EnsureCreated();
        }
    }
}
