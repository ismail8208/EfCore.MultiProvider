using Application.TodoItems.Commands.CreateTodoItem;
using Application.TodoItems.Queries.GetTodoItems;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Web.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TodoItemsController(ISender sender) : ControllerBase
{
	[HttpGet]
	public async Task<List<TodoItem>> GetTodoItems()
	{
		return await sender.Send(new GetTodoItemsQuery());
	}

	[HttpPost]
	public async Task<int> Post([FromBody] string value)
	{
		var command = new CreateTodoItemCommand
		{
			Title = value
		};

		return await sender.Send(command);
	}
}
