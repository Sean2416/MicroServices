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
    public class TestController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public TestController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<ResponseDto<string>> Get()
        {
            return new ResponseDto<string>
            {
                IsSuccess = true,
                Data = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection")
            };
        }

    }
}
