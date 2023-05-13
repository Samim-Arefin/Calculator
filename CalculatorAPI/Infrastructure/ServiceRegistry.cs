using CalculatorAPI.Entities;
using CalculatorAPI.Mapping;
using CalculatorAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace CalculatorAPI.Infrastructure
{
    public static class ServiceRegistry
    {
        public static IServiceCollection RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var dbConnectionString = configuration.GetConnectionString("Db_Connection");
            services.AddDbContext<AppDbContext>(o => o.UseSqlServer(dbConnectionString));
            return services;
        }

        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ICalculatorService, CalculatorService>();
            services.AddAutoMapper(typeof(Mapper));

            return services;
        }

        public static IServiceCollection AddCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(option =>
            {
                option.AddPolicy("CorsPolicy",
                  policy =>
                  {
                      policy.AllowAnyOrigin()
                      .AllowAnyHeader()
                      .AllowAnyMethod();
                  });
            });
            return services;
        }
    }
}
