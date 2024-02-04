using System.ComponentModel.DataAnnotations;

namespace Mango.Services.CouponApi.Models
{
    public class Coupon
    {
        /// <summary>
        /// Индификатор
        /// </summary>
        [Key]
        public int CouponId { get; set; }
        /// <summary>
        /// Код купона
        /// </summary>
        [Required]
        public string CouponCode { get; set; }
        /// <summary>
        /// Скидка
        /// </summary>
        [Required]
        public double DiscountAmount { get; set; }
        /// <summary>
        /// Минимальное количество
        /// </summary>
        public int MinAmount { get; set; }

    }
}
