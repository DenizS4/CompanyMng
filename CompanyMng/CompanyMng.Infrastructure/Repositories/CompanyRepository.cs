using CompanyMng.Domain.Entities;
using CompanyMng.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CompanyMng.Infrastructure.Repositories;

public class CompanyRepository: ICompanyRepository
{
    private readonly ApplicationDbContext _context;

    public CompanyRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Companies>> Get()
    {
        var companies = await _context.Companies.ToListAsync();
        return companies;
    }

    public async Task<int> GetTotalCompanies()
    {
        var companies = await _context.Companies.ToListAsync();
        
        return companies.Count;
    }

    public async Task<List<Companies>> GetLatestThreeCompanies()
    {
        var companies = await _context.Companies.OrderByDescending(x => x.CreationTime).Take(3).ToListAsync();
        
        return companies;
    }


    public async Task<Companies> GetById(int id)
    {
        var company = await _context.Companies.FirstOrDefaultAsync(x => x.Id == id);
        return company;
    }

    public async Task Add(Companies companies)
    {
        companies.CreationTime = DateTime.Now;
        _context.Companies.Add(companies);
        await _context.SaveChangesAsync();
    }

    public async Task Update(int id, Companies companies)
    {
        var company = await _context.Companies.FirstOrDefaultAsync(x => x.Id == id);
        var products = await _context.Products.ToListAsync();
        if (company == null) throw new Exception("Couldn't find id");

        if (company.CompanyName != companies.CompanyName)
        {
            foreach (var product in products)
            {
                if (product.CompanyName == company.CompanyName)
                    product.CompanyName = companies.CompanyName;
            }
        }
        company.CompanyName = companies.CompanyName;
        company.CompanyNumber = companies.CompanyNumber;
        company.Country = companies.Country;
        company.Website = companies.Website;
        company.CreationTime = DateTime.Now;
        
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var products = await _context.Products.ToListAsync();
        var company = await _context.Companies.FirstOrDefaultAsync(x => x.Id == id);
        if (company == null) throw new Exception("Couldn't find id");

        foreach (var product in products)
        {
            if (product.CompanyName == company.CompanyName)
                _context.Products.Remove(product);
        }
        _context.Companies.Remove(company);
        await _context.SaveChangesAsync();
    }
}