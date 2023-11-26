using CompanyMng.Domain.Repositories;
using MediatR;

namespace CompanyMng.Application.Business.Companies.Commands;

public class AddCompanyCommand: IRequest<Domain.Entities.Companies>
{
    public Domain.Entities.Companies Company { get; set; }
}

public class AddCompanyHandler : IRequestHandler<AddCompanyCommand, Domain.Entities.Companies>
{
    private readonly ICompanyRepository _companyRepository;

    public AddCompanyHandler(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    public async Task<Domain.Entities.Companies> Handle(AddCompanyCommand request, CancellationToken cancellationToken)
    {
        await _companyRepository.Add(request.Company);
        
        return request.Company;
    }
}
