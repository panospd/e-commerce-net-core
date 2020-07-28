using System.Collections.Generic;
using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> products)
        {
            bool existProduct = products.Find(p => true).Any();

            if (!existProduct)
            {
                products.InsertManyAsync(GetPreConfiguredProducts());
            }
        }

        private static IEnumerable<Product> GetPreConfiguredProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    Name = "Iphone X",
                    Summary = "This is a great phone by Apple",
                    Description = "Great all glass phone",
                    ImageFile = "product-5.png",
                    Price = 380.00M,
                    Category = "Smart Phone"
                },
                new Product
                {
                    Name = "Huawei P10",
                    Summary = "This is a great phone by Huawei",
                    Description = "Compact phone",
                    ImageFile = "product-6.png",
                    Price = 320.00M,
                    Category = "Smart Phone"
                }
            };
        }
    }
}
