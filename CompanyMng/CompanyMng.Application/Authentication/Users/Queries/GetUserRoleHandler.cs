using CompanyMng.Domain.Enums;
using CompanyMng.Domain.Repositories;
using MediatR;

namespace CompanyMng.Application.Authentication.Users.Queries;

public record GetUserRoleQuery(string username) : IRequest<Roles>;


public class GetUserRoleHandler : IRequestHandler<GetUserRoleQuery, Roles>
{
    private readonly IUserRepository _userRepository;

    public GetUserRoleHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Roles> Handle(GetUserRoleQuery request, CancellationToken cancellationToken)
    {
        var role = await _userRepository.GetUserRole(request.username);

        return role;
    }
}