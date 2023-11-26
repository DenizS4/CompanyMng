using CompanyMng.Domain.Repositories;
using MediatR;

namespace CompanyMng.Application.Business.Companies.Queries;


public class GetLatestThreeCompaniesQuery : IRequest<List<Domain.Entities.Companies>>
{
}

public class GetLatestThreeCompaniesHandler : IRequestHandler<GetLatestThreeCompaniesQuery, List<Domain.Entities.Companies>>
{
    private readonly ICompanyRepository _companyRepository;

    public GetLatestThreeCompaniesHandler(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    public async Task<List<Domain.Entities.Companies>> Handle(GetLatestThreeCompaniesQuery request, CancellationToken cancellationToken)
    {
        var companies = await _companyRepository.GetLatestThreeCompanies();

        return companies;
    }
}