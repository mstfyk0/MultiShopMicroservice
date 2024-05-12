﻿namespace MultiShop.DtoLayer.CatalogDtos.BrandDtos
{
    public record UpdateBrandDto
    {
        public string BrandId { get; init; }
        public string BrandName { get; init; }
        public string BrandImageUrl { get; init; }
    }
}
