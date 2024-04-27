namespace MultiShop.Catalog.Dtos.CategoryDtos
{
    public record UpdateCategoryDto
    {
        public string CategoryId { get; init; }

        public string CategoryName { get; init; }
    }
}
