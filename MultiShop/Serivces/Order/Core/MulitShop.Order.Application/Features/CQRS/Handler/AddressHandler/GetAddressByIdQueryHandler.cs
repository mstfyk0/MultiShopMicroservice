using MulitShop.Order.Application.Features.CQRS.Querys.AddresQuerys;
using MulitShop.Order.Application.Features.CQRS.Results.AddressResults;
using MulitShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MulitShop.Order.Application.Features.CQRS.Handler.AddressHandler
{
    public class GetAddressByIdQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressByIdQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery getAddressByIdQuery)
        {
            var values = await _repository.GetByIdAsync(getAddressByIdQuery.Id);
            return new GetAddressByIdQueryResult
            {
                AddressId = values.AddressId,
                City = values.City,
                District = values.District,
                Detail = values.Detail,
                UserId= values.UserId,
            };
        }
    }
}
