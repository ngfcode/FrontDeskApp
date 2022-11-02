using System.Diagnostics.CodeAnalysis;

namespace FrontDeskApp.Application.Common.Results;

/// <summary>
/// A return object based from a command transaction.
/// </summary>
/// <typeparam name="T">The object type to be returned.</typeparam>
[ExcludeFromCodeCoverage]
public class DtoResult<T> : ErrorResult
{
	public T Dto { get; set; }

	public DtoResult()
	{
	}

	public DtoResult(
		T dto)
	{
		Dto = dto;
	}

	public DtoResult(
		string errorMessage)
	{
		AddErrorMessage(errorMessage);
	}

	public DtoResult(
		List<string> errors)
	{
		AddErrorMessage(errors);
	}
}
