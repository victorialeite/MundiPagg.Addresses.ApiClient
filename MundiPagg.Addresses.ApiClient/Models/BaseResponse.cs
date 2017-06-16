using System.Net;

namespace MundiPagg.Addresses.ApiClient.Models
{
    public class BaseResponse<T>
    {
        public HttpStatusCode StatusCode { get; set; }

        public bool IsSuccess { get; set; }

        public T Data { get; set; }
    }
}
