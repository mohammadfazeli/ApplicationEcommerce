using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Collections.Generic;
using Core.Entites;
using System;

namespace Infrastructure.Data
{
    public static class StoreContextSeedData
    {
        public static async Task SeedData(StoreContext storeContext, ILoggerFactory loggerFactory)
        {
            try
            {
                await SeedBrandData(storeContext);
                await SeedProductTypeData(storeContext);
                await SeedProductData(storeContext);
            }
            catch (Exception ex)
            {

                    throw ex;
            }
        }

        private static async Task SeedBrandData(StoreContext context)
        {
            if (!context.Brands.Any())
            {
                var jsonData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                var data = JsonSerializer.Deserialize<List<Brand>>(jsonData);
                await context.AddRangeAsync(data);
                await context.SaveChangesAsync();
            }
        }

        private static async Task SeedProductTypeData(StoreContext context)
        {
            if (!context.productTypes.Any())
            {
                var jsonData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                var data = JsonSerializer.Deserialize<List<ProductType>>(jsonData);
                await context.AddRangeAsync(data);
                await context.SaveChangesAsync();
            }
        }

        private static async Task SeedProductData(StoreContext context)
        {
            if (!context.Products.Any())
            {
                var brandData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                var brands = JsonSerializer.Deserialize<List<Product>>(brandData);
                await context.AddRangeAsync(brands);
                await context.SaveChangesAsync();
            }
        }
    }
}