using CompanyMng.Domain.Entities;
using CompanyMng.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace CompanyMng.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Companies> Companies {get; set; }
    
    public DbSet<Products> Products {get; set; }
    
    public DbSet<Users> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Users>().HasData(
            new Users()
            {
                Id = 1,
                FirstName = "admin",
                LastName = "admin",
                Email = "admin@mail.com",
                Username = "admin",
                Password = "admin",
                Roles = Roles.Admin,
                CreationTime = default
            },
            new Users
            {
                Id = 2,
                FirstName = "user",
                LastName = "user",
                Email = "user@mail.com",
                Username = "user",
                Password = "user",
                Roles = Roles.User,
                CreationTime = default
            }
        );
        modelBuilder.Entity<Companies>().HasData(
            new Companies
            {
                Id = 1,
                CompanyName = "company1",
                CompanyNumber = 1,
                Country = "Turkey",
                Website = "company1.com",
                CreationTime = default
            },
            new Companies
            {
                Id = 2,
                CompanyName = "company2",
                CompanyNumber = 2,
                Country = "USA",
                Website = "company2.com",
                CreationTime = default
            },
            new Companies
            {
                Id = 3,
                CompanyName = "company3",
                CompanyNumber = 3,
                Country = "Germany",
                Website = "company3.com",
                CreationTime = default
            });
        modelBuilder.Entity<Products>().HasData(
            new Products
            {
                Id = 1,
                ProductName = "Product1",
                Amount = 15,
                AmountUnit = "unit1",
                Category = "category1",
                CompanyName = "company1",
                CreationTime = default
            },
            new Products
            {
                Id = 2,
                ProductName = "Product2",
                Amount = 25,
                AmountUnit = "unit2",
                Category = "category2",
                CompanyName = "company1",
                CreationTime = default
            },
        new Products
        {
            Id = 3,
            ProductName = "Product3",
            Amount = 12,
            AmountUnit = "unit3",
            Category = "category3",
            CompanyName = "company2",
            CreationTime = default
        },
        new Products
        {
            Id = 4,
            ProductName = "Product4",
            Amount = 7,
            AmountUnit = "unit4",
            Category = "category4",
            CompanyName = "company2",
            CreationTime = default
        },
        new Products
        {
            Id = 5,
            ProductName = "Product5",
            Amount = 16,
            AmountUnit = "unit5",
            Category = "category5",
            CompanyName = "company3",
            CreationTime = default
        },
        new Products
        {
            Id = 6,
            ProductName = "Product6",
            Amount = 30,
            AmountUnit = "unit6",
            Category = "category6",
            CompanyName = "company3",
            CreationTime = default
        });
    }
}