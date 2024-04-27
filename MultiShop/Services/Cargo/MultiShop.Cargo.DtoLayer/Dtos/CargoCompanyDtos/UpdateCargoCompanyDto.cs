﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DtoLayer.Dtos.CargoCompanyDtos
{
    public record UpdateCargoCompanyDto
    {
        public int CargoCompanyId { get; init; }
        public string CargoCompanyName { get; init; }
    }
}
