using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace FrontDeskApp.WinForm.Models;

[ExcludeFromCodeCoverage]
public sealed class AccountDto
{
	public sealed class Label : BaseDto.Label
	{
		public const string UserName = "UserName";
		public const string Email = "Email";
		public const string Password = "Password";
		public const string CurrentPassword = "Current Password";
		public const string NewPassword = "New Password";
		public const string ConfirmPassword = "Confirm Password";
		public const string EmailToken = "Token";
		public const string AccessToken = "Access Token";
		public const string RefreshToken = "Refresh Token";
	}

	public sealed class Dto
	{
		public Guid Id { get; set; }
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		public string FullName
		{
			get
			{
				return $"{FirstName} {LastName}".Trim();
			}
		}

		public byte[] Photo { get; set; }
		public bool IsActivated { get; set; }
	}

	public sealed class LoginDto
	{
		public string UserName { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
		public bool RememberMe { get; set; }
	}

	public sealed class LoginResponseDto
	{
		public LoginResponseDto()
		{
			Roles = new List<string>();
		}

		public Guid Id { get; set; }
		public string Email { get; set; }
		public string UserName { get; set; }
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		public byte[] ImagePhoto { get; set; }
		public bool IsActivated { get; set; }

		public string Token { get; set; }
		public DateTime? Expiration { get; set; }
		public string RefreshToken { get; set; }

		public IList<string> Roles { get; set; }
	}

	public sealed class LogoffDto
	{
	}

	public class TokenDto
	{
		public string Token { get; set; }
		public string RefreshToken { get; set; }
	}

	public sealed class TokenResponseDto : TokenDto
	{
		public DateTime? Expiration { get; set; }
	}

	public sealed class ChangePasswordDto
	{
		public Guid Id { get; set; }
		public string CurrentPassword { get; set; }
		public string NewPassword { get; set; }
		public string ConfirmPassword { get; init; }
	}

	public sealed class ResetPasswordDto
	{
		public string Email { get; set; }
		public string EmailConfirmationToken { get; set; }
		public string Password { get; init; }
		public string ConfirmPassword { get; init; }
	}

	public sealed class RegisterDto
	{
		public string Email { get; init; }
		[Browsable(false)]
		[JsonIgnore]
		public string UserName { get; set; }
		public string Password { get; init; }
		public string ConfirmPassword { get; init; }
	}

	public sealed class RegisterResponseDto
	{
		public string EmailConfirmationToken { get; set; }
	}

	public sealed class ActivateEmailResponseDto
	{
		public string EmailConfirmationToken { get; set; }
	}

	public sealed class SearchCriteria : SearchCriteriaDto
	{
		public string Email { get; set; }
		public bool? IsLocked { get; set; }
	}

	public sealed class QueryDto : BaseDto.Dto
	{
		[Browsable(false)]
		[JsonIgnore]
		public string FirstName { get; set; }
		[Browsable(false)]
		[JsonIgnore]
		public string MiddleName { get; set; }
		[Browsable(false)]
		[JsonIgnore]
		public string LastName { get; set; }
		public string FullName
		{
			get
			{
				return $"{FirstName} {LastName}".Trim();
			}
		}
		public string Email { get; set; }
		public bool IsActivated { get; set; }
		public bool IsLocked { get; set; }
	}
}
