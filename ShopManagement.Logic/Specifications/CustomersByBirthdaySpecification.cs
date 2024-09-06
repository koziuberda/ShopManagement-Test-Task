using Ardalis.Specification;
using ShopManagement.Data.Models;

namespace ShopManagement.Logic.Specifications;

public class CustomersByBirthdaySpecification : Specification<CustomerDb>
{
    public CustomersByBirthdaySpecification(DateTime date)
    {
        Query.Where(x => x.BirthDate.Date.Equals(date.Date));
    }
}