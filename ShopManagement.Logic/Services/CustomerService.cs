using ShopManagement.Data.Repositories.Interfaces;
using ShopManagement.Logic.Mapping;
using ShopManagement.Logic.Responses.Birthday;
using ShopManagement.Logic.Responses.FavoriteCategories;
using ShopManagement.Logic.Responses.LastCustomers;
using ShopManagement.Logic.Services.Interfaces;
using ShopManagement.Logic.Specifications;

namespace ShopManagement.Logic.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IPurchaseRepository _purchaseRepository;
    
    public CustomerService(
        ICustomerRepository customerRepository, 
        IPurchaseRepository purchaseRepository)
    {
        _customerRepository = customerRepository;
        _purchaseRepository = purchaseRepository;
    }

    public async Task<BirthdayResponse> GetCustomersByBirthdayAsync(DateTime date)
    {
        var birthdaySpecification = new CustomersByBirthdaySpecification(date);
        var customers = await _customerRepository.ListAsync(birthdaySpecification);
        var customerDtos = customers.Select(CustomerMapper.MapToBirthdayModel).ToList();
        return new BirthdayResponse(customerDtos);
    }

    public async Task<LastCustomersResponse> GetCustomersWithRecentPurchasesAsync(int nLastDays)
    {
        var lastCustomersSpecification = new CustomersWithRecentPurchasesSpecification(nLastDays);
        var lastCustomerModels = await _customerRepository.ListAsync(lastCustomersSpecification);
        return new LastCustomersResponse(lastCustomerModels);
    }

    public async Task<FavoriteCategoriesResponse> GetFavoriteCategoriesAsync(Guid customerId)
    {
        var categoryGroups = await _purchaseRepository.GetPopularCategoriesByCustomerAsync(customerId);
        var categoriesDto = categoryGroups.Select(CustomerMapper.Map).ToList();
        return new FavoriteCategoriesResponse(customerId, categoriesDto);
    }
}