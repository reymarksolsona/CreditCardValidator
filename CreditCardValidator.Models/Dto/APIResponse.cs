using System.Net;

namespace CreditCardValidator.Models.Dto
{
    public class APIResponse<T>
    {
        public T Data { get; set; }
        public List<string> Errors { get; set; }
        public bool HasError { get; set; } = false;
        public HttpStatusCode StatusCode { get; set; }

        public APIResponse()
        {
            Data = default(T);
            Errors = new List<string>();
            StatusCode = HttpStatusCode.OK;
        }
    }
}
