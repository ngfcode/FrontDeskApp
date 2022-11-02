using System.Diagnostics.CodeAnalysis;
using FrontDeskApp.Application.Common.Extensions;
using FrontDeskApp.Shared.Constants;
using FluentValidation;

namespace FrontDeskApp.Application.Accounts.Commands.ResetPassword;

/// <summary>
/// Validator for the reset password command.
/// </summary>
[ExcludeFromCodeCoverage]
internal sealed class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommand>
{
	public ResetPasswordCommandValidator()
	{
		RuleFor(_ => _.Dto.Email)
			.Cascade(CascadeMode.Stop)
			.NotEmptyNotNull(string.Format(ErrorMessages.Required, AccountDto.Label.Email))
			.EmailAddress()
			.WithMessage(ErrorMessages.EmailInvalid);

		RuleFor(_ => _.Dto.EmailConfirmationToken)
			.Cascade(CascadeMode.Stop)
			.NotEmptyNotNull(string.Format(ErrorMessages.Required, AccountDto.Label.EmailToken));

		RuleFor(_ => _.Dto.Password)
			.Cascade(CascadeMode.Stop)
			.NotEmptyNotNull(string.Format(ErrorMessages.Required, AccountDto.Label.Password))
			.Matches(DefaultValues.PasswordFormat)
			.WithMessage(ErrorMessages.PasswordInvalidFormat)
			.DependentRules(() =>
			{
				RuleFor(_ => _.Dto.ConfirmPassword)
					.Cascade(CascadeMode.Stop)
					.NotEmptyNotNull(string.Format(ErrorMessages.Required, AccountDto.Label.ConfirmPassword))
					.Equal(_ => _.Dto.Password)
					.WithMessage(ErrorMessages.PasswordDoesNotMatch);
			});
	}
}
