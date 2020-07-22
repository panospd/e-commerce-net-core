using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ordering.Core.Entities;

namespace Ordering.Infrastructure.Data
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILoggerFactory loggerFactory, int retry = 0)
        {
            int retryForAvailability = retry;

            try
            {
                orderContext.Database.Migrate();

                if (!orderContext.Orders.Any())
                {
                    orderContext.Orders.AddRange(GetPreconfiguredOrders());

                    await orderContext.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                if (retry < 3)
                {
                    retryForAvailability++;

                    var log = loggerFactory.CreateLogger<OrderContext>();
                    log.LogError(e.Message);

                    await SeedAsync(orderContext, loggerFactory, retryForAvailability);
                }
                Console.WriteLine(e);
                throw;
            }
        }

        private static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>
            {
                new Order
                {
                    Username = "swn",
                    FirstName = "Mehmet",
                    LastName = "Ozkaya",
                    EmailAddress = "azozkme@gmail.com",
                    AddressLine = "Bahcelievler",
                    Country = "Turkey"
                }
            };
        }
    }
}