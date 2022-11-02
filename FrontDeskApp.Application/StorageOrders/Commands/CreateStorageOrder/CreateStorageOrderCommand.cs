using Ardalis.GuardClauses;
using FrontDeskApp.Application.Common.Interfaces.Services;
using FrontDeskApp.Application.Common.Results;
using MediatR;

namespace FrontDeskApp.Application.StorageOrders.Commands.CreateStorageOrder;

public sealed class CreateStorageOrderCommand : IRequest<DtoResult<StorageOrderDto.Dto>>
{
	public StorageOrderDto.CreateDto Dto { get; set; }
}

public sealed class CreateStorageOrderCommandHandler :
	IRequestHandler<CreateStorageOrderCommand, DtoResult<StorageOrderDto.Dto>>
{
	private readonly IStorageOrderService _service;
	private readonly IStorageService _storageSvc;

	public CreateStorageOrderCommandHandler(
		IStorageOrderService service,
		IStorageService storageSvc)
	{
		_service = Guard.Against.Null(service, nameof(service));
		_storageSvc = Guard.Against.Null(storageSvc, nameof(_storageSvc));
	}

	public async Task<DtoResult<StorageOrderDto.Dto>> Handle(
		CreateStorageOrderCommand request,
		CancellationToken cancellationToken)
	{
		var valOutput = await (new CreateStorageOrderCommandValidator(_storageSvc)).ValidateAsync(request, cancellationToken);
		if (valOutput.IsValid)
		{
			return await _service.AddAsync(request.Dto, cancellationToken);
		}

		var result = new DtoResult<StorageOrderDto.Dto>(
			valOutput.Errors
				.Select(_ => _.ErrorMessage).ToList());

		return result;
	}
}
