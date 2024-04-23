namespace MultiShop.Discount.Dtos
{
    public class GetByIdDiscountCoutponDto
    {
        public int CouponId { get; set; }
        public string Code { get; set; }
        public int Rate { get; set; }
        public bool IsActive { get; set; }
        public DateTime ValiedDate { get; set; }
    }
}
