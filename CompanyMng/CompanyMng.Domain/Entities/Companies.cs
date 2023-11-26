namespace CompanyMng.Domain.Entities;

public class Companies
{
    public int Id { get; set; }
    public string CompanyName { get; set; }
    public int CompanyNumber { get; set; }
    public string Country { get; set; }
    public string Website { get; set; }
    
    public DateTime CreationTime { get; set; }
}