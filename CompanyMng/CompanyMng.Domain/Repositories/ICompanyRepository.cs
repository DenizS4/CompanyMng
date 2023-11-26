using CompanyMng.Domain.Entities;

namespace CompanyMng.Domain.Repositories;

public interface ICompanyRepository
{
    Task<List<Companies>> Get();
    Task<int> GetTotalCompanies();
    Task<List<Companies>> GetLatestThreeCompanies();
    Task<Companies> GetById(int id);
    Task Add(Companies companies);
    Task Update(int id, Companies companies);
    Task Delete(int id);
}