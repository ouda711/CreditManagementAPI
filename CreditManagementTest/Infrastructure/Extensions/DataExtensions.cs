using System.Configuration;
using CreditManagementTest.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CreditManagementTest.Infrastructure.Extensions
{
    public static class DataExtensions
    {
        public static void AddDb(this IServiceCollection services, IConfiguration configuration)
        {
            
             /*services.AddDbContext<ApplicationDbContext>(options =>
      options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<ApplicationDbContext>(options=>options.UseSqlServer(configuration
                ["ConnectionStrings:DefaultConnection"]));
            */
             services.AddDbContext<ApplicationDbContext>(options =>
                 options.UseNpgsql("Host=localhost;Database=credit-management-database;Username=postgres;Password=1234"), ServiceLifetime.Transient);
        }
    }
}