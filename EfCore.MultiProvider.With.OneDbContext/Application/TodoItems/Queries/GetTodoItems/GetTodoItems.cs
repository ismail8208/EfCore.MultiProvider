using Application.Common.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.TodoItems.Queries.GetTodoItems;

public record GetTodoItemsQuery : IRequest<List<TodoItem>>;
public class GetTodoItemsQueryHandler : IRequestHandler<GetTodoItemsQuery, List<TodoItem>>
{
    private readonly IApplicationDbContext _context;

    public GetTodoItemsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<TodoItem>> Handle(GetTodoItemsQuery request, CancellationToken cancellationToken)
    {
        var todoItems = await _context.TodoItems.ToListAsync(cancellationToken);
        return todoItems;
	}
}
