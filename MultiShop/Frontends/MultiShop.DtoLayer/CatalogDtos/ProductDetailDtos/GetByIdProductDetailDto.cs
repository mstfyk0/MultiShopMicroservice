namespace MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos
{
    public record GetByIdProductDetailDto
    {
        public string ProductDetailId { get; init; }
        public string ProductDescription { get; init; }
        public string ProductInfo { get; init; }
        public string ProductId { get; init; }


    }
}
