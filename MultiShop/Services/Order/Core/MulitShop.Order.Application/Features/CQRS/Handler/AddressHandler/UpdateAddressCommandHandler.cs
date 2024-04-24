﻿using MulitShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MulitShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MulitShop.Order.Application.Features.CQRS.Handler.AddressHandler
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateAddressCommand updateAddressCommand)
        {
            var  values= await _repository.GetByIdAsync(updateAddressCommand.AddressId);
            values.Detail=updateAddressCommand.Detail;
            values.District=updateAddressCommand.District;
            values.City=updateAddressCommand.City;
            values.UserId=updateAddressCommand.UserId;
            await _repository.UpdateAsync(values);
        }
    }
}
