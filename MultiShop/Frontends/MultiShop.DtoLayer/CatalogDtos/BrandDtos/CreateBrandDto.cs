namespace MultiShop.DtoLayer.CatalogDtos.BrandDtos
{
    public record CreateBrandDto
    {
        public string BrandName { get; init; }
        public string BrandImageUrl { get; init; }
    }
}
