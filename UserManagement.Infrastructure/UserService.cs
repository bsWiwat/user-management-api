using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserManagement.Application.Contracts.Repository;
using UserManagement.Infrastructure.Repositories;

namespace UserManagement.Infrastructure
{
    public static class UserService
    {
        public static IServiceCollection AddUserManagementInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Register repositories
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}