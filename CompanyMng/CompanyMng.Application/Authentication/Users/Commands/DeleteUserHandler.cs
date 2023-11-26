using CompanyMng.Domain.Repositories;
using MediatR;

namespace CompanyMng.Application.Authentication.Users.Commands;

public class DeleteUserCommand: IRequest<Domain.Entities.Users>
{
    public int id { get; set; }
    public Domain.Entities.Users User { get; set; }
}

public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, Domain.Entities.Users>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }


    public async Task<Domain.Entities.Users> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        await _userRepository.Delete(request.id);
        
        return request.User;
    }
}