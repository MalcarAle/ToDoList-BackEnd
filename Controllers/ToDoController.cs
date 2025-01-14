using Microsoft.AspNetCore.Mvc;
using ToDoApp.Handlers;
using ToDoApp.Models;

namespace ToDoApp.Controllers;

[Route("v1/todos")]
public class ToDoController(IToDoService toDoService) : ControllerBase
{
    private readonly IToDoService _toDoService = toDoService;

    [HttpGet("")]
    public async Task<IActionResult> GetAll()
    {
        var response = await _toDoService.GetAllAsync();
        return response.IsSuccess
            ? Ok(response.Data)
            : BadRequest(response.Message);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var response = await _toDoService.GetByIdAsync(id);
        return response.IsSuccess
            ? Ok(response.Data)
            : NotFound(response.Message);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Add(ToDoItem item)
    {
        var response = await _toDoService.AddAsync(item);
        return response.IsSuccess
            ? CreatedAtAction(nameof(GetById), new { id = response.Data?.Id }, response)
            : BadRequest(response.Message);
    }

    [HttpPut("update/{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] ToDoItem item)
    {
        var response = await _toDoService.UpdateAsync(id, item);
        return response.IsSuccess
            ? Ok(response.Data)
            : BadRequest(response.Message);
    }

    [HttpDelete("delete/{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _toDoService.DeleteAsync(id);
        return response.IsSuccess
            ? Ok(response.Message)
            : NotFound(response.Message);
    }
}