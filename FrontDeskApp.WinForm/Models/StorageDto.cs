using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace FrontDeskApp.WinForm.Models;

[ExcludeFromCodeCoverage]
public class StorageDto
{
	#region Form
	public sealed class FormLabel : BaseDto.Label
	{
		public const string StorageTypeId = "Storage Type";
		public const string Location = "Location";
		public const string IsAvailable = "Is Available";
	}

	public class Dto : BaseDto.Dto
	{
		[DisplayName(FormLabel.StorageTypeId)]
		public Guid StorageTypeId { get; set; }

		[DisplayName(FormLabel.Location)]
		public string Location { get; set; }

		[DisplayName(FormLabel.IsAvailable)]
		public bool IsAvailable { get; set; }
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
		public const string StorageTypeId = "Storage Type";
		public const string Location = "Location";
		public const string IsAvailable = "Is Available";
	}

	public sealed class QueryDto : BaseDto.Dto
	{
		[DisplayName(QueryLabel.StorageTypeId)]
		public Guid StorageTypeId { get; set; }

		[DisplayName(QueryLabel.Location)]
		public string Location { get; set; }

		[DisplayName(QueryLabel.IsAvailable)]
		public bool IsAvailable { get; set; }
	}

	public sealed class SearchCriteria : SearchCriteriaDto
	{
		public Guid? StorageTypeId { get; set; }
		public int? SizeType { get; set; }
		public bool? IsAvailable { get; set; }
	}
	#endregion
}
