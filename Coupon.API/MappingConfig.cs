using AutoMapper;
using Coupon.API.Models.Dto;

namespace Coupon.API
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDto, Models.Coupon>();
                config.CreateMap<Models.Coupon, CouponDto>();
            });  

            return mappingConfig;
        }
    }
}
