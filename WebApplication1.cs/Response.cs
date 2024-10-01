namespace WebApplication1.Services
{
    public class Response<T>
    {
        
        public Response(string message, bool success, T data)
        {
            Message = message;
            Success = success;
            Data = data;
        }

        public string Message { get; set; }
        public bool Success { get; }
        public T Data { get; }
    }
}
