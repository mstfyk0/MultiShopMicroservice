namespace MultiShop.Catalog.Dtos.CategoryDtos
{
    public record CreateCategoryDto
    {
        public string CategoryName { get; init; }
        public string ImageUrl { get; init; }

    }
}
