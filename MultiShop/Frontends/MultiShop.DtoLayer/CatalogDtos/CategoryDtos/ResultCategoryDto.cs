using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DtoLayer.CatalogDtos.CategoryDtos
{
    public record ResultCategoryDto
    {
        public string CategoryId { get; init; }
        public string CategoryName { get; init; }
        public string ImageUrl { get; init; }

    }
}
