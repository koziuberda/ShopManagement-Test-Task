using ShopManagement.Data.Models;
using ShopManagement.Data.Repositories.Results;
using ShopManagement.Logic.Models;
using ShopManagement.Logic.Responses.AllCustomers;
using ShopManagement.Logic.Responses.Birthday;
using ShopManagement.Logic.Responses.FavoriteCategories;

namespace ShopManagement.Logic.Mapping;

public static class CustomerMapper
{
    public static CustomerModel MapInfo(CustomerDb obj) => new ()
    {
        Id = obj.Id,
        FullName = obj.FullName,
        BirthDate = obj.BirthDate,
        RegistrationDate = obj.RegistrationDate
    };
    
    public static BirthdayCustomerModel MapToBirthdayModel(CustomerDb obj) 
        => new BirthdayCustomerModel(obj.Id, obj.FullName);

    public static CustomerCategoryModel Map(CategoryGroupResultDb obj) =>
        new(obj.Category.ToString(), obj.TotalQuantity);
}