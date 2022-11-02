using Ardalis.GuardClauses;
using FrontDeskApp.Application.Common.Interfaces.Services;
using FrontDeskApp.Application.Common.Results;
using MediatR;

namespace FrontDeskApp.Application.Customers.Commands.DeleteCustomer;

public sealed class DeleteCustomerCommand : IRequest<DtoResult<CustomerDto.Dto>>
{
	public CustomerDto.DeleteDto Dto { get; set; }
}

public sealed class DeleteCustomerCommandHandler :
	IRequestHandler<DeleteCustomerCommand, DtoResult<CustomerDto.Dto>>
{
	private readonly ICustomerService _service;

	public DeleteCustomerCommandHandler(
		ICustomerService service)
	{
		_service = Guard.Against.Null(service, nameof(service));
	}

	public async Task<DtoResult<CustomerDto.Dto>> Handle(
		DeleteCustomerCommand request,
		CancellationToken cancellationToken)
	{
		var valOutput = await (new DeleteCustomerCommandValidator(_service)).ValidateAsync(request, cancellationToken);
		if (valOutput.IsValid)
		{
			return await _service.DeleteAsync(request.Dto, cancellationToken);
		}

		var result = new DtoResult<CustomerDto.Dto>(
			valOutput.Errors
				.Select(_ => _.ErrorMessage).ToList());

		return result;
	}
}
