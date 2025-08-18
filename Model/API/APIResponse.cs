using System.Net;

namespace Model.API
{
    public class APIResponse<T>
    {
        public T? Data { get; set; }
        public string? Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public bool Success { get; set; }
        public bool ServiceStatus { get; set; }
        public APIException? Error { get; set; }

    }
    public class Response
    {

        public string? Message { get; set; } = "Sorry";
        public HttpStatusCode StatusCode { get; set; }

        public bool Success { get; set; }
        public bool ServiceStatus { get; set; }
        public APIException? Error { get; set; }
    }
    public class Response<T>
    {
        public T? Data { get; set; }
        public string? Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public bool Success { get; set; }
        public bool ServiceStatus { get; set; }
        public APIException? Error { get; set; }

    }
}
