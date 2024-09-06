using ShopManagement.Core.Enums;

namespace ShopManagement.Data.Repositories.Results;

public class CategoryGroupResultDb
{
    public ProductCategory Category { get; set; }
    public int TotalQuantity { get; set; }
}