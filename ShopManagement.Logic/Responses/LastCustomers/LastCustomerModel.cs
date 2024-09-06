namespace ShopManagement.Logic.Responses.LastCustomers;

public record LastCustomerModel(Guid Id, string Fullname, DateTime LastPurchaseDate);