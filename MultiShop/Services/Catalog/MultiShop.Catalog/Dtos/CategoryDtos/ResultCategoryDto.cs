namespace MultiShop.Catalog.Dtos.CategoryDtos
{
    public record ResultCategoryDto
    {
        public string CategoryId { get; init; }
        public string CategoryName { get; init; }
        public string ImageUrl { get; init; }

    }
}
