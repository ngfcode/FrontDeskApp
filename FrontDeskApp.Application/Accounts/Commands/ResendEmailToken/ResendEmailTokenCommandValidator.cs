using System.Diagnostics.CodeAnalysis;
using FrontDeskApp.Application.Common.Extensions;
using FrontDeskApp.Shared.Constants;
using FluentValidation;

namespace FrontDeskApp.Application.Accounts.Commands.ResendEmailToken;

/// <summary>
/// Validator for the resend email token command.
/// </summary>
[ExcludeFromCodeCoverage]
internal sealed class ResendEmailTokenCommandValidator : AbstractValidator<ResendEmailTokenCommand>
{
	public ResendEmailTokenCommandValidator()
	{
		RuleFor(_ => _.Email)
			.Cascade(CascadeMode.Stop)
			.NotEmptyNotNull(string.Format(ErrorMessages.Required, AccountDto.Label.Email))
			.EmailAddress()
			.WithMessage(ErrorMessages.EmailInvalid);
	}
}
