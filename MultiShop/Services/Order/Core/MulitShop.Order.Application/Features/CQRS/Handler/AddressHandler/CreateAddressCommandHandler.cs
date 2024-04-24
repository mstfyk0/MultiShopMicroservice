using MulitShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MulitShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;


namespace MulitShop.Order.Application.Features.CQRS.Handler.AddressHandler
{
    public class CreateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public CreateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAddressCommand createAddressCommand)
        {
            await _repository.CreateAsync(new Address
            {
                City = createAddressCommand.City,
                District = createAddressCommand.District,
                Detail = createAddressCommand.Detail,
                UserId = createAddressCommand.UserId
            });
        }
    }
}
