using MulitShop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using MulitShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;


namespace MulitShop.Order.Application.Features.CQRS.Handler.OrderDetailHandlers
{
    public class GetOrderDetailQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetOrderDetailQueryResult>> Handle() 
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetOrderDetailQueryResult
            {
                OrderDetailId = x.OrderDetailId,
                ProductAmount = x.ProductAmount,
                ProductName = x.ProductName,
                OrderingId = x.OrderingId,
                ProductId = x.ProductId,
                ProductPrice = x.ProductPrice,
                ProductTotalPrice = x.ProductTotalPrice,


            }).ToList();
        }


    }
}
