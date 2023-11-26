using CompanyMng.Domain.Repositories;
using MediatR;

namespace CompanyMng.Application.Authentication.Users.Queries;

public record AuthUserQuery(string username, string password) : IRequest<bool>;

public class AuthUserHandler : IRequestHandler<AuthUserQuery, bool>
{
    private readonly IUserRepository _userRepository;

    public AuthUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<bool> Handle(AuthUserQuery request, CancellationToken cancellationToken)
    {
        var auth = await _userRepository.AuthUser(request.username, request.password);

        return auth;
    }
}