using DotNet9.Application.UseCases.User.Commands;
using DotNet9.Application.UseCases.User.Queries.GetUsers;
using MediatR;

namespace DotNet9.API.ServiceRegistration
{
    public static class MediatRDependencyHandler
    {
        public static IServiceCollection RegisterRequestHandlers(
        this IServiceCollection services)
        {
            services.AddScoped(typeof(IRequestHandler<GetUsersQuery, UserListResponseDto>), typeof(GetUsersQueryHandler));
            services.AddScoped(typeof(IRequestHandler<GetUsersWithoutCacheQuery, UserListResponseDto>), typeof(GetUsersWithouyCacheQueryHandler));
            return services;
        }
    }
}
