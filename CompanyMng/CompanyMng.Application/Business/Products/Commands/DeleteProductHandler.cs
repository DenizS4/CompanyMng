using CompanyMng.Domain.Repositories;
using MediatR;

namespace CompanyMng.Application.Business.Products.Commands;

public class DeleteProductCommand: IRequest<Domain.Entities.Products>
{
    public int id { get; set; }
    public Domain.Entities.Products Product { get; set; }
}

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, Domain.Entities.Products>
{
    private readonly IProductRepository _productRepository;

    public DeleteProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }


    public async Task<Domain.Entities.Products> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        await _productRepository.Delete(request.id);
        
        return request.Product;
    }
}