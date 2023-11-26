
using CompanyMng.Domain.Entities;
using CompanyMng.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CompanyMng.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Products>> Get()
    {
        var products = await _context.Products.ToListAsync();
        return products;
    }

    public async Task<Products> GetById(int id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        return product;
    }

    public async Task<int> GetTotalProducts()
    {
        var product = await _context.Products.ToListAsync();
        return product.Count;
    }

    public async Task<List<Products>> GetLatestThreeProducts()
    {
        var products = await _context.Products.OrderByDescending(x => x.CreationTime).Take(3).ToListAsync();
        
        return products;
    }

    public async Task<List<Products>> GetTopThreeProducts()
    {
        var products = await _context.Products.OrderByDescending(x => x.Amount).Take(3).ToListAsync();

        return products;
    }

    public async Task<Dictionary<string, int>> GetProductsByCompanies()
    {
        var products = await _context.Products.Select(x=>x.CompanyName).ToListAsync();
        
        var query = products.GroupBy(x => x)
            .Where(g => g.Count() > 0)
            .ToDictionary(x => x.Key, y => y.Count());

        return query;
    }

    public async Task Add(Products products)
    {
        products.CreationTime = DateTime.UtcNow;
        var boo = false;
        await _context.Products.AddAsync(products);
        var companies = await _context.Companies.ToListAsync();
        foreach (var company in companies)
        {
            if (company.CompanyName == products.CompanyName)
                boo = true;
        }
        if(boo)
            await _context.SaveChangesAsync();
        else
        {
            throw new Exception("Company Name doesnt exist");
        }
    }

    public async Task Update(int id, Products products)
    {
        var boo = false;
        var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        if (product == null) throw new Exception("Couldn't find id");
        
        product.ProductName = products.ProductName;
        product.Amount = products.Amount;
        product.AmountUnit = products.AmountUnit;
        product.Category = products.Category;
        product.CompanyName = products.CompanyName;
        product.CreationTime = DateTime.Now;
        
        var companies = await _context.Companies.ToListAsync();
        foreach (var company in companies)
        {
            if (company.CompanyName == products.CompanyName)
                boo = true;
        }
        if(boo)
            await _context.SaveChangesAsync();
        else
        {
            throw new Exception("Company Name doesnt exist");
        }
    }

    public async Task Delete(int id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        if (product == null) throw new Exception("Couldn't find id");

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }
}