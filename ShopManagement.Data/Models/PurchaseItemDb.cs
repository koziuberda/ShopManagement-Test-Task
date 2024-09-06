namespace ShopManagement.Data.Models;

public class PurchaseItemDb
{
    public Guid Id { get; set; }
    public Guid PurchaseId { get; set; }
    public PurchaseDb Purchase { get; set; }
    public Guid ProductId { get; set; }
    public ProductDb Product { get; set; }
    public int Quantity { get; set; }
}