using Ardalis.Specification;

namespace ShopManagement.Data.Repositories.Interfaces;

public interface IRepository<T> : IRepositoryBase<T> where T : class
{
    
}