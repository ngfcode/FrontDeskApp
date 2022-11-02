using System.Diagnostics.CodeAnalysis;
using Ardalis.GuardClauses;
using FrontDeskApp.Application.Common.Interfaces.Services;
using FrontDeskApp.Application.Common.Results;
using MediatR;

namespace FrontDeskApp.Application.Customers.Queries;

[ExcludeFromCodeCoverage]
public class GetCustomerQuery : IRequest<DtoResult<CustomerDto.Dto>>
{
	public Guid Id { get; set; }
}

public sealed class GetCustomerQueryHandler :
	IRequestHandler<GetCustomerQuery, DtoResult<CustomerDto.Dto>>
{
	private readonly ICustomerService _service;

	public GetCustomerQueryHandler(
		ICustomerService service)
	{
		_service = Guard.Against.Null(service, nameof(service));
	}
	public async Task<DtoResult<CustomerDto.Dto>> Handle(
		GetCustomerQuery request,
		CancellationToken cancellationToken)
	{
		return await _service.GetByIdAsync(request.Id,
			cancellationToken);
	}
}
