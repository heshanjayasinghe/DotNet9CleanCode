using DotNet9.Domain.RepositoryInterfaces;
using DotNet9.Insfrastructure.RepositoryImplementations;

namespace DotNet9API.ServiceRegistration
{
    public static class RepositoryServicesExtension
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services) {
            services.AddScoped<IUserRepository,UserRepository>();
            return services;
        }
    }
}
