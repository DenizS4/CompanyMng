using CompanyMng.Domain.Repositories;
using MediatR;

namespace CompanyMng.Application.Business.Products.Queries;

public class GetProductByIdQuery: IRequest<Domain.Entities.Products>
{
    public int Id { get; set; }
}

public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery ,Domain.Entities.Products>
{
    private readonly IProductRepository _productRepository;

    public GetProductByIdHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Domain.Entities.Products> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetById(request.Id);

        return product;
    }
}