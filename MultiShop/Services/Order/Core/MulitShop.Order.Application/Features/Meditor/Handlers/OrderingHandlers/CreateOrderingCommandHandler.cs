using MediatR;
using MulitShop.Order.Application.Features.Meditor.Command.OrderingCommands;
using MulitShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;


namespace MulitShop.Order.Application.Features.Meditor.Handlers.OrderingHandlers
{
    public class CreateOrderingCommandHandler : IRequestHandler<CreateOrderingCommand>
    {

        private readonly IRepository<Ordering> _repository;

        public CreateOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateOrderingCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Ordering
            {
                OrderDate = request.OrderDate,
                TotalPrice = request.TotalPrice,
                UserId = request.UserId,

            });
        }
    }
}
