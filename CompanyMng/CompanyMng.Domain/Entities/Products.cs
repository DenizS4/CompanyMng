using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyMng.Domain.Entities;

public class Products
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public int Amount { get; set; }
    public string AmountUnit { get; set; }
    public string Category { get; set; }
    public string CompanyName { get; set; }
    
    public DateTime CreationTime { get; set; }
}