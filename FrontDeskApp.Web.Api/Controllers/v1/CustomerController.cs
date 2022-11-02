using Microsoft.AspNetCore.Mvc;
using FrontDeskApp.Application.Customers;
using FrontDeskApp.Application.Customers.Queries;
using FrontDeskApp.Application.Customers.Commands.CreateCustomer;
using FrontDeskApp.Application.Customers.Commands.UpdateCustomer;
using FrontDeskApp.Application.Customers.Commands.DeleteCustomer;

namespace FrontDeskApp.Web.Api.Controllers.v1;

[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "Customer")]
public sealed class CustomerController : BaseController
{
	[HttpPost]
	public async Task<IActionResult> Create(
		[FromBody] CustomerDto.CreateDto request,
		CancellationToken cancellationToken = default)
	{
		var cmd = new CreateCustomerCommand()
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
		[FromBody] CustomerDto.UpdateDto request,
		CancellationToken cancellationToken = default)
	{
		var cmd = new UpdateCustomerCommand()
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
		var cmd = new DeleteCustomerCommand()
		{
			Dto = new CustomerDto.DeleteDto() { Id = id }
		};
		var result = await Mediator.Send(cmd, cancellationToken);
		if (result.NoErrors)
		{
			return Ok(result);
		}

		return BadRequest(result);
	}

	//[HttpGet("{id}")]
	//public async Task<IActionResult> GetCustomerAsync(
	//	Guid id,
	//	CancellationToken cancellationToken = default)
	//{
	//	var query = new GetCustomerQuery()
	//	{
	//		Id = id
	//	};
	//	var result = await Mediator.Send(query, cancellationToken);

	//	return Ok(result);
	//}

	[HttpGet]
	public async Task<IActionResult> GetCustomersAsync(
		[FromQuery] CustomerDto.SearchCriteria searchCriteria,
		CancellationToken cancellationToken = default)
	{
		var query = new GetCustomersQuery()
		{
			SearchCriteria = searchCriteria
		};
		var result = await Mediator.Send(query, cancellationToken);

		return Ok(result);
	}
}
