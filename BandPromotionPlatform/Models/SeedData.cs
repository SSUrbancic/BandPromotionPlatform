using BandPromotionPlatform.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandPromotionPlatform.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any products
                if (context.Product.Any())
                {
                    return;   // DB has been seeded
                }

                context.Product.AddRange(
                     new Product
                     {
                         ProductID = 1,
                         ProductName = "T-Shirt",
                         ProductDescription = "Black T-Shirt with white lettering",
                         ProductColor = "Black",
                         ProductSize = "Large",   
                         UnitPrice = 14.99
                     },                                         
                     new Product

                     {
                         ProductID = 2,
                         ProductName = "Hat",
                         ProductDescription = "Dead Gang Hat, white with black logo",
                         ProductColor = "White",
                         ProductSize = "Snapback",
                         UnitPrice = 14.99
                     }
                );
                context.SaveChanges();
            }
        }
    }
}
