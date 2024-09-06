using ShopManagement.Logic.Responses.AllCustomers;
using ShopManagement.Logic.Responses.Birthday;
using ShopManagement.Logic.Responses.CustomerPurchases;
using ShopManagement.Logic.Responses.FavoriteCategories;
using ShopManagement.Logic.Responses.LastCustomers;

namespace ShopManagement.Logic.Services.Interfaces;

public interface ICustomerService
{
    Task<AllCustomersResponse> GetAllCustomers();
    Task<BirthdayResponse> GetCustomersByBirthdayAsync(DateTime date);
    Task<LastCustomersResponse> GetCustomersWithRecentPurchasesAsync(int nLastDays);
    Task<FavoriteCategoriesResponse> GetFavoriteCategoriesAsync(Guid customerId);
    Task<CustomerPurchasesResponse> GetCustomerPurchasesAsync(Guid customerId);
}