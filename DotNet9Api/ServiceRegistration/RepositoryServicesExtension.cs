
using DotNet9.Application.RepositoryInterfaces;
using DotNet9.Insfrastructure.RepositoryImplementations;

namespace DotNet9API.ServiceRegistration
{
    public static class RepositoryServicesExtension
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services) {
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<ISessionRepository, SessionRepository>();
            return services;
        }
    }
}
