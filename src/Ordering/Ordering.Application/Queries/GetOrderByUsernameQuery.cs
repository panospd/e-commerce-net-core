using System.Collections.Generic;
using MediatR;
using Ordering.Application.Responses;

namespace Ordering.Application.Queries
{
    public class GetOrderByUsernameQuery : IRequest<IEnumerable<OrderResponse>>
    {
        public GetOrderByUsernameQuery(string username)
        {
            Username = username;
        }

        public string Username { get; }
    }
}
