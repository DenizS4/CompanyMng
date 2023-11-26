using CompanyMng.Domain.Repositories;
using MediatR;

namespace CompanyMng.Application.Business.Products.Queries;

public class GetProductQuery: IRequest<List<Domain.Entities.Products>>
{
}

public class GetProductHandler : IRequestHandler<GetProductQuery ,List<Domain.Entities.Products>>
{
    private readonly IProductRepository _productRepository;

    public GetProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<Domain.Entities.Products>> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.Get();

        return product;
    }
}