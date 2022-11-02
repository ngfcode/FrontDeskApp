namespace FrontDeskApp.Shared.Constants;

public class ErrorMessages
{
	public const string NotFound = "The record does not exists or might have been deleted already.";

	public const string AddError = "An error occurred while adding the record, please try again.";
	public const string UpdateError = "An error occurred while updating the record, please try again.";
	public const string DeleteError = "An error occurred while deleting the record, please try again.";

	public const string UsernamePasswordInvalid = "The username or password is invalid.";
	public const string EmailPasswordInvalid = "The email or password is invalid.";
	public const string AccountIsLocked = "The account is currently locked, please contact your administrator or wait for {0} minutes and try again.";
	public const string AccountNotYetActivated = "The account is not yet activated, please click the link from the email sent to you to activate.";
	public const string AccountAlreadyExists = "Account already exists.";
	public const string EmailNotYetValidated = "The email address given during registration has not been validated yet. Please check your email.";
	public const string ActivateKeyNotFound = "The activation key cannot be found or already expired.";
	public const string ConfirmEmail = "An error occurred while confirming the email, the token may be invalid or expired.";
	public const string EmailNotFound = "The specified email does not exists.";
	public const string RegistrationFailed = "An error occurred during registration, please try again later.";
	public const string PasswordInvalidFormat = "The password must have at least one uppercase, one lowercase, a digit, a special character and at least 8 characters.";
	public const string PasswordDoesNotMatch = "The confirm password does not match the password you entered.";
	public const string ResetPasswordError = "The confirmation token does not exists or already expired. Please try again to reset your password.";

	public const string Required = "{0} is required.";
	public const string Unique = "{0} already exists and must be unique.";
	public const string MaxLength = "{0} should not exceed the maximum length of {1}.";
	public const string MaxValue = "{0} should not exceed the maximum value of {1}.";
	public const string LessThanOrEEqual = "{0} should be less or equal to {1}.";
	public const string EmailInvalid = "The email address is invalid.";
}
