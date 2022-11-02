using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using FrontDeskApp.Application.Common.Dtos;

namespace FrontDeskApp.Application.StorageTypes;

[ExcludeFromCodeCoverage]
public class StorageTypeDto
{
	#region Form
	public sealed class FormLabel : BaseDto.Label
	{
		public const string Code = "Code";
		public const string Name = "Name";
		public const string Description = "Description";
		public const string SizeType = "Size";
	}

	public class Dto : BaseDto.Dto
	{
		[DisplayName(FormLabel.Code)]
		public string Code { get; set; }

		[DisplayName(FormLabel.Name)]
		public string Name { get; set; }

		[DisplayName(FormLabel.Description)]
		public string Description { get; set; }

		[DisplayName(FormLabel.SizeType)]
		public int SizeType { get; set; }
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
		public const string Code = "Code";
		public const string Name = "Name";
		public const string Description = "Description";
		public const string SizeType = "Size";
		public const string TotalStorage = "Total Storage";
		public const string TotalAvailable = "Total Available";
	}

	public sealed class QueryDto : BaseDto.Dto
	{
		[DisplayName(QueryLabel.Code)]
		public string Code { get; set; }

		[DisplayName(QueryLabel.Name)]
		public string Name { get; set; }

		[DisplayName(QueryLabel.Description)]
		public string Description { get; set; }

		[DisplayName(QueryLabel.SizeType)]
		public int SizeType { get; set; }

		[DisplayName(QueryLabel.TotalStorage)]
		public int TotalStorage { get; set; }

		[DisplayName(QueryLabel.TotalAvailable)]
		public int TotalAvailable { get; set; }
	}

	public sealed class SearchCriteria : SearchCriteriaDto
	{
	}
	#endregion
}
