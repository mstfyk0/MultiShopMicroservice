namespace MultiShop.Catalog.Dtos.ProductImageDtos
{
    public record CreateProductImageDto
    {
        public string Image1 { get; init; }
        public string Image2 { get; init; }
        public string Image3 { get; init; }
        public string ProductId { get; init; }
    }
}
