using ToDoApp.Models;

namespace ToDoApp.Responses;

public class ResponseBase<TData>(TData? data, bool isSuccess, string? message = null)
{
    public TData? Data { get; set; } = data;
    public bool IsSuccess { get; set; } = isSuccess;
    public string? Message { get; set; } = message;
}