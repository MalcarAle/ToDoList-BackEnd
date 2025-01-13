using System.Collections;
using ToDoApp.Models;
using ToDoApp.Responses;

namespace ToDoApp.Handlers;

public interface IToDoService
{
    Task<ResponseBase<IEnumerable<ToDoItem>>> GetAllAsync();
    Task<ResponseBase<ToDoItem>> GetByIdAsync(int id);
    Task<ResponseBase<ToDoItem>> AddAsync(ToDoItem item);
    Task<ResponseBase<ToDoItem>> UpdateAsync(int id, ToDoItem item);
    Task<ResponseBase<ToDoItem>> DeleteAsync(int id);
}