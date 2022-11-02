using System.Diagnostics.CodeAnalysis;
using FluentValidation;

namespace FrontDeskApp.Application.Common.Extensions;

[ExcludeFromCodeCoverage]
public static class FluentValidationExtension
{
	public static IRuleBuilderOptions<T, Guid> ValidGuid<T>(
		this IRuleBuilder<T, Guid> ruleBuilder,
		string errorMessage)
	{
		return ruleBuilder.Must(guid => guid != Guid.Empty)
			.WithMessage(errorMessage);
	}

	public static IRuleBuilderOptions<T, string> NotEmptyNotNull<T>(
		this IRuleBuilder<T, string> ruleBuilder,
		string errorMessage)
	{
		return ruleBuilder.Must(paramToEvaluate => !string.IsNullOrWhiteSpace(paramToEvaluate))
			.WithMessage(errorMessage);
	}

	public static IRuleBuilderOptions<T, DateTime> ValidMaximumDate<T>(
		this IRuleBuilderOptions<T, DateTime> ruleBuilder,
		DateTime maxDate,
		string errorMessage)
	{
		return ruleBuilder.Must(paramToEvaluate => paramToEvaluate <= maxDate)
			.WithMessage(errorMessage);
	}

	public static IRuleBuilderOptions<T, DateOnly?> ValidMaximumDateOnly<T>(
		this IRuleBuilderOptions<T, DateOnly?> ruleBuilder,
		DateOnly maxDate,
		string errorMessage)
	{
		return ruleBuilder.Must(paramToEvaluate => paramToEvaluate <= maxDate)
			.When(dateValue => dateValue is object)
			.WithMessage(errorMessage);
	}

	public static IRuleBuilderOptions<T, DateOnly?> NotNull<T>(
		this IRuleBuilderOptions<T, DateOnly?> ruleBuilder,
		string errorMessage)
	{
		return ruleBuilder.Must(paramToEvaluate => paramToEvaluate is not null)
			.WithMessage(errorMessage);
	}
}
