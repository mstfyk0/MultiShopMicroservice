using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos
{
    public record CreateCargoDetailDto
    {
        public string SenderCustomer { get; init; }
        public string ReceiverCustomer { get; init; }
        public int Barcode { get; init; }
        public int CargoCompanyId { get; init; }
    }
}
