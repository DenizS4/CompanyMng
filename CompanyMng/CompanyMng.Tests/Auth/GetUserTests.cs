using CompanyMng.Application.Authentication.Users.Queries;
using CompanyMng.Domain.Entities;
using CompanyMng.Domain.Repositories;
using Moq;
using Shouldly;

namespace CompanyMng.Tests.Auth;

public class GetUserTests
{
    private readonly Mock<IUserRepository> _mock = MockRepo.SetUserRepo();

    [Fact]
    public async Task GetUsers_Should()
    {
        var query = new GetUserQuery();
        var handler = new GetUserHandler(_mock.Object);

        var result = await handler.Handle(query, CancellationToken.None);
        
        result.Count.ShouldBe(3);
        result.ShouldBeOfType<List<Users>>();
    }
}