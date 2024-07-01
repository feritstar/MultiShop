using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponsAsync();
        Task CreateDiscountCouponAsync(CreateDiscountCouponDto coupon);
        Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto coupon);
        Task DeleteDiscountCouponAsync(int couponId);
        Task<GetByIdDİscountCouponDto> GetByIdDiscountCouponAsync(int couponId);
    }
}
