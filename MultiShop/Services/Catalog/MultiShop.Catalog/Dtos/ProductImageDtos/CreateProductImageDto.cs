﻿namespace MultiShop.Catalog.Dtos.ProductImageDtos
{
    public record CreateProductImageDto
    {
        public string Image { get; init; }
        public string ProductId { get; init; }
    }
}
