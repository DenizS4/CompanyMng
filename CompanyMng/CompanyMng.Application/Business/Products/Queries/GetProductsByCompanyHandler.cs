using CompanyMng.Domain.Repositories;
using CompanyMng.Infrastructure.Repositories;
using MediatR;

namespace CompanyMng.Application.Business.Products.Queries;


public class GetProductsByCompanyQuery : IRequest<Dictionary<string,int>>
{
    
}
public class GetProductsByCompanyHandler : IRequestHandler<GetProductsByCompanyQuery, Dictionary<string, int>>
{
    private readonly IProductRepository _productRepository;

    public GetProductsByCompanyHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Dictionary<string, int>> Handle(GetProductsByCompanyQuery request, CancellationToken cancellationToken)
    {
        return await _productRepository.GetProductsByCompanies();
    }
}