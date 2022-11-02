using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using FrontDeskApp.Application.Common.Dtos;

namespace FrontDeskApp.Application.StorageOrders;

[ExcludeFromCodeCoverage]
public class StorageOrderDto
{
	#region Form
	public sealed class FormLabel : BaseDto.Label
	{
		public const string CustomerId = "Customer";
		public const string StorageId = "Storage";

		public const string StoredDate = "Stored Date";
		public const string RetrievedDate = "Retrieved Date";
	}

	public class Dto : BaseDto.Dto
	{
		[DisplayName(FormLabel.CustomerId)]
		public Guid CustomerId { get; set; }

		[DisplayName(FormLabel.StorageId)]
		public Guid StorageId { get; set; }

		public int BoxSize { get; set; }

		[DisplayName(FormLabel.StoredDate)]
		public DateTime? StoredDate { get; set; }

		[DisplayName(FormLabel.RetrievedDate)]
		public DateTime? RetrievedDate { get; set; }
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
		public const string CustomerId = "Customer";
		public const string StorageId = "Storage";
		public const string StoredDate = "Stored Date";
		public const string RetrievedDate = "Retrieved Date";
	}

	public sealed class QueryDto : BaseDto.Dto
	{
		[DisplayName(QueryLabel.CustomerId)]
		public string Customer { get; set; }

		[DisplayName(QueryLabel.StorageId)]
		public string StorageLocation { get; set; }

		[DisplayName(QueryLabel.StoredDate)]
		public DateTime StoredDate { get; set; }

		[DisplayName(QueryLabel.RetrievedDate)]
		public DateTime? RetrievedDate { get; set; }
	}

	public sealed class SearchCriteria : SearchCriteriaDto
	{
		public Guid? CustomerId { get; set; }
		public Guid? StorageTypeId { get; set; }
		public string StorageLocation { get; set; }
	}
	#endregion
}
