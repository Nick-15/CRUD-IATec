using CRUD_IATec.Application.Interfaces;
using CRUD_IATec.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CRUD_IATec.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Serviços
            services.AddScoped<IEstoqueService, EstoqueService>();

            return services;
        }
    }
}