﻿namespace MultiShop.DtoLayer.CatalogDtos.ProductImageDtos
{
    public record GetByIdProductImageDto
    {
        public string ProductImageId { get; init; }
        public string Image { get; init; }
        public string ProductId { get; init; }
    }
}
