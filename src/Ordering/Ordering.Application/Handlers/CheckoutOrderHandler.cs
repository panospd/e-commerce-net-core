﻿using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Ordering.Application.Commands;
using Ordering.Application.Mapper;
using Ordering.Application.Responses;
using Ordering.Core.Entities;
using Ordering.Core.Repositories;

namespace Ordering.Application.Handlers
{
    public class CheckoutOrderHandler : IRequestHandler<CheckoutOrderCommand, OrderResponse>
    {
        private readonly IOrderRepository _repository;

        public CheckoutOrderHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<OrderResponse> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            var orderEntity = OrderMapper.Mapper.Map<Order>(request);

            if (orderEntity == null)
            {
                throw new ApplicationException("not mapped");
            }

            var newOrder = await _repository.AddAsync(orderEntity);

            return OrderMapper.Mapper.Map<OrderResponse>(newOrder);
        }
    }
}
 