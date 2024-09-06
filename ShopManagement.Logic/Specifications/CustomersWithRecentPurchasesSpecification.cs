using System.Linq.Expressions;
using Ardalis.Specification;
using ShopManagement.Data.Models;
using ShopManagement.Logic.Responses.LastCustomers;

namespace ShopManagement.Logic.Specifications;

public class CustomersWithRecentPurchasesSpecification : Specification<CustomerDb, LastCustomerModel>
{
    public CustomersWithRecentPurchasesSpecification(int nLastDays)
    {
        var fromDate = DateTime.Now.AddDays(-nLastDays);
        Query.Where(x => x.Purchases.Any(p => p.Date >= fromDate));
        Query.Select(x => new LastCustomerModel(
            x.Id,
            x.FullName,
            x.Purchases.OrderByDescending(p => p.Date).First().Date)
        );
    }
}