using System.Diagnostics.CodeAnalysis;
using FrontDeskApp.Application.Common.Extensions;
using FrontDeskApp.Shared.Constants;
using FluentValidation;

namespace FrontDeskApp.Application.Accounts.Commands.ForgotPassword;

/// <summary>
/// Validator for the forgot password command.
/// </summary>
[ExcludeFromCodeCoverage]
internal sealed class ForgotPasswordCommandValidator : AbstractValidator<ForgotPasswordCommand>
{
	public ForgotPasswordCommandValidator()
	{
		RuleFor(_ => _.Email)
			.Cascade(CascadeMode.Stop)
			.NotEmptyNotNull(string.Format(ErrorMessages.Required, AccountDto.Label.Email))
			.EmailAddress()
			.WithMessage(ErrorMessages.EmailInvalid);
	}
}
