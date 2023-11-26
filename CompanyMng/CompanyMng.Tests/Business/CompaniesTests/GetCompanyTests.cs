using CompanyMng.Application.Business.Companies.Queries;
using CompanyMng.Domain.Entities;
using CompanyMng.Domain.Repositories;
using Moq;
using Shouldly;

namespace CompanyMng.Tests.Business.CompaniesTests;

public class GetCompanyTests
{
    private readonly Mock<ICompanyRepository> _mock = MockRepo.SetCompanyRepo();

    [Fact]
    public async Task GetCompanies_Should()
    {
        var query = new GetCompanyQuery();
        var handler = new GetCompanyHandler(_mock.Object);

        var result = await handler.Handle(query, CancellationToken.None);
        
        result.Count.ShouldBe(3);
        result.ShouldBeOfType<List<Companies>>();
    }
}