namespace ShopManagement.Data.Models;

public class PurchaseDb
{
    public Guid Id { get; set; }
    public string Number { get; set; }
    public DateTime Date { get; set; }
    public decimal TotalAmount { get; set; }
    public Guid CustomerId { get; set; }
    public CustomerDb Customer { get; set; }
    public List<PurchaseItemDb> PurchaseItems { get; set; }
}