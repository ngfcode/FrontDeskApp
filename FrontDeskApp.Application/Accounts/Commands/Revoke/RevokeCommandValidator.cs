using System.Diagnostics.CodeAnalysis;
using FrontDeskApp.Application.Common.Extensions;
using FrontDeskApp.Shared.Constants;
using FluentValidation;

namespace FrontDeskApp.Application.Accounts.Commands.Revoke;

/// <summary>
/// Validation for the refresh token command.
/// </summary>
[ExcludeFromCodeCoverage]
internal sealed class RevokeCommandValidator : AbstractValidator<RevokeCommand>
{
	public RevokeCommandValidator()
	{
		RuleFor(_ => _.UserName)
			.NotEmptyNotNull(string.Format(ErrorMessages.Required, AccountDto.Label.UserName));
	}
}
