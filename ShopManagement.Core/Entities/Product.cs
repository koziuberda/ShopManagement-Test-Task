using ShopManagement.Core.Enums;

namespace ShopManagement.Core.Entities;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ProductCategory Category { get; set; }
    public string SKU { get; set; }
    public decimal Price { get; set; }
}