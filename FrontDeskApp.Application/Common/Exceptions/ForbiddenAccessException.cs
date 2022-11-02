using System.Diagnostics.CodeAnalysis;

namespace FrontDeskApp.Application.Common.Exceptions;

/// <summary>
/// An exception object for unauthorized access.
/// </summary>
[ExcludeFromCodeCoverage]
internal class ForbiddenAccessException : Exception
{
	public ForbiddenAccessException()
		: base()
	{
	}
}
