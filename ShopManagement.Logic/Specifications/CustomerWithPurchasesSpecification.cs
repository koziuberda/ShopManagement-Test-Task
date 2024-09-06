using Ardalis.Specification;
using ShopManagement.Data.Models;

namespace ShopManagement.Logic.Specifications;

public class CustomerWithPurchasesSpecification : Specification<CustomerDb>
{
    public CustomerWithPurchasesSpecification(Guid customerId)
    {
        Query
            .Where(c => c.Id == customerId)
            .Include(c => c.Purchases)
            .ThenInclude(p => p.PurchaseItems)
            .ThenInclude(p => p.Product);
    }
}