using System.Diagnostics.CodeAnalysis;
using FluentValidation.Results;

namespace FrontDeskApp.Application.Common.Exceptions;

/// <summary>
/// An exception object when of one of the validations failed.
/// </summary>
[ExcludeFromCodeCoverage]
internal class ValidationException : Exception
{
	public IDictionary<string, string[]> Errors { get; }

	public ValidationException()
		: base("One or more validation failures have occurred.")
	{
		Errors = new Dictionary<string, string[]>();
	}

	public ValidationException(
		IEnumerable<ValidationFailure> failure)
		: this()
	{
		Errors = failure
			.GroupBy(_ => _.PropertyName, _ => _.ErrorMessage)
			.ToDictionary(failureGrp => failureGrp.Key, failureGrp => failureGrp.ToArray());
	}
}
