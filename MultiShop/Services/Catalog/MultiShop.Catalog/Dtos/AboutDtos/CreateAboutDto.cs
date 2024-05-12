namespace MultiShop.Catalog.Dtos.AboutDtos
{
    public record CreateAboutDto
    {
        public string AboutDescription { get; init; }
        public string AboutAddress { get; init; }
        public string AboutEmail { get; init; }
        public string AboutPhone { get; init; }
    }
}
