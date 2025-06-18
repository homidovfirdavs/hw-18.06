using System.Net;

namespace Domain.ApiResponses;

public class Responce<T>
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public T? Data { get; set; }
    public int StatusCode { get; set; }

    public Responce(T? data, string message)
    {
        IsSuccess = true;
        Message = message;
        Data = data;
        StatusCode = 200;
    }

    public Responce(string message, HttpStatusCode statusCode)
    {
        IsSuccess = false;
        Message = message;
        StatusCode = (int)statusCode;
        Data = default;
    }
    
}