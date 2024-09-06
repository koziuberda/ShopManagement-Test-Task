namespace ShopManagement.Data.Models;

public class CustomerDb
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime RegistrationDate { get; set; }
    public List<PurchaseDb> Purchases { get; set; }
}