using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Module1.Data;
using Module1.Services;

namespace Module1
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
            services.AddMvc();
            services.AddDbContext<ProductsDbContext>(option => option.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProductsDb"));
            services.AddScoped<IProduct, ProductRepository>();
            services.AddScoped<IBuys, BuysRepository>();
            services.AddScoped<ICompany, CompanyRepository>();
            services.AddScoped<ICustomer, CustomerRepository>();
            services.AddScoped<IStore, StoreRepository>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ProductsDbContext productsDbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            productsDbContext.Database.EnsureCreated();
        }
    }
}
