using System.Text.Json;
using API.Data;
using Core.Entities;

namespace Infrastructure.Data.SeedData
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context){
            if (!context.ProductsBrands.Any()){
                var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                context.ProductsBrands.AddRange(brands);
            
            }

             if (!context.ProductTypes.Any()){
                var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                var brands = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                context.ProductTypes.AddRange(brands);
            
            }

             if (!context.Products.Any()){
                var productData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                var brands = JsonSerializer.Deserialize<List<Product>>(productData);
                context.Products.AddRange(brands);
            }

            if (context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
        }    
    }
}