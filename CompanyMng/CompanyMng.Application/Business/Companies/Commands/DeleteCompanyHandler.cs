using CompanyMng.Domain.Repositories;
using MediatR;

namespace CompanyMng.Application.Business.Companies.Commands;

public class DeleteCompanyCommand: IRequest<Domain.Entities.Companies>
{
    public int id { get; set; }
    public Domain.Entities.Companies Company { get; set; }
}

public class DeleteCompanyHandler : IRequestHandler<DeleteCompanyCommand, Domain.Entities.Companies>
{
    private readonly ICompanyRepository _companyRepository;

    public DeleteCompanyHandler(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }


    public async Task<Domain.Entities.Companies> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
    {
        await _companyRepository.Delete(request.id);
        
        return request.Company;
    }
}