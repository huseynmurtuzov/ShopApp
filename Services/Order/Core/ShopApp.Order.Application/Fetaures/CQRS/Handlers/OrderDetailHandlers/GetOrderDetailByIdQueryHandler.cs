using ShopApp.Order.Application.Fetaures.CQRS.Queries.AddressQueries;
using ShopApp.Order.Application.Fetaures.CQRS.Queries.OrderDetailQueries;
using ShopApp.Order.Application.Fetaures.CQRS.Results.AddressResults;
using ShopApp.Order.Application.Fetaures.CQRS.Results.OrderDetailResult;
using ShopApp.Order.Application.Interfaces;
using ShopApp.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Order.Application.Fetaures.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;
        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);
            return new GetOrderDetailByIdQueryResult
            {
                OrderDetailId = value.OrderDetailId,
                ProductAmount = value.ProductAmount,
                ProductTotalPrice = value.ProductTotalPrice,
                ProductPrice = value.ProductPrice,
                ProductName = value.ProductName,
                ProductId = value.ProductId,
                OrderingId = value.OrderingId
            };

        }
    }
}
