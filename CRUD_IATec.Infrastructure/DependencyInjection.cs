using CRUD_IATec.Application.Interfaces;
using CRUD_IATec.Application.Services;
using CRUD_IATec.Infrastructure.Data;
using CRUD_IATec.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CRUD_IATec.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // Configuração do DbContext
            services.AddDbContext<EstoqueDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("CRUD_IATec.Infrastructure")));

            // Repositórios
            services.AddScoped<IEstoqueRepository, EstoqueRepository>();

            return services;
        }
    }
}