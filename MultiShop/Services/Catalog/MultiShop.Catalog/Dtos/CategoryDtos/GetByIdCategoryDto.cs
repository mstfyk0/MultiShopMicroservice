namespace MultiShop.Catalog.Dtos.CategoryDtos
{
    public record GetByIdCategoryDto
    {
        public string CategoryId { get; init; }
        public string CategoryName { get; init; }
        public string ImageUrl { get; init; }

    }
}
