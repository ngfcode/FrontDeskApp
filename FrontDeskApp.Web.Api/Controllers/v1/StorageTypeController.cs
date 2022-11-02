using Microsoft.AspNetCore.Mvc;
using FrontDeskApp.Application.StorageTypes;
using FrontDeskApp.Application.StorageTypes.Queries;
using Microsoft.AspNetCore.Authorization;

namespace FrontDeskApp.Web.Api.Controllers.v1;

[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "StorageType")]
[AllowAnonymous]
public sealed class StorageTypeController : BaseController
{
	[HttpGet]
	public async Task<IActionResult> GetStorageTypesAsync(
		[FromQuery] StorageTypeDto.SearchCriteria searchCriteria,
		CancellationToken cancellationToken = default)
	{
		var query = new GetStorageTypesQuery()
		{
			SearchCriteria = searchCriteria
		};
		var result = await Mediator.Send(query, cancellationToken);

		return Ok(result);
	}
}
