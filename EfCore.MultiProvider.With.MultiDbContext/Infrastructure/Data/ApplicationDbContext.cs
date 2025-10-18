using Application.Common.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data;
public class ApplicationDbContext<T> : DbContext, IApplicationDbContext where T : DbContext
{
	public ApplicationDbContext(DbContextOptions<T> options) : base(options) { }
	
	public DbSet<TodoItem> TodoItems => Set<TodoItem>();
	
	protected override void OnModelCreating(ModelBuilder builder)
	{
		builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

		base.OnModelCreating(builder);
	}
}

public class SqlServerApplicationDbContext : ApplicationDbContext<SqlServerApplicationDbContext>
{
	public SqlServerApplicationDbContext(DbContextOptions<SqlServerApplicationDbContext> options) : base(options) { }
}

public class PostgreSqlApplicationDbContext : ApplicationDbContext<PostgreSqlApplicationDbContext>
{
	public PostgreSqlApplicationDbContext(DbContextOptions<PostgreSqlApplicationDbContext> options) : base(options) { }
}