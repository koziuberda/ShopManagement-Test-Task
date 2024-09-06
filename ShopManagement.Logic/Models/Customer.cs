namespace ShopManagement.Logic.Models;

public class Customer
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime RegistrationDate { get; set; }
    public List<Purchase> Purchases { get; set; }
}