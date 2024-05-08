using MultiShop.Catalog.Dtos.CategoryDtos;

namespace MultiShop.Catalog.Dtos.ProductDtos
{
    public record ResultProductsOneCategoryDto
    {
        public string ProductId { get; init; }
        public string ProductName { get; init; }
        public decimal ProductPrice { get; init; }
        public string ProductImageUrl { get; init; }
        public string ProductDescription { get; init; }
        public string CategoryId { get; init; }
        public ResultCategoryDto Category { get; init; }
    }
}
