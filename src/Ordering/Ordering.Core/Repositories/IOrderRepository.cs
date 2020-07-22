using System.Collections.Generic;
using System.Threading.Tasks;
using Ordering.Core.Entities;
using Ordering.Core.Repositories.Base;

namespace Ordering.Core.Repositories
{
    interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByUsername(string username);
    }
}
