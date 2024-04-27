﻿namespace MultiShop.Discount.Dtos
{
    public record UpdateDiscountCouponDto
    {
        public int CouponId { get; init; }
        public string Code { get; init; }
        public int Rate { get; init; }
        public bool IsActive { get; init; }
        public DateTime ValiedDate { get; init; }
    }
}
