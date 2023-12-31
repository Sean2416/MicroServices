using Mongo.Web.Models;

namespace Mongo.Web.Service.IService
{
    public interface ICouponService
    {
        Task<ResponseDto> GetCouponAsync(string id);
        Task<ResponseDto> GetAllCouponsAsync();
        Task<ResponseDto> CreateCouponAsync(CouponDto req);
    }
}
