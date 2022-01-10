namespace Api.Errors
{
    public class ErrorException : ApiResponse
    {
        public ErrorException()
        {
        }

        public ErrorException(int statusCode, string message = null, string detail = "") :
            base(statusCode, message)
        {
            Detail = detail;
        }

        public string Detail { get; set; }
    }
}