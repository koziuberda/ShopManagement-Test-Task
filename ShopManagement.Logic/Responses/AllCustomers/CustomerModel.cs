namespace ShopManagement.Logic.Responses.AllCustomers;

public class CustomerModel
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime RegistrationDate { get; set; }
}