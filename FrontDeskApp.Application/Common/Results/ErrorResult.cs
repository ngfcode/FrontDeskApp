using System.Diagnostics.CodeAnalysis;

namespace FrontDeskApp.Application.Common.Results;

/// <summary>
/// An abstract class that contains error messages.
/// </summary>
[ExcludeFromCodeCoverage]
public abstract class ErrorResult
{
	#region Public Data Members
	/// <summary>
	/// A list of error messages.
	/// </summary>
	public List<string> Errors { get; init; }

	/// <summary>
	/// A property that determines if there's an error message in the list.
	/// </summary>
	public bool NoErrors => Errors.Count == 0;
	#endregion

	public ErrorResult()
	{
		Errors = new List<string>();
	}

	/// <summary>
	/// Adds an error message to the list.
	/// </summary>
	/// <param name="message">The actual error message.</param>
	public void AddErrorMessage(
		string message)
	{
		Errors.Add(message);
	}

	/// <summary>
	/// Adds a list of error messages to the list.
	/// </summary>
	/// <param name="errors">The list of error messasges to be added.</param>
	/// <param name="reset">A flag to reset the values of the internal list before adding the new ones, default is false.</param>
	public void AddErrorMessage(
		List<string> errors,
		bool reset = false)
	{
		if (reset)
		{
			Errors.Clear();
		}

		Errors.AddRange(errors);
	}

	public void ClearErrorMessages()
	{
		Errors.Clear();
	}
}
