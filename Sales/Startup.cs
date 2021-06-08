using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Sales.DBContexts;
using Sales.Repositories.Interfaces;
using Sales.Repositories;

namespace Sales
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
            services.AddControllersWithViews();

            //services.AddDb_context<SalesDb_context>(options =>
            //        options.UseSqlite(Configuration.GetConnectionString("SalesDb_context")));

            services.AddDbContext<SalesDbContext>(
            options => options.UseNpgsql(Configuration.GetConnectionString("SalesDbContext")),
            ServiceLifetime.Scoped);

            //public void ConfigureServices(IServiceCollection services)
            //{
            //    services.AddDb_context<Database_context>(opts =>
            //       opts.UseInMemoryDatabase("database"));
            //services.AddScoped<SalesDb_context>();
            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            //services.AddControllers();
            //}





        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
