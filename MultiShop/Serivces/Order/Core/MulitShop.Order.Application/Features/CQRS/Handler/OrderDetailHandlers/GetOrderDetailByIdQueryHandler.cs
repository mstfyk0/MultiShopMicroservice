using MulitShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MulitShop.Order.Application.Features.CQRS.Querys.AddresQuerys;
using MulitShop.Order.Application.Features.CQRS.Querys.OrderDetailQuerys;
using MulitShop.Order.Application.Features.CQRS.Results.AddressResults;
using MulitShop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using MulitShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MulitShop.Order.Application.Features.CQRS.Handler.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery getOrderDetailByIdQuery)
        {
            var values = await _repository.GetByIdAsync(getOrderDetailByIdQuery.Id);
            return new GetOrderDetailByIdQueryResult
            {
                ProductAmount = values.ProductAmount,
                ProductId = values.ProductId,
                ProductName = values.ProductName,
                ProductPrice = values.ProductPrice,
                ProductTotalPrice = values.ProductTotalPrice,
                OrderingId = values.OrderingId,
                OrderDetailId = values.OrderDetailId,
            };
        }
    }
}
