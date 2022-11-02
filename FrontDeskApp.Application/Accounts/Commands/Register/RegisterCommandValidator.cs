using System.Diagnostics.CodeAnalysis;
using FrontDeskApp.Application.Common.Extensions;
using FrontDeskApp.Shared.Constants;
using FluentValidation;

namespace FrontDeskApp.Application.Accounts.Commands.Register;

/// <summary>
/// Validator for the register command.
/// </summary>
[ExcludeFromCodeCoverage]
internal sealed class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
	public RegisterCommandValidator()
	{
		RuleFor(_ => _.Dto.Email)
			.Cascade(CascadeMode.Stop)
			.NotEmptyNotNull(string.Format(ErrorMessages.Required, AccountDto.Label.Email))
			.EmailAddress()
			.WithMessage(ErrorMessages.EmailInvalid);

		RuleFor(_ => _.Dto.UserName)
			.Cascade(CascadeMode.Stop)
			.NotEmptyNotNull(string.Format(ErrorMessages.Required, AccountDto.Label.UserName))
			.MaximumLength(MaxLengths.User.UserName)
			.WithMessage(string.Format(ErrorMessages.MaxLength, AccountDto.Label.UserName, MaxLengths.User.UserName));

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
