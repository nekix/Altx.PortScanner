using Altx.PortScanner.Clock;
using Altx.PortScanner.EntityFrameworkCore;
using Altx.PortScanner.Guids;
using Altx.PortScanner.Repositories;
using Altx.PortScanner.Services;
using Microsoft.EntityFrameworkCore;

namespace Altx.PortScanner.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.AddJsonFile("appsettings.json");

            // Add services to the container.
            builder.Services.AddRazorPages();

            ConfigureSharedServices(builder.Services, builder.Configuration);
            ConfigureDomainServices(builder.Services, builder.Configuration);
            ConfigureEfCoreServices(builder.Services, builder.Configuration);
            ConfigureApplicationServices(builder.Services, builder.Configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }

        public static void ConfigureSharedServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IGuidGenerator, SequentialGuidGenerator>();

            services.AddTransient<DefaultClockOptions>();
            services.AddTransient<IClock, DefaultClock>();
        }

        public static void ConfigureDomainServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ScanTaskDomainService>();
        }

        private static void ConfigureApplicationServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(ApplicationAutoMapperProfile));

            services.AddTransient<IScanTaskAppService, ScanTaskAppService>();
        }

        private static void ConfigureEfCoreServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ScanTaskDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("Default"));
            });

            services.AddTransient<IScanTaskRepository, EfCoreScanTaskRepository>();
        }
    }
}
