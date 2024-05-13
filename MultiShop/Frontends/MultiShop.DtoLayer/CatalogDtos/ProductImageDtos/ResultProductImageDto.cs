namespace MultiShop.DtoLayer.CatalogDtos.ProductImageDtos
{
    public record ResultProductImageDto
    {
        public string ProductImageId { get; init; }
        public string Image { get; init; }
        public string ProductId { get; init; }
    }
}
