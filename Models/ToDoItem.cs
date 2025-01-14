namespace ToDoApp.Models;

public class ToDoItem(int id, string title, string description, bool isCompleted)
{
    public int Id { get; set; } = id;

    public string Title { get; set; } = title;

    public string Description { get; set; } = description;

    public bool IsCompleted { get; set; } = isCompleted;
}