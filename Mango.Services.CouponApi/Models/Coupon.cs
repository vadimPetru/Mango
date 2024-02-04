namespace Mango.Services.CouponApi.Models
{
    public class Coupon
    {
        /// <summary>
        /// Индификатор
        /// </summary>
        public int CouponId { get; set; }
        /// <summary>
        /// Код купона
        /// </summary>
        public string CouponCode { get; set; }
        /// <summary>
        /// Скидка
        /// </summary>
        public double DiscountAmount { get; set; }
        /// <summary>
        /// Минимальное количество
        /// </summary>
        public int MinAmount { get; set; }

    }
}
