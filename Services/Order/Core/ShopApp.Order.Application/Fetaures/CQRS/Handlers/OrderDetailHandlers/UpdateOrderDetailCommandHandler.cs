﻿using ShopApp.Order.Application.Fetaures.CQRS.Commands.AddressCommands;
using ShopApp.Order.Application.Fetaures.CQRS.Commands.OrderDetailCommands;
using ShopApp.Order.Application.Interfaces;
using ShopApp.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Order.Application.Fetaures.CQRS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;
        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderDetailCommand command)
        {
            var value = await _repository.GetByIdAsync(command.OrderDetailId);
            value.OrderDetailId = command.OrderDetailId;
            value.OrderingId = command.OrderingId;
            value.ProductId = command.ProductId;
            value.ProductName = command.ProductName;
            value.ProductPrice = command.ProductPrice;
            value.ProductTotalPrice = command.ProductTotalPrice;
            value.ProductAmount = command.ProductAmount;
            await _repository.UpdateAsync(value);
        }
    }
}
