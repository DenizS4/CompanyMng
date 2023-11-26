using CompanyMng.Domain.Entities;

namespace CompanyMng.Domain.Repositories;

public interface IProductRepository
{
    Task<List<Products>> Get();
    Task<Products> GetById(int id);
    Task<int> GetTotalProducts();
    Task<List<Products>> GetLatestThreeProducts();
    
    Task<List<Products>> GetTopThreeProducts();
    Task<Dictionary<string, int>> GetProductsByCompanies();
    Task Add(Products products);
    Task Update(int id, Products products);
    Task Delete(int id);
}