namespace MultiShop.Catalog.Dtos.OfferDiscountDtos
{
    public record CreateOfferDiscountDto
    {
        
        public string OfferDiscountTitle { get; init; }
        public string OfferDiscountSubTitle { get; init; }
        public string OfferDiscountImageUrl { get; init; }
        public string OfferDiscountButtonTitle { get; init; }
    }
}
