using FrontDeskApp.Application.Accounts;
using FrontDeskApp.Application.Accounts.Queries;
using FrontDeskApp.Application.Common.Results;
using Microsoft.AspNetCore.Mvc;

namespace FrontDeskApp.Web.Api.Controllers.v1;

[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "User")]
public class UserController : BaseController
{
	[HttpGet("Users")]
	public async Task<IActionResult> GetUsersAsync(
		[FromQuery] AccountDto.SearchCriteria searchCriteria)
	{
		var query = new GetUsersQuery()
		{
			SearchCriteria = searchCriteria
		};
		var result = await Mediator.Send(query);

		return Ok(result);
	}
}
