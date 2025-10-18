using Application.Common.Interfaces;
using MediatR;

namespace Application.TodoItems.Commands.CreateTodoItem;

public record CreateTodoItemCommand : IRequest<int>
{
    public string Title { get; init; } = string.Empty;
}

public class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateTodoItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
    {
        var todoItem = new Domain.TodoItem
        {
            Title = request.Title,
            IsCompleted = false
        };
        _context.TodoItems.Add(todoItem);
        await _context.SaveChangesAsync(cancellationToken);
        return todoItem.Id;
	}
}
