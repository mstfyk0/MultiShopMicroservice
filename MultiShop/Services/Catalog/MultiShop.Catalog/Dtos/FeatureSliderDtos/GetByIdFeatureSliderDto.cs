namespace MultiShop.Catalog.Dtos.FeatureSliderDtos
{
    public record GetByIdFeatureSliderDto
    {

        public string FeatureSliderId { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
        public string ImageUrl { get; init; }
        public bool Status { get; init; }
    }
}
