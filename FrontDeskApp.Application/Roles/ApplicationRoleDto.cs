using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using FrontDeskApp.Application.Common.Dtos;

namespace FrontDeskApp.Application.Roles;

[ExcludeFromCodeCoverage]
public class ApplicationRoleDto
{
	#region Form
	public sealed class FormLabel : BaseDto.Label
	{
		public const string Code = "Code";
		public const string Name = "Name";
	}

	public class Dto : BaseDto.Dto
	{
		[DisplayName(FormLabel.Code)]
		public string Code { get; set; }

		[DisplayName(FormLabel.Name)]
		public string Name { get; set; }
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
	public sealed class IndexLabel : BaseDto.Label
	{
		public const string Code = "Code";
		public const string Name = "Name";
	}

	public sealed class IndexDto : BaseDto.Dto
	{
		[DisplayName(IndexLabel.Code)]
		public string Code { get; set; }

		[DisplayName(IndexLabel.Name)]
		public string Name { get; set; }
	}

	public sealed class SearchCriteria : SearchCriteriaDto
	{
	}
	#endregion
}
