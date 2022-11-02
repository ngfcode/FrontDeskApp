using System.Diagnostics.CodeAnalysis;
using FrontDeskApp.Application.Common.Extensions;
using FrontDeskApp.Shared.Constants;
using FluentValidation;

namespace FrontDeskApp.Application.Accounts.Commands.ActivateEmail;

/// <summary>
/// Validator for the activate email command.
/// </summary>
[ExcludeFromCodeCoverage]
internal sealed class ActivateEmailCommandValidator : AbstractValidator<ActivateEmailCommand>
{
	public ActivateEmailCommandValidator()
	{
		RuleFor(_ => _.Email)
			.Cascade(CascadeMode.Stop)
			.NotEmptyNotNull(string.Format(ErrorMessages.Required, AccountDto.Label.Email))
			.EmailAddress()
			.WithMessage(ErrorMessages.EmailInvalid);

		RuleFor(_ => _.Token)
			.Cascade(CascadeMode.Stop)
			.NotEmptyNotNull(string.Format(ErrorMessages.Required, AccountDto.Label.EmailToken));
	}
}
