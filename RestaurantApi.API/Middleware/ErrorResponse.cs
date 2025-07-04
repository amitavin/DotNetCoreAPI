namespace RestaurantApi.API.Middleware
{
    /// <summary>
    /// Model used to represent error details returned to the client.
    /// </summary>
    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string? StackTrace { get; set; }
    }
}
