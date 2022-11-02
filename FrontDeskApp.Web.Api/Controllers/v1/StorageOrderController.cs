using Microsoft.AspNetCore.Mvc;
using FrontDeskApp.Application.StorageOrders;
using FrontDeskApp.Application.StorageOrders.Queries;
using FrontDeskApp.Application.StorageOrders.Commands.CreateStorageOrder;
using FrontDeskApp.Application.StorageOrders.Commands.UpdateStorageOrder;
using FrontDeskApp.Application.StorageOrders.Commands.DeleteStorageOrder;

namespace FrontDeskApp.Web.Api.Controllers.v1;

[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "StorageOrder")]
public sealed class StorageOrderController : BaseController
{
	[HttpPost]
	public async Task<IActionResult> Create(
		[FromBody] StorageOrderDto.CreateDto request,
		CancellationToken cancellationToken = default)
	{
		var cmd = new CreateStorageOrderCommand()
		{
			Dto = request
		};
		var result = await Mediator.Send(cmd, cancellationToken);
		if (result.NoErrors)
		{
			return Ok(result);
		}

		return BadRequest(result);
	}

	[HttpPut]
	public async Task<IActionResult> Update(
		[FromBody] StorageOrderDto.UpdateDto request,
		CancellationToken cancellationToken = default)
	{
		var cmd = new UpdateStorageOrderCommand()
		{
			Dto = request
		};
		var result = await Mediator.Send(cmd, cancellationToken);
		if (result.NoErrors)
		{
			return Ok(result);
		}

		return BadRequest(result);
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(
		Guid id,
		CancellationToken cancellationToken = default)
	{
		var cmd = new DeleteStorageOrderCommand()
		{
			Dto = new StorageOrderDto.DeleteDto() { Id = id }
		};
		var result = await Mediator.Send(cmd, cancellationToken);
		if (result.NoErrors)
		{
			return Ok(result);
		}

		return BadRequest(result);
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetStorageOrderAsync(
		Guid id,
		CancellationToken cancellationToken = default)
	{
		var query = new GetStorageOrderQuery()
		{
			Id = id
		};
		var result = await Mediator.Send(query, cancellationToken);

		return Ok(result);
	}

	[HttpGet]
	public async Task<IActionResult> GetStorageOrdersAsync(
		[FromQuery] StorageOrderDto.SearchCriteria searchCriteria,
		CancellationToken cancellationToken = default)
	{
		var query = new GetStorageOrdersQuery()
		{
			SearchCriteria = searchCriteria
		};
		var result = await Mediator.Send(query, cancellationToken);

		return Ok(result);
	}
}
