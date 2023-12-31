namespace Coupon.API.Models.Dto
{
    public class ResponseDto<T>
    {
        public T? Data { get; set; }

        public bool IsSuccess { get; set; } = true;

        public string ErrMsg { get; set; } = "";
    }
}
