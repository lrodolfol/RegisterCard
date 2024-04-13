namespace RegisterCard.Application.Model;
public class BaseResult
{
    public BaseResult(string? message, bool success = true, int statusCode = 200)
    {
        Success = success;
        if(message is not null)
            Message.Add(message);
        StatusCode = statusCode;
    }
    public BaseResult(int statusCode = 200, bool success = true, List<string>? messages = null)
    {
        if(messages is not null)
            Message = messages;
        Success = success;
        StatusCode = statusCode;
    }
    public int StatusCode { get; set; }
    public bool Success { get; private set; }
    public List<string> Message { get; private set; } = new();
}

public class BaseResult<T> : BaseResult
{
    public BaseResult(T data, bool success = true, string message = "", int statusCode = 200) 
        : base(message, success, statusCode)
    {
        Data = data;
    }

    public BaseResult(T data, List<string> messages, bool success = true, int statusCode = 200)
    : base(statusCode, success, messages)
    {
        Data = data;
    }

    public T Data { get; private set; }
}
