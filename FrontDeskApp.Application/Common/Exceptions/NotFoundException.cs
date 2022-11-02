using System.Diagnostics.CodeAnalysis;

namespace FrontDeskApp.Application.Common.Exceptions;

/// <summary>
/// An exception object if an entity is not found.
/// </summary>
[ExcludeFromCodeCoverage]
internal class NotFoundException : Exception
{
	public NotFoundException()
		: base()
	{
	}

	public NotFoundException(
		string message)
		: base(message)
	{
	}

	public NotFoundException(
		string message,
		Exception innerException)
		: base(message, innerException)
	{
	}

	public NotFoundException(
		string name,
		object key)
		: base($"Entity \"{name}\" ({key}) was not found.")
	{
	}
}
