using CompanyMng.Domain.Repositories;
using MediatR;

namespace CompanyMng.Application.Business.Companies.Queries;

public class GetCompanyQuery: IRequest<List<Domain.Entities.Companies>>
{
}

public class GetCompanyHandler : IRequestHandler<GetCompanyQuery ,List<Domain.Entities.Companies>>
{
    private readonly ICompanyRepository _companyRepository;

    public GetCompanyHandler(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    public async Task<List<Domain.Entities.Companies>> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
    {
        var company = await _companyRepository.Get();

        return company;
    }
}