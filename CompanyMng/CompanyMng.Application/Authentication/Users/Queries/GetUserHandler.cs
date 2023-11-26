using CompanyMng.Domain.Repositories;
using MediatR;

namespace CompanyMng.Application.Authentication.Users.Queries;

public class GetUserQuery: IRequest<List<Domain.Entities.Users>>
{
}

public class GetUserHandler : IRequestHandler<GetUserQuery ,List<Domain.Entities.Users>>
{
    private readonly IUserRepository _userRepository;

    public GetUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<Domain.Entities.Users>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.Get();

        return user;
    }
}