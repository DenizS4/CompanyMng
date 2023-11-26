using CompanyMng.Domain.Repositories;
using MediatR;

namespace CompanyMng.Application.Business.Products.Queries;

public class GetTotalProductsQuery : IRequest<int>
{
}

public class GetTotalCompaniesHandler : IRequestHandler<GetTotalProductsQuery, int>
{
    private readonly IProductRepository _productRepository;

    public GetTotalCompaniesHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<int> Handle(GetTotalProductsQuery request, CancellationToken cancellationToken)
    {
        var count = await _productRepository.GetTotalProducts();

        return count;
    }
}