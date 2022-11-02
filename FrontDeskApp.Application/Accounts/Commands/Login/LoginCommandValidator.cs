using System.Diagnostics.CodeAnalysis;
using FrontDeskApp.Application.Common.Extensions;
using FrontDeskApp.Shared.Constants;
using FluentValidation;

namespace FrontDeskApp.Application.Accounts.Commands.Login;

/// <summary>
/// Validation for the login command.
/// </summary>
[ExcludeFromCodeCoverage]
internal sealed class LoginCommandValidator : AbstractValidator<LoginCommand>
{
	public LoginCommandValidator()
	{
		RuleFor(_ => _.Dto.UserName)
			.Cascade(CascadeMode.Stop)
			.NotEmptyNotNull(string.Format(ErrorMessages.Required, AccountDto.Label.UserName))
			.MaximumLength(MaxLengths.User.UserName)
			.WithMessage(string.Format(ErrorMessages.MaxLength, AccountDto.Label.UserName, MaxLengths.User.UserName));

		RuleFor(_ => _.Dto.Password)
			.Cascade(CascadeMode.Stop)
			.NotEmptyNotNull(string.Format(ErrorMessages.Required, AccountDto.Label.Password))
			.MaximumLength(MaxLengths.User.Password)
			.WithMessage(string.Format(ErrorMessages.MaxLength, AccountDto.Label.Password, MaxLengths.User.Password));
	}
}
