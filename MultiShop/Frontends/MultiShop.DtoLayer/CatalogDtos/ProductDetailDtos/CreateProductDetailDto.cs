namespace MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos
{
    public record CreateProductDetailDto
    {
        public string ProductDescription { get; init; }
        public string ProductInfo { get; init; }
        public string ProductId { get; init; }
    }
}
