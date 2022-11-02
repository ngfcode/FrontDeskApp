namespace FrontDeskApp.Shared.Constants;

public sealed class DefaultValues
{
	// Timezone
	public const string DefaultTimeZone = "Taipei Standard Time";

	// Authentication
	public const int LockoutTimeSpanInMinutes = 2;
	public const string OriginSite = "OriginSite";
	public const string PasswordFormat = "(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^A-Za-z0-9])(?=.{8,})";

	public const int CodeLength = 20;
	public const int NameLength = 50;
	public const int DescriptionLength = 200;
	public const int EmailLength = 150;

	public const Enums.PageSize DefaultPageSize = Enums.PageSize.Pg5;

	// User Defined Groups
	public const string UDGQualifierType = "QTYPE";
}
