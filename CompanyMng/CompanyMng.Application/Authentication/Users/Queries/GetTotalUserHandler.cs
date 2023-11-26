using CompanyMng.Domain.Repositories;
using MediatR;

namespace CompanyMng.Application.Authentication.Users.Queries;

public class GetTotalUsersQuery : IRequest<int>
{
}

public class GetTotalUserHandler : IRequestHandler<GetTotalUsersQuery, int>
{
    private readonly IUserRepository _userRepository;

    public GetTotalUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<int> Handle(GetTotalUsersQuery request, CancellationToken cancellationToken)
    {
        var count = await _userRepository.GetTotalUser();

        return count;
    }
}