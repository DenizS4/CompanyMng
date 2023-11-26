using CompanyMng.Domain.Repositories;
using MediatR;

namespace CompanyMng.Application.Authentication.Users.Commands;

public class AddUserCommand: IRequest<Domain.Entities.Users>
{
    public Domain.Entities.Users User { get; set; }
}
public class AddUserHandler : IRequestHandler<AddUserCommand, Domain.Entities.Users>
{
    private readonly IUserRepository _userRepository;

    public AddUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Domain.Entities.Users> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        await _userRepository.Add(request.User);
        
        return request.User;
    }
}