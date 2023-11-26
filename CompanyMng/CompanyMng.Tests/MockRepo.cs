using CompanyMng.Domain.Entities;
using CompanyMng.Domain.Enums;
using CompanyMng.Domain.Repositories;
using Moq;

namespace CompanyMng.Tests;

public class MockRepo
{
    public static Mock<ICompanyRepository> SetCompanyRepo()
    {
        var companies = new List<Companies>()
        {
            new Companies
            {
                Id = 1,
                CompanyName = "test",
                CompanyNumber = 1,
                Country = "test",
                Website = "test",
                CreationTime = default
            },
            new Companies
            {
                Id = 2,
                CompanyName = "test1",
                CompanyNumber = 2,
                Country = "test1",
                Website = "test1",
                CreationTime = default
            },
            new Companies
            {
                Id = 3,
                CompanyName = "test2",
                CompanyNumber = 3,
                Country = "test2",
                Website = "test2",
                CreationTime = default
            }
        };

        var mock = new Mock<ICompanyRepository>();

        mock.Setup(x => x.Get()).ReturnsAsync(companies);

        return mock;
    }
    public static Mock<IProductRepository> SetProductRepo()
    {
        var products = new List<Products>()
        {
            new Products
            {
                Id = 1,
                ProductName = "test1",
                Amount = 1,
                AmountUnit = "test1",
                Category = "test1",
                CompanyName = "test1",
                CreationTime = default
            },
            new Products
            {
                Id = 2,
                ProductName = "test2",
                Amount = 2,
                AmountUnit = "test2",
                Category = "test2",
                CompanyName = "test2",
                CreationTime = default
            },
            new Products
            {
                Id = 3,
                ProductName = "test3",
                Amount = 3,
                AmountUnit = "test3",
                Category = "test3",
                CompanyName = "test3",
                CreationTime = default
            }
        };

        var mock = new Mock<IProductRepository>();

        mock.Setup(x => x.Get()).ReturnsAsync(products);

        return mock;
    }
    public static Mock<IUserRepository> SetUserRepo()
    {
        var users = new List<Users>()
        {
            new Users
            {
                Id = 1,
                FirstName = "test1",
                LastName = "test1",
                Email = "test1",
                Username = "test1",
                Password = "test1",
                Roles = Roles.None,
                CreationTime = default
            },
            new Users
            {
                Id = 2,
                FirstName = "test2",
                LastName = "test2",
                Email = "test2",
                Username = "test2",
                Password = "test2",
                Roles = Roles.User,
                CreationTime = default
            },
            new Users
            {
                Id = 3,
                FirstName = "test3",
                LastName = "test3",
                Email = "test3",
                Username = "test3",
                Password = "test3",
                Roles = Roles.Admin,
                CreationTime = default
            }
        };

        var mock = new Mock<IUserRepository>();

        mock.Setup(x => x.Get()).ReturnsAsync(users);

        return mock;
    }
}