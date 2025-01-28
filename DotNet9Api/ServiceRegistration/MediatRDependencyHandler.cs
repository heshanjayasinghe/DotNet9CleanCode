using DotNet9.Application.UseCases.User.Commands;
using MediatR;

namespace DotNet9.API.ServiceRegistration
{
    public static class MediatRDependencyHandler
    {
        public static IServiceCollection RegisterRequestHandlers(
        this IServiceCollection services)
        {
            services.AddScoped(typeof(IRequestHandler<GetUsersQuery, UserListResponseDto>), typeof(GetUsersQueryHandler));
            return services;
        }
    }
}
