using CompanyMng.Application.Business.Products.Queries;
using CompanyMng.Domain.Entities;
using CompanyMng.Domain.Repositories;
using Moq;
using Shouldly;

namespace CompanyMng.Tests.Business.ProductsTests;

public class GetProductTests
{
    private readonly Mock<IProductRepository> _mock = MockRepo.SetProductRepo();

    [Fact]
    public async Task GetProducts_Should()
    {
        var query = new GetProductQuery();
        var handler = new GetProductHandler(_mock.Object);

        var result = await handler.Handle(query, CancellationToken.None);
        
        result.Count.ShouldBe(3);
        result.ShouldBeOfType<List<Products>>();
    }
}