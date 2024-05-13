namespace MultiShop.Catalog.Dtos.ProductImageDtos
{
    public record UpdateListProductImageDto
    {
        public string ProductImageId { get; init; }
        public string Image { get; init; }
        public string ProductId { get; init; }
    }
}
