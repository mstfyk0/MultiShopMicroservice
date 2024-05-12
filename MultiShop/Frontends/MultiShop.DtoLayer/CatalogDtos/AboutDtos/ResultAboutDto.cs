namespace MultiShop.DtoLayer.CatalogDtos.AboutDtos

{
    public record ResultAboutDto
    {
        public string AboutId { get; init; }
        public string AboutDescription { get; init; }
        public string AboutAddress { get; init; }
        public string AboutEmail { get; init; }
        public string AboutPhone { get; init; }
    }
}
