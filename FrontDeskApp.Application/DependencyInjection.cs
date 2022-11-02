using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using FrontDeskApp.Application.Common.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FrontDeskApp.Application;

[ExcludeFromCodeCoverage]
public static class DependencyInjection
{
	public static IServiceCollection AddApplication(
		this IServiceCollection services)
	{
		services
			.AddMediatR(Assembly.GetExecutingAssembly())
			.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
			.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

		return services;
	}
}
