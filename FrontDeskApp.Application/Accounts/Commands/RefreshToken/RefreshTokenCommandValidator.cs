using System.Diagnostics.CodeAnalysis;
using FrontDeskApp.Application.Common.Extensions;
using FrontDeskApp.Shared.Constants;
using FluentValidation;

namespace FrontDeskApp.Application.Accounts.Commands.RefreshToken;

/// <summary>
/// Validation for the refresh token command.
/// </summary>
[ExcludeFromCodeCoverage]
internal sealed class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommand>
{
	public RefreshTokenCommandValidator()
	{
		RuleFor(_ => _.Dto.Token)
			.NotEmptyNotNull(string.Format(ErrorMessages.Required, AccountDto.Label.AccessToken));

		RuleFor(_ => _.Dto.RefreshToken)
			.NotEmptyNotNull(string.Format(ErrorMessages.Required, AccountDto.Label.RefreshToken));
	}
}
