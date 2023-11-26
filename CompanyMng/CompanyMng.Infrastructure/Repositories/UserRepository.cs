using CompanyMng.Domain.Entities;
using CompanyMng.Domain.Enums;
using CompanyMng.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CompanyMng.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Users>> Get()
    {
        var users = await _context.Users.ToListAsync();

        return users;
    }

    public async Task<Roles> GetUserRole(string username)
    {
        var roles = await _context.Users.ToListAsync();

        foreach (var item in roles)
        {
            if (item.Username == username)
            {
                return item.Roles;
            }
        }

        return Roles.None;
    }

    public async Task<List<Users>> GetLatestThreeUsers()
    {
        var users = await _context.Users.OrderByDescending(x => x.CreationTime).Take(3).ToListAsync();
        
        return users;
    }

    public async Task<int> GetTotalUser()
    {
        var users = await _context.Users.ToListAsync();
        return users.Count;
    }

    public async Task Add(Users users)
    {
        users.CreationTime = DateTime.Now;
        await _context.Users.AddAsync(users);
        await _context.SaveChangesAsync();
    }

    public async Task Update(int id, Users user)
    {
        var users = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        if (users == null) throw new Exception("Couldn't find id");

        users.Roles = user.Roles;
        users.Email = user.Email;
        users.Password = user.Password;
        users.FirstName = user.FirstName;
        users.Username = user.Username;
        users.LastName = user.LastName;
        users.CreationTime = DateTime.Now;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var users = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        if (users == null) throw new Exception("Couldn't find id");

        _context.Users.Remove(users);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> AuthUser(string username, string password)
    {
        var users = await _context.Users.ToListAsync();
        return users.Any(user => user.Username == username && user.Password == password);
    }
}