using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using FrontDeskApp.Application.Common.Dtos;

namespace FrontDeskApp.Application.Customers;

[ExcludeFromCodeCoverage]
public class CustomerDto
{
	#region Form
	public sealed class FormLabel : BaseDto.Label
	{
		public const string FirstName = "First Name";
		public const string MiddleName = "Middle Name";
		public const string LastName = "Last Name";
		public const string PhoneNo = "Phone No.";
	}

	public class Dto : BaseDto.Dto
	{
		[DisplayName(FormLabel.FirstName)]
		public string FirstName { get; set; }

		[DisplayName(FormLabel.MiddleName)]
		public string MiddleName { get; set; }

		[DisplayName(FormLabel.LastName)]
		public string LastName { get; set; }

		public string PhoneNo { get; set; }
	}

	public sealed class CreateDto : Dto
	{
	}

	public sealed class UpdateDto : Dto
	{
	}

	public sealed class DeleteDto : BaseDto.Dto
	{
	}
	#endregion

	#region List
	public sealed class QueryLabel : BaseDto.Label
	{
		public const string CustomerName = "Customer Name";
		public const string PhoneNo = "Phone No.";
	}

	public sealed class QueryDto : BaseDto.Dto
	{
		[DisplayName(QueryLabel.CustomerName)]
		public string CustomerName { get; set; }

		[DisplayName(QueryLabel.PhoneNo)]
		public string PhoneNo { get; set; }
	}

	public sealed class SearchCriteria : SearchCriteriaDto
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
	#endregion
}
