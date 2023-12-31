using AutoMapper;
using Coupon.API.Data;
using Coupon.API.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;

namespace Coupon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;


        public CouponController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ResponseDto<List<Models.Coupon>>> Get()
        {
            try
            {
                List<Models.Coupon> list = await _context.Coupons.ToListAsync();

                return new ResponseDto<List<Models.Coupon>>
                {
                    IsSuccess = true,
                    Data = list
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<List<Models.Coupon>>
                {
                    IsSuccess = false,
                    Data = new List<Models.Coupon>(),
                    ErrMsg = ex.Message
                };
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ResponseDto<Models.Coupon>> Get(int id)
        {
            try
            {
                var data = await _context.Coupons.FirstOrDefaultAsync(r => r.CouponId == id);

                return new ResponseDto<Models.Coupon>
                {
                    IsSuccess = data != null,
                    Data = data
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<Models.Coupon>
                {
                    IsSuccess = false,
                    Data = null,
                    ErrMsg = ex.Message
                };
            }
        }

        [HttpPost]
        public async Task<ResponseDto<CouponDto>> Post([FromBody] CouponDto dto)
        {
            try
            {

                var entity = _mapper.Map<Models.Coupon>(dto);

                var r = await _context.Coupons.AddAsync(entity);

                _context.SaveChanges();


                return new ResponseDto<CouponDto>
                {
                    IsSuccess =true,
                    Data = dto
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<CouponDto>
                {
                    IsSuccess = false,
                    ErrMsg = ex.Message,
                    Data = dto
                };
            }
        }

        [HttpPut]
        public async Task<ResponseDto<CouponDto>> Put([FromBody] CouponDto dto)
        {
            try
            {

                var history = await _context.Coupons.FirstOrDefaultAsync(r => r.CouponId == dto.CouponId) ?? throw new Exception("Not Found~~");

                history.CouponCode = dto.CouponCode;
                history.DiscountAmount = dto.DiscountAmount;    
                history.MinAmount = dto.MinAmount;  

                _context.Coupons.Update(history);

                _context.SaveChanges();


                return new ResponseDto<CouponDto>
                {
                    IsSuccess = true,
                    Data = dto
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<CouponDto>
                {
                    IsSuccess = false,
                    ErrMsg = ex.Message,
                    Data = null
                };
            }
        }
    }
}
