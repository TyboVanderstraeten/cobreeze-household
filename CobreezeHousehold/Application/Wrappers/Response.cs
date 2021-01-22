namespace Application.Wrappers
{
    public class Response<T>
    {
        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }
        public string Message { get; set; }

        public Response(T data, string message = null)
        {
            Succeeded = true;
            Message = message;
            Errors = null;
            Data = data;
        }
    }
}
