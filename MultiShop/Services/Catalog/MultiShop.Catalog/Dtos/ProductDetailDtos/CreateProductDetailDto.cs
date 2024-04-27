namespace MultiShop.Catalog.Dtos.ProductDetailDtos
{
    public record CreateProductDetailDto
    {
        public string ProductDescription { get; init; }
        public string ProductInfo { get; init; }
        public string ProductId { get; init; }
    }
}
