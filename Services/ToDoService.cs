using Microsoft.EntityFrameworkCore;
using ToDoApp.Data;
using ToDoApp.Handlers;
using ToDoApp.Models;
using ToDoApp.Responses;

namespace ToDoApp.Services;

public class ToDoService(AppDbContext context) : IToDoService
{
    public async Task<ResponseBase<IEnumerable<ToDoItem>>> GetAllAsync()
    {
        var items = await context.ToDoItems.ToListAsync();
        return items.Count > 0
            ? new ResponseBase<IEnumerable<ToDoItem>>(items, true, "Items retrieved successfully")
            : new ResponseBase<IEnumerable<ToDoItem>>(items, false, "Theres no items to show!");
    }

    public async Task<ResponseBase<ToDoItem>> GetByIdAsync(int id)
    {
        var item = await context.ToDoItems.FindAsync(id);
        return item == null
            ? new ResponseBase<ToDoItem>(null, false, "Item was not found!")
            : new ResponseBase<ToDoItem>(item, true, "Item was found");
    }

    public async Task<ResponseBase<ToDoItem>> AddAsync(ToDoItem item)
    {
        if (string.IsNullOrEmpty(item.Title))
            return new ResponseBase<ToDoItem>(null, false, "Title is required");

        await context.ToDoItems.AddAsync(item);
        await context.SaveChangesAsync();

        return new ResponseBase<ToDoItem>(item, true, "Item created successfully!");
    }

    public async Task<ResponseBase<ToDoItem>> UpdateAsync(int id, ToDoItem item)
    {
        var existingItem = await context.ToDoItems.FindAsync(id);
        if (existingItem == null)
            return new ResponseBase<ToDoItem>(existingItem, false, "Item was not found!");

        existingItem.Title = item.Title;
        existingItem.Description = item.Description;
        existingItem.IsCompleted = item.IsCompleted;

        await context.SaveChangesAsync();

        return new ResponseBase<ToDoItem>(existingItem, true, "Item update successfully!");
    }

    public async Task<ResponseBase<ToDoItem>> DeleteAsync(int id)
    {
        var item = await context.ToDoItems.FindAsync(id);
        if (item == null)
            return new ResponseBase<ToDoItem>(item, false, "Item was not found!");

        context.ToDoItems.Remove(item);
        await context.SaveChangesAsync();
        return new ResponseBase<ToDoItem>(null, true, "Item was deleted successfully!");
    }
}