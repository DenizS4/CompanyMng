using CompanyMng.Domain.Repositories;
using MediatR;

namespace CompanyMng.Application.Business.Companies.Queries;

public class GetTotalCompaniesQuery : IRequest<int>
{
}

public class GetTotalCompaniesHandler : IRequestHandler<GetTotalCompaniesQuery, int>
{
    private readonly ICompanyRepository _companyRepository;

    public GetTotalCompaniesHandler(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    public async Task<int> Handle(GetTotalCompaniesQuery request, CancellationToken cancellationToken)
    {
        var count = await _companyRepository.GetTotalCompanies();

        return count;
    }
}