using CompanyMng.Domain.Repositories;
using MediatR;

namespace CompanyMng.Application.Business.Companies.Commands;

public class UpdateCompanyCommand: IRequest<Domain.Entities.Companies>
{
    public int id { get; set; }
    public Domain.Entities.Companies Company { get; set; }
}

public class UpdateCompanyHandler : IRequestHandler<UpdateCompanyCommand, Domain.Entities.Companies>
{
    private readonly ICompanyRepository _companyRepository;

    public UpdateCompanyHandler(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }


    public async Task<Domain.Entities.Companies> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        await _companyRepository.Update(request.id, request.Company);
        
        return request.Company;
    }
}