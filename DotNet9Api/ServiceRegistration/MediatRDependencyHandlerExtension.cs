using DotNet9.Application.UseCases.Session.Queries;
using DotNet9.Application.UseCases.User.Commands;
using DotNet9.Application.UseCases.User.Queries.GetUsers;
using MediatR;

namespace DotNet9.API.ServiceRegistration
{
    public static class MediatRDependencyHandlerExtension
    {
        public static IServiceCollection RegisterRequestHandlers(
        this IServiceCollection services)
        {
            services.AddScoped(typeof(IRequestHandler<GetUsersQuery, UserListResponseDto>), typeof(GetUsersQueryHandler));
            services.AddScoped(typeof(IRequestHandler<GetUsersWithoutCacheQuery, UserListResponseDto>), typeof(GetUsersWithouyCacheQueryHandler));
            services.AddScoped(typeof(IRequestHandler<GetSessionsWithSongNoteDetailsQuery, List<GetSessionsWithSongNoteDetailsDto>>), typeof(GetSessionsWithSongNoteDetailsQueryHandler));
            return services;
        }
    }
}
