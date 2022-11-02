using System.Diagnostics.CodeAnalysis;
using FrontDeskApp.Application.Common.Extensions;
using FrontDeskApp.Shared.Constants;
using FluentValidation;

namespace FrontDeskApp.Application.Accounts.Commands.ChangePassword;

/// <summary>
/// Validation for the change password command.
/// </summary>
[ExcludeFromCodeCoverage]
internal sealed class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
{
	public ChangePasswordCommandValidator()
	{
		RuleFor(_ => _.Dto.Id)
			.Cascade(CascadeMode.Stop)
			.ValidGuid(string.Format(ErrorMessages.Required, AccountDto.Label.Id));

		RuleFor(_ => _.Dto.CurrentPassword)
			.Cascade(CascadeMode.Stop)
			.NotEmptyNotNull(string.Format(ErrorMessages.Required, AccountDto.Label.CurrentPassword));

		RuleFor(_ => _.Dto.NewPassword)
			.Cascade(CascadeMode.Stop)
			.NotEmptyNotNull(string.Format(ErrorMessages.Required, AccountDto.Label.NewPassword))
			.Matches(DefaultValues.PasswordFormat)
			.WithMessage(ErrorMessages.PasswordInvalidFormat)
			.DependentRules(() =>
			{
				RuleFor(_ => _.Dto.ConfirmPassword)
					.Cascade(CascadeMode.Stop)
					.NotEmptyNotNull(string.Format(ErrorMessages.Required, AccountDto.Label.ConfirmPassword))
					.Equal(_ => _.Dto.NewPassword)
					.WithMessage(ErrorMessages.PasswordDoesNotMatch);
			});
	}
}
