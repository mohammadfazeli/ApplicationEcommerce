namespace Api.Errors
{
    public class ApiResponse
    {
        public ApiResponse()
        {
        }

        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageByStatusCode(statusCode);
        }

        private string GetDefaultMessageByStatusCode(int statusCode)
        {
            return statusCode switch
            {
                200 => "ok",
                400 => "a bad request",
                401 => "Authorized",
                404 => "not found",
                500 => "Server Error",
                _ => null
            };
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}