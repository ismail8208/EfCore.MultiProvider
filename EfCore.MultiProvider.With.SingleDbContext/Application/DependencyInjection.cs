using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace Application;

public static class DependencyInjection
{
	public static void AddApplicationServices(this IHostApplicationBuilder builder)
	{
		builder.Services.AddMediatR(cfg => {
			cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
		});
	}
}