using ShopManagement.Core.Enums;

namespace ShopManagement.Logic.Models;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public string SKU { get; set; }
    public decimal Price { get; set; }
}