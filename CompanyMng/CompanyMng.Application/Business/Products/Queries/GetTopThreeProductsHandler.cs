using CompanyMng.Domain.Repositories;
using MediatR;

namespace CompanyMng.Application.Business.Products.Queries;

public class GetTopThreeProductsQuery : IRequest<List<Domain.Entities.Products>>
{
}

public class GetTopThreeProductsHandler : IRequestHandler<GetTopThreeProductsQuery, List<Domain.Entities.Products>>
{
    private readonly IProductRepository _productRepository;

    public GetTopThreeProductsHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<Domain.Entities.Products>> Handle(GetTopThreeProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetTopThreeProducts();

        return products;
    }
}