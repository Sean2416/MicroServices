using Mongo.Web.Models;
using Mongo.Web.Service.IService;
using Mongo.Web.Utility;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using static Mongo.Web.Utility.SD;

namespace Mongo.Web.Service
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ResponseDto> SendAsync(RequestDto req)
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient();
                HttpRequestMessage message = new();
                message.Headers.Add("Accept", "application/json");

                message.RequestUri = new Uri(req.Url);

                if (req.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(req.Data), Encoding.UTF8, "application/json");
                }

                HttpResponseMessage? apiResp = null;

                switch (req.ApiType)
                {
                    case ApiType.Post:
                        message.Method = HttpMethod.Post;
                        break;
                    case ApiType.Put:
                        message.Method = HttpMethod.Put;
                        break;
                    case ApiType.Delete:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                apiResp = await client.SendAsync(message);

                if (apiResp.StatusCode != HttpStatusCode.OK)
                    return new() { IsSuccess = false, ErrMsg = "Send API Error!!!" };

                var apiContent = await apiResp.Content.ReadAsStringAsync();
                var dto = JsonConvert.DeserializeObject(apiContent);

                return new() { IsSuccess = true, Data = dto };
            }
            catch (Exception ex)
            {
                return new() { IsSuccess = false, ErrMsg = ex .Message};
            }
        }
    }
}
