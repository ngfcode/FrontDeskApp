﻿using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using AutoMapper;

namespace FrontDeskApp.Application.Common.Mappings;

/// <summary>
/// An object resposible for mapping different objects.
/// </summary>
[ExcludeFromCodeCoverage]
internal sealed class MappingProfile : Profile
{
	public MappingProfile()
	{
		ApplyMappingFromAssembly(Assembly.GetExecutingAssembly());
	}

	private void ApplyMappingFromAssembly(
		Assembly assembly)
	{
		var types = assembly.GetExportedTypes()
			.Where(t => t.GetInterfaces().Any(i =>
				i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
			.ToList();

		foreach (var type in types)
		{
			var instance = Activator.CreateInstance(type);

			var methodInfo = type.GetMethod("Mapping")
				?? type.GetInterface("IMapFrom`1").GetMethod("Mapping");

			methodInfo?.Invoke(instance, new object[] { this });

		}
	}
}
