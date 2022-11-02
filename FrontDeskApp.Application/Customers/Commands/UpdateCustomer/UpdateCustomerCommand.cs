using Ardalis.GuardClauses;
using FrontDeskApp.Application.Common.Interfaces.Services;
using FrontDeskApp.Application.Common.Results;
using MediatR;

namespace FrontDeskApp.Application.Customers.Commands.UpdateCustomer;

public sealed class UpdateCustomerCommand : IRequest<DtoResult<CustomerDto.Dto>>
{
	public CustomerDto.UpdateDto Dto { get; set; }
}

public sealed class UpdateCustomerCommandHandler :
	IRequestHandler<UpdateCustomerCommand, DtoResult<CustomerDto.Dto>>
{
	private readonly ICustomerService _service;

	public UpdateCustomerCommandHandler(
		ICustomerService service)
	{
		_service = Guard.Against.Null(service, nameof(service));
	}

	public async Task<DtoResult<CustomerDto.Dto>> Handle(
		UpdateCustomerCommand request,
		CancellationToken cancellationToken)
	{
		var valOutput = await (new UpdateCustomerCommandValidator(_service)).ValidateAsync(request, cancellationToken);
		if (valOutput.IsValid)
		{
			return await _service.UpdateAsync(request.Dto, cancellationToken);
		}

		var result = new DtoResult<CustomerDto.Dto>(
			valOutput.Errors
				.Select(_ => _.ErrorMessage).ToList());

		return result;
	}
}
