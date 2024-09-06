using Microsoft.EntityFrameworkCore;
using ShopManagement.Core.Enums;
using ShopManagement.Data.Models;

namespace ShopManagement.Data.Database;

public class ShopDbContext : DbContext
{
    public DbSet<CustomerDb> Customers { get; set; } = null!;
    public DbSet<ProductDb> Products { get; set; } = null!;
    public DbSet<PurchaseDb> Purchases { get; set; } = null!;
    public DbSet<PurchaseItemDb> PurchaseItems { get; set; } = null!;

    public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(ShopDbContext).Assembly);
        base.OnModelCreating(builder);

        var products = GetTestProducts();
        var customers = GetTestCustomersData();
        var (purchases, purchaseItems) = GetTestPurchasesWithItems(products, customers);
        
        builder.Entity<ProductDb>().HasData(products);
        builder.Entity<CustomerDb>().HasData(customers);
        builder.Entity<PurchaseDb>().HasData(purchases);
        builder.Entity<PurchaseItemDb>().HasData(purchaseItems);
    }
    

    private ProductDb[] GetTestProducts()
    {
        var products = new ProductDb[]
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Laptop",
                Category = ProductCategory.Electronics,
                SKU = "LPT123",
                Price = 1500m
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Smartphone",
                Category = ProductCategory.Electronics,
                SKU = "SPH456",
                Price = 800m
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Tablet",
                Category = ProductCategory.Electronics,
                SKU = "TBL789",
                Price = 600m
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Office Chair",
                Category = ProductCategory.Furniture,
                SKU = "CH123",
                Price = 120m
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Dining Table",
                Category = ProductCategory.Furniture,
                SKU = "DT456",
                Price = 300m
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Running Shoes",
                Category = ProductCategory.Sports,
                SKU = "RS789",
                Price = 80m
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Basketball",
                Category = ProductCategory.Sports,
                SKU = "BB123",
                Price = 50m
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Blender",
                Category = ProductCategory.KitchenAppliances,
                SKU = "BL123",
                Price = 90m
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Microwave",
                Category = ProductCategory.KitchenAppliances,
                SKU = "MW456",
                Price = 150m
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Vacuum Cleaner",
                Category = ProductCategory.HomeAppliances,
                SKU = "VC123",
                Price = 200m
            }
        };
        
        return products;
    }

    private CustomerDb[] GetTestCustomersData()
    {
        var customers = new CustomerDb[]
        {
            new()
            {
                Id = Guid.NewGuid(),
                FullName = "John Doe",
                BirthDate = new DateTime(1985, 7, 23),
                RegistrationDate = DateTime.Now
            },
            new()
            {
                Id = Guid.NewGuid(),
                FullName = "Jane Smith",
                BirthDate = new DateTime(1990, 11, 5),
                RegistrationDate = DateTime.Now
            },
            new()
            {
                Id = Guid.NewGuid(),
                FullName = "Bill Johnson",
                BirthDate = new DateTime(1975, 2, 13),
                RegistrationDate = DateTime.Now
            },
            new()
            {
                Id = Guid.NewGuid(),
                FullName = "Anna Williams",
                BirthDate = new DateTime(1995, 4, 18),
                RegistrationDate = DateTime.Now
            },
            new()
            {
                Id = Guid.NewGuid(),
                FullName = "George Brown",
                BirthDate = new DateTime(1980, 10, 1),
                RegistrationDate = DateTime.Now
            }
        };
        
        return customers;
    }

    private (PurchaseDb[] purchases, PurchaseItemDb[] purchaseItems) GetTestPurchasesWithItems(
        ProductDb[] products,
        CustomerDb[] customers)
    {
        var random = new Random();
        var purchases = new List<PurchaseDb>();
        var purchaseItems = new List<PurchaseItemDb>();

        foreach (var customer in customers)
        {
            int purchaseCount = random.Next(1, 4);

            for (int i = 0; i < purchaseCount; i++)
            {
                var purchase = new PurchaseDb
                {
                    Id = Guid.NewGuid(),
                    Number = $"ORD{random.Next(1000, 9999)}",
                    CustomerId = customer.Id,
                    Date = DateTime.Now.AddDays(-random.Next(1, 100)),
                    PurchaseItems = new List<PurchaseItemDb>()
                };
                
                int productCount = random.Next(1, 4);
                decimal totalAmount = 0;

                for (int j = 0; j < productCount; j++)
                {
                    var product = products[random.Next(products.Length)];
                    
                    var purchaseItem = new PurchaseItemDb
                    {
                        Id = Guid.NewGuid(),
                        PurchaseId = purchase.Id,
                        ProductId = product.Id,
                        Quantity = random.Next(1, 5)
                    };
                    
                    purchaseItems.Add(purchaseItem);
                    totalAmount += product.Price * purchaseItem.Quantity;
                }
                
                purchase.TotalAmount = totalAmount;
                purchases.Add(purchase);
            }
        }

        return (purchases.ToArray(), purchaseItems.ToArray());
    }
}