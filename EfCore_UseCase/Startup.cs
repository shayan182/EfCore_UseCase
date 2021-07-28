using EfCore.Domain.ProductAgg;
using EfCore.Domain.ProductCategoryAgg;
using EfCore.Application;
using EfCore.Application.Contract.Product;
using EfCore.Application.Contract.ProductCategory;
using EFCore.Infrastructure.EFCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EfCore.Infrastructure.EfCore;
using EfCore.Infrostructure.EfCore.Repository;

namespace EfCore_UseCase
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
            services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();

            services.AddTransient< IProductApplication, ProductApplication>();
            services.AddTransient< IProductRepository, ProductRepository>();
        
            services.AddDbContext<EfContext>(x =>
                    x.UseSqlServer(Configuration.GetConnectionString("EfCoreDb")));
            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
