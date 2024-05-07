namespace MultiShop.Catalog.Dtos.FeatureSliderDtos
{
    public record CreateFeatureSliderDto
    {

        public string Title { get; init; }
        public string Description { get; init; }
        public string ImageUrl { get; init; }
        public bool Status { get; init; }
    }
}
