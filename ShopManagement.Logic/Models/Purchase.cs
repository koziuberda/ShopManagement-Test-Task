namespace ShopManagement.Logic.Models;

public class Purchase
{
    public Guid Id { get; set; }
    public string Number { get; set; }
    public DateTime Date { get; set; }
    public decimal TotalAmount { get; set; }
    public List<PurchaseItem> PurchaseItems { get; set; }
}