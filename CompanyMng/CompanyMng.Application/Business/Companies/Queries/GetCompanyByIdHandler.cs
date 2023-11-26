using CompanyMng.Domain.Repositories;
using MediatR;

namespace CompanyMng.Application.Business.Companies.Queries;

public class GetCompanyByIdQuery: IRequest<Domain.Entities.Companies>
{
    public int id { get; set; }
}

public class GetCompanyByIdHandler : IRequestHandler<GetCompanyByIdQuery ,Domain.Entities.Companies>
{
    private readonly ICompanyRepository _companyRepository;

    public GetCompanyByIdHandler(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    public async Task<Domain.Entities.Companies> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
    {
        var company = await _companyRepository.GetById(request.id);

        return company;
    }
}