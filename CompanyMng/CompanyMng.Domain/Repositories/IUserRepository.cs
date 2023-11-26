using CompanyMng.Domain.Entities;
using CompanyMng.Domain.Enums;

namespace CompanyMng.Domain.Repositories;

public interface IUserRepository
{
    Task<List<Users>> Get();
    Task<Roles> GetUserRole(string username);
    Task<List<Users>> GetLatestThreeUsers();
    Task<int> GetTotalUser();
    Task Add(Users users);
    Task Update(int id, Users user);
    Task Delete(int id);

    Task<bool> AuthUser(string username, string password);
}