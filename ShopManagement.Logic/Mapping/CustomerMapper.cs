using ShopManagement.Data.Models;
using ShopManagement.Data.Repositories.Results;
using ShopManagement.Logic.Models;
using ShopManagement.Logic.Responses.Birthday;
using ShopManagement.Logic.Responses.FavoriteCategories;

namespace ShopManagement.Logic.Mapping;

public static class CustomerMapper
{
    public static BirthdayCustomerModel MapToBirthdayModel(CustomerDb obj) 
        => new BirthdayCustomerModel(obj.Id, obj.FullName);

    public static CustomerCategoryModel Map(CategoryGroupResultDb obj) =>
        new(obj.Category.ToString(), obj.TotalQuantity);
}