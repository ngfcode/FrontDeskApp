using Microsoft.AspNetCore.Mvc;
using FrontDeskApp.Application.Storages;
using FrontDeskApp.Application.Storages.Queries;

namespace FrontDeskApp.Web.Api.Controllers.v1;

[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "Storage")]
public sealed class StorageController : BaseController
{
	[HttpGet]
	public async Task<IActionResult> GetStoragesAsync(
		[FromQuery] StorageDto.SearchCriteria searchCriteria,
		CancellationToken cancellationToken = default)
	{
		var query = new GetStoragesQuery()
		{
			SearchCriteria = searchCriteria
		};
		var result = await Mediator.Send(query, cancellationToken);

		return Ok(result);
	}
}
