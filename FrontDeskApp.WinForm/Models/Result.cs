using System.Diagnostics.CodeAnalysis;

namespace FrontDeskApp.WinForm.Models;

/// <summary>
/// A return object to signifies a successful transactions, or not.
/// </summary>
[ExcludeFromCodeCoverage]
public sealed class Result
{
	public bool IsSuccessful { get; set; }
	public IList<string> Errors { get; set; }

	internal Result()
	{
		IsSuccessful = true;
		Errors = new List<string>();
	}

	internal Result(
		bool successful,
		IList<string> errors)
	{
		IsSuccessful = successful;
		Errors = errors;
	}

	public static Result Success()
	{
		return new Result();
	}

	public static Result Failure(
		IList<string> errors)
	{
		return new Result(false, errors);
	}

	public static Result Failure(
		string error)
	{
		return new Result(false,
			new List<string> { error });
	}
}
