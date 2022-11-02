using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace FrontDeskApp.Infrastructure.Mappings;

[ExcludeFromCodeCoverage]
public static class DataMapping
{
	public static IServiceCollection AddMappings(
		this IServiceCollection services)
	{
		var config = TypeAdapterConfig.GlobalSettings;
		config.Scan(Assembly.GetExecutingAssembly());

		services.AddSingleton(config);
		services.AddScoped<IMapper, ServiceMapper>();

		return services;
	}
}
