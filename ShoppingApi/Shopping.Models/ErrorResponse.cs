using System.Net;

namespace Shopping.Models
{
    public class ErrorResponse
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.InternalServerError;

        public string Message { get; set; } = "An unexpected error occurred.";
    }
}