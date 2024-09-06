using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Data.Database;
using ShopManagement.Data.Models;
using ShopManagement.Data.Repositories.Interfaces;
using ShopManagement.Data.Repositories.Results;

namespace ShopManagement.Data.Repositories;

public class PurchaseRepository : RepositoryBase<PurchaseDb>, IPurchaseRepository
{
    private readonly ShopDbContext _dbContext;
    
    public PurchaseRepository(ShopDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<CategoryGroupResultDb>> GetPopularCategoriesByCustomerAsync(Guid customerId)
    {
        var query = await _dbContext.PurchaseItems
            .Where(p => p.Purchase.CustomerId == customerId)
            .GroupBy(p => p.Product.Category)
            .Select(g => new CategoryGroupResultDb
            {
                Category = g.Key,
                TotalQuantity = g.Sum(x => x.Quantity)
            })
            .ToListAsync();

        return query;
    }
}