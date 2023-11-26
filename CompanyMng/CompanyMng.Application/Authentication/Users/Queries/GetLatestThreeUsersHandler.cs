using CompanyMng.Domain.Repositories;
using MediatR;

namespace CompanyMng.Application.Authentication.Users.Queries;

public class GetLatestThreeUsersQuery : IRequest<List<Domain.Entities.Users>>
{
}

public class GetLatestThreeUsersHandler : IRequestHandler<GetLatestThreeUsersQuery, List<Domain.Entities.Users>>
{
    private readonly IUserRepository _userRepository;

    public GetLatestThreeUsersHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<Domain.Entities.Users>> Handle(GetLatestThreeUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetLatestThreeUsers();

        return users;
    }
}