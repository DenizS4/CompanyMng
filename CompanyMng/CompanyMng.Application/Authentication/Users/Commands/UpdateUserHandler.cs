using CompanyMng.Domain.Repositories;
using MediatR;

namespace CompanyMng.Application.Authentication.Users.Commands;

public class UpdateUserCommand: IRequest<Domain.Entities.Users>
{
    public int id { get; set; }
    public Domain.Entities.Users User { get; set; }
}

public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, Domain.Entities.Users>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }


    public async Task<Domain.Entities.Users> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        await _userRepository.Update(request.id, request.User);
        
        return request.User;
    }
}