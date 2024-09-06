using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Data.Database;
using ShopManagement.Data.Models;
using ShopManagement.Data.Repositories.Interfaces;

namespace ShopManagement.Data.Repositories;

public class CustomerRepository : RepositoryBase<CustomerDb>, ICustomerRepository
{
    public CustomerRepository(ShopDbContext dbContext) : base(dbContext)
    {
    }
}