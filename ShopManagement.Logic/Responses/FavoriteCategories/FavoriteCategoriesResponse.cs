namespace ShopManagement.Logic.Responses.FavoriteCategories;

public record FavoriteCategoriesResponse(Guid Id, List<CustomerCategoryModel> Categories);
