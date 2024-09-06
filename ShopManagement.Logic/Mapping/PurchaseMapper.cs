using ShopManagement.Data.Models;
using ShopManagement.Logic.Models;

namespace ShopManagement.Logic.Mapping;

public static class PurchaseMapper
{
    public static Purchase Map(PurchaseDb db) => new()
    {
        Date = db.Date,
        Id = db.Id,
        Number = db.Number,
        PurchaseItems = db.PurchaseItems.Select(Map).ToList(),
        TotalAmount = db.TotalAmount
    };
    
    public static PurchaseItem Map(PurchaseItemDb db) => new()
    {
        Id = db.Id,
        Product = Map(db.Product),
        PurchaseId = db.PurchaseId,
        ProductId = db.ProductId,
        Quantity = db.Quantity
    };

    public static Product Map(ProductDb db) => new()
    {
        Category = db.Category.ToString(),
        Id = db.Id,
        Name = db.Name,
        Price = db.Price,
        SKU = db.SKU
    };
}