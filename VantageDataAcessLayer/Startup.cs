using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using VantageDataAcessLayer.CustomerRepository;
using VantageOnlineCustomer.DAL;
//using CustomerBusinessLogic;


namespace YourNamespace
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
            // Add controllers
            services.AddControllers();

            // Configure Entity Framework to use an in-memory database
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("CustomerDb"));

            // Register repository and service for dependency injection
            services.AddScoped<ICustomerRepository, CustomerRepository>();
          //  services.AddScoped<ICustomerService, CustomerService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
