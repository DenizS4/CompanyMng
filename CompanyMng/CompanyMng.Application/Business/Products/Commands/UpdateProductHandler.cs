
using CompanyMng.Domain.Repositories;
using MediatR;

namespace CompanyMng.Application.Business.Products.Commands;

public class UpdateProductCommand: IRequest<Domain.Entities.Products>
{
    public int id { get; set; }
    public Domain.Entities.Products Product { get; set; }
}

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Domain.Entities.Products>
{
    private readonly IProductRepository _productRepository;

    public UpdateProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }


    public async Task<Domain.Entities.Products> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        await _productRepository.Update(request.id, request.Product);
        
        return request.Product;
    }
}