using Ardalis.GuardClauses;
using FrontDeskApp.Application.Common.Interfaces.Services;
using FrontDeskApp.Application.Common.Results;
using MediatR;

namespace FrontDeskApp.Application.StorageOrders.Commands.UpdateStorageOrder;

public sealed class UpdateStorageOrderCommand : IRequest<DtoResult<StorageOrderDto.Dto>>
{
	public StorageOrderDto.UpdateDto Dto { get; set; }
}

public sealed class UpdateStorageOrderCommandHandler :
	IRequestHandler<UpdateStorageOrderCommand, DtoResult<StorageOrderDto.Dto>>
{
	private readonly IStorageOrderService _service;

	public UpdateStorageOrderCommandHandler(
		IStorageOrderService service)
	{
		_service = Guard.Against.Null(service, nameof(service));
	}

	public async Task<DtoResult<StorageOrderDto.Dto>> Handle(
		UpdateStorageOrderCommand request,
		CancellationToken cancellationToken)
	{
		var valOutput = await (new UpdateStorageOrderCommandValidator(_service)).ValidateAsync(request, cancellationToken);
		if (valOutput.IsValid)
		{
			return await _service.UpdateAsync(request.Dto, cancellationToken);
		}

		var result = new DtoResult<StorageOrderDto.Dto>(
			valOutput.Errors
				.Select(_ => _.ErrorMessage).ToList());

		return result;
	}
}
