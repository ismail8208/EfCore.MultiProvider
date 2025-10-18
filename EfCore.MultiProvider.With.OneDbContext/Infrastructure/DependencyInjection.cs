using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace Infrastructure.Data;

public static class DependencyInjection
{
	public static void AddInfrastructureServices(this IHostApplicationBuilder builder)
	{

		var settings = builder.Configuration.GetSection(nameof(DatabaseOptions)).Get<DatabaseOptions>();
		_ = settings ?? throw new InvalidOperationException("Database settings are not configured properly.");

		if (settings.Provider.ToUpperInvariant() == DbProviders.MSSQL)
		{
			builder.Services.AddDbContext<SqlServerApplicationDbContext>(options =>
			{
				options.UseSqlServer(settings.ConnectionString);
			});

			builder.Services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<SqlServerApplicationDbContext>());
		}
		else if (settings.Provider.ToUpperInvariant() == DbProviders.POSTGRESQL)
		{
			builder.Services.AddDbContext<PostgreSqlApplicationDbContext>(options =>
			{
				options.UseNpgsql(settings.ConnectionString);
			});

			builder.Services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<PostgreSqlApplicationDbContext>());
		}

	}
}