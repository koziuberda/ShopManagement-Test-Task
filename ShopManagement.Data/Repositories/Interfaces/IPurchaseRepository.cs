using ShopManagement.Data.Models;
using ShopManagement.Data.Repositories.Results;

namespace ShopManagement.Data.Repositories.Interfaces;

public interface IPurchaseRepository : IRepository<PurchaseDb>
{
    Task<List<CategoryGroupResultDb>> GetPopularCategoriesByCustomerAsync(Guid customerId);
}