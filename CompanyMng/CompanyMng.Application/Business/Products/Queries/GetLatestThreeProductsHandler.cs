using CompanyMng.Domain.Repositories;
using MediatR;

namespace CompanyMng.Application.Business.Products.Queries;

public class GetLatestThreeProductsQuery : IRequest<List<Domain.Entities.Products>>
{
}

public class GetLatestThreeProductsHandler : IRequestHandler<GetLatestThreeProductsQuery, List<Domain.Entities.Products>>
{
    private readonly IProductRepository _productRepository;

    public GetLatestThreeProductsHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<Domain.Entities.Products>> Handle(GetLatestThreeProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetLatestThreeProducts();

        return products;
    }
}