using ShopManagement.Logic.Responses.Birthday;
using ShopManagement.Logic.Responses.FavoriteCategories;
using ShopManagement.Logic.Responses.LastCustomers;

namespace ShopManagement.Logic.Services.Interfaces;

public interface ICustomerService
{
    Task<BirthdayResponse> GetCustomersByBirthdayAsync(DateTime date);
    Task<LastCustomersResponse> GetCustomersWithRecentPurchasesAsync(int nLastDays);
    Task<FavoriteCategoriesResponse> GetFavoriteCategoriesAsync(Guid customerId);
}