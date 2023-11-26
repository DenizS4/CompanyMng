using CompanyMng.Application.Business.Companies.Commands;
using CompanyMng.Domain.Repositories;
using MediatR;

namespace CompanyMng.Application.Business.Products.Commands;

public class AddProductCommand: IRequest<Domain.Entities.Products>
{
    public Domain.Entities.Products Product { get; set; }
}

public class AddProductHandler : IRequestHandler<AddProductCommand, Domain.Entities.Products>
{
    private readonly IProductRepository _productRepository;

    public AddProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Domain.Entities.Products> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        await _productRepository.Add(request.Product);
        
        return request.Product;
    }
}
