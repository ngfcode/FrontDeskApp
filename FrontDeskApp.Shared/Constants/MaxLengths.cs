namespace FrontDeskApp.Shared.Constants;

public class MaxLengths
{
	public sealed class User
	{
		public const int UserName = DefaultValues.NameLength;
		public const int Password = 100;
	}

	public sealed class Customer
	{
		public const int FirstName = DefaultValues.NameLength;
		public const int MiddleName = DefaultValues.NameLength;
		public const int LastName = DefaultValues.NameLength;
		public const int PhoneNo = 20;
	}

	public sealed class Storage
	{
		public const int Location = DefaultValues.NameLength;
	}

	public sealed class StorageType
	{
		public const int Code = DefaultValues.CodeLength;
		public const int Name = DefaultValues.NameLength;
		public const int Description = DefaultValues.DescriptionLength;
	}
}
