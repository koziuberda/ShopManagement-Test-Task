using ShopManagement.Logic.Models;

namespace ShopManagement.Logic.Responses.CustomerPurchases;

public record CustomerPurchasesResponse(Guid customerId, List<Purchase> purchases);