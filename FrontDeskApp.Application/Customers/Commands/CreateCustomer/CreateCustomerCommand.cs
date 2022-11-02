using Ardalis.GuardClauses;
using FrontDeskApp.Application.Common.Interfaces.Services;
using FrontDeskApp.Application.Common.Results;
using MediatR;

namespace FrontDeskApp.Application.Customers.Commands.CreateCustomer;

public sealed class CreateCustomerCommand : IRequest<DtoResult<CustomerDto.Dto>>
{
	public CustomerDto.CreateDto Dto { get; set; }
}

public sealed class CreateCustomerCommandHandler :
	IRequestHandler<CreateCustomerCommand, DtoResult<CustomerDto.Dto>>
{
	private readonly ICustomerService _service;

	public CreateCustomerCommandHandler(
		ICustomerService service)
	{
		_service = Guard.Against.Null(service, nameof(service));
	}

	public async Task<DtoResult<CustomerDto.Dto>> Handle(
		CreateCustomerCommand request,
		CancellationToken cancellationToken)
	{
		var valOutput = await (new CreateCustomerCommandValidator(_service)).ValidateAsync(request, cancellationToken);
		if (valOutput.IsValid)
		{
			return await _service.AddAsync(request.Dto, cancellationToken);
		}

		var result = new DtoResult<CustomerDto.Dto>(
			valOutput.Errors
				.Select(_ => _.ErrorMessage).ToList());

		return result;
	}
}
