namespace MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos
{
    public record UpdateProductDetailDto
    {
        public string ProductDetailId { get; init; }
        public string ProductDescription { get; init; }
        public string ProductInfo { get; init; }
        public string ProductId { get; init; }

    }
}
