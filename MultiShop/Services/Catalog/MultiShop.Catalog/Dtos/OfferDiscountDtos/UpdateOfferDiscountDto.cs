namespace MultiShop.Catalog.Dtos.OfferDiscountDtos
{
    public record UpdateOfferDiscountDto
    {
        public string OfferDiscountId { get; init; }
        public string OfferDiscountTitle { get; init; }
        public string OfferDiscountSubTitle { get; init; }
        public string OfferDiscountImageUrl { get; init; }
        public string OfferDiscountButtonTitle { get; init; }
    }
}
