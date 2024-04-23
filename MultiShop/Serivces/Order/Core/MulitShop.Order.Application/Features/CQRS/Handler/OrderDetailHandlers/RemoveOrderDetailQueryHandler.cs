using MulitShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MulitShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;


namespace MulitShop.Order.Application.Features.CQRS.Handler.OrderDetailHandlers
{
    public class RemoveOrderDetailQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public RemoveOrderDetailQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveOrderDetailCommand removeOrderDetailCommand)
        {
            var value = await _repository.GetByIdAsync(removeOrderDetailCommand.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
