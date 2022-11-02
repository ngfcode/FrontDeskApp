using Ardalis.GuardClauses;
using FrontDeskApp.Application.Common.Interfaces.Services;
using FrontDeskApp.Application.Common.Results;
using MediatR;

namespace FrontDeskApp.Application.StorageOrders.Commands.DeleteStorageOrder;

public sealed class DeleteStorageOrderCommand : IRequest<DtoResult<StorageOrderDto.Dto>>
{
	public StorageOrderDto.DeleteDto Dto { get; set; }
}

public sealed class DeleteStorageOrderCommandHandler :
	IRequestHandler<DeleteStorageOrderCommand, DtoResult<StorageOrderDto.Dto>>
{
	private readonly IStorageOrderService _service;

	public DeleteStorageOrderCommandHandler(
		IStorageOrderService service)
	{
		_service = Guard.Against.Null(service, nameof(service));
	}

	public async Task<DtoResult<StorageOrderDto.Dto>> Handle(
		DeleteStorageOrderCommand request,
		CancellationToken cancellationToken)
	{
		var valOutput = await (new DeleteStorageOrderCommandValidator(_service)).ValidateAsync(request, cancellationToken);
		if (valOutput.IsValid)
		{
			return await _service.DeleteAsync(request.Dto, cancellationToken);
		}

		var result = new DtoResult<StorageOrderDto.Dto>(
			valOutput.Errors
				.Select(_ => _.ErrorMessage).ToList());

		return result;
	}
}
