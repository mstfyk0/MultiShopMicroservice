namespace MultiShop.Catalog.Dtos.BrandDtos
{
    public record CreateBrandDto
    {
        public string BrandName { get; init; }
        public string BrandImageUrl { get; init; }
    }
}
