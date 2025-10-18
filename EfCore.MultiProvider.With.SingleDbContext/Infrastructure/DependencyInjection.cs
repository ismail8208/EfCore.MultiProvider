using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;


namespace Infrastructure.Data;

public static class DependencyInjection
{
	public static void AddInfrastructureServices(this IHostApplicationBuilder builder)
	{
		builder.Services.AddOptions<DatabaseOptions>()
			.BindConfiguration(nameof(DatabaseOptions))
			.PostConfigure(config =>
			{
				Console.WriteLine($"current db provider: {config.Provider}");
			});

		builder.Services.AddDbContext<ApplicationDbContext>((sp, options) =>
		{
			options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());

			var settings = sp.GetRequiredService<IOptions<DatabaseOptions>>();
			var _settings = settings.Value;

			if (_settings.Provider.ToUpperInvariant() == DbProviders.MSSQL)
			{
				options.UseSqlServer(_settings.ConnectionString, x => x.MigrationsAssembly(DbProviders.MSSQLASSEMBLY));
			}
			else if (_settings.Provider.ToUpperInvariant() == DbProviders.POSTGRESQL)
			{
				options.UseNpgsql(_settings.ConnectionString, x => x.MigrationsAssembly(DbProviders.POSTGRESQLASSEMBLY));
			}

		});

		builder.Services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

	}
}