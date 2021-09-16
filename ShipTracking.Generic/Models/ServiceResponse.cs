using System.Net;

namespace ShipTracking.Generic.Models
{
    public class SearchModel
    {
        public enum SearchOperator
        {
            EqualTo = 1, NotEqualTo, BeginsWith, EndsWith, Contains, DoesNotContains, GreaterThan, LessThan
        }

        public string Name { get; set; }
        public string Value { get; set; }
        public int OperatorId { get; set; }
    }

    public class ApiRequest
    {
        public string ApiRequestUrl { get; set; }
    }

    public class ApiRequest<T> : ApiRequest where T : class, new()
    {
        public ApiRequest()
        {
            data = new T();
        }

        public T data { get; set; }
    }

    public class ApiResponse
    {
        public bool IsSuccess { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string Code { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
    }

    public sealed class ApiResponse<T> : ApiResponse
    {
        public T data { get; set; }
    }
}
