using Domain.Common;

namespace Domain;
public class TodoItem : BaseEntity
{
	public string Title { get; set; } = null!;
	public bool IsCompleted { get; set; }
}
