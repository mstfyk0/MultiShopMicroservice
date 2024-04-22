using System.ComponentModel.DataAnnotations;

namespace MultiShop.Discount.Entities
{
    public class Coupons
    {
        [Key]
        public int CouponId { get; set; }
        public string Code { get; set; }
        public int Rate{ get; set; }
        public bool IsActive { get; set; }
        public DateTime ValiedDate{ get; set; }
    }
}
