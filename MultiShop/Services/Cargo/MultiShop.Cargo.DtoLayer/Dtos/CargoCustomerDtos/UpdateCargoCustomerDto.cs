using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos
{
    public record UpdateCargoCustomerDto
    {
        public int CargoCustomerId { get; init; }
        public string Name { get; init; }
        public string SurName { get; init; }
        public string Email { get; init; }
        public string Phone { get; init; }
        public string District { get; init; }
        public string City { get; init; }
        public string Address { get; init; }
    }
}
