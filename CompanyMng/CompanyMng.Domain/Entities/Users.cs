using CompanyMng.Domain.Enums;

namespace CompanyMng.Domain.Entities;

public class Users
{
    public int Id { get; set; }
    
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }
    
    public Roles Roles { get; set; }
    
    public DateTime CreationTime { get; set; }
}