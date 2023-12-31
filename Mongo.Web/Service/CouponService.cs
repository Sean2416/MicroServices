using Mongo.Web.Models;
using Mongo.Web.Utility;

namespace Mongo.Web.Service.IService
{
    public class CouponService: ICouponService
    {
        private readonly IBaseService _baseService;
        public CouponService(IBaseService baseService)
        { 
            _baseService = baseService;
        }

        public async Task<ResponseDto> GetCouponAsync(string id)
        {
            return await _baseService.SendAsync(new RequestDto { 
                ApiType= SD.ApiType.Get,
                Url = SD.CouponAPIBase+"/api/coupon/"+id
            });        
        }

        public async Task<ResponseDto> GetAllCouponsAsync()
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.Get,
                Url = SD.CouponAPIBase + "/api/coupon"
            });
        }

        public async Task<ResponseDto> CreateCouponAsync(CouponDto req)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.Post,
                Url = SD.CouponAPIBase + "/api/coupon",
                Data = req
            });
        }
    }
}
