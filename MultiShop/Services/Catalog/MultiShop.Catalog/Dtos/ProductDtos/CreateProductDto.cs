namespace MultiShop.Catalog.Dtos.ProductDtos
{
    public record CreateProductDto
    {   
        public string ProductName { get; init; }
        public decimal ProductPrice { get; init; }
        public string ProductImageUrl { get; init; }
        public string ProductDescription { get; init; }
        public string CategoryId { get; init; }
    }
}
