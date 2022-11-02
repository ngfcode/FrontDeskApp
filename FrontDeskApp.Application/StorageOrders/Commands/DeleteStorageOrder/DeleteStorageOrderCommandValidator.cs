using Ardalis.GuardClauses;
using FluentValidation;
using FrontDeskApp.Application.Common.Extensions;
using FrontDeskApp.Application.Common.Interfaces.Services;
using FrontDeskApp.Shared.Constants;

namespace FrontDeskApp.Application.StorageOrders.Commands.DeleteStorageOrder;

internal sealed class DeleteStorageOrderCommandValidator : AbstractValidator<DeleteStorageOrderCommand>
{
	private readonly IStorageOrderService _service;

	public DeleteStorageOrderCommandValidator(
		IStorageOrderService service)
	{
		_service = Guard.Against.Null(service, nameof(service));

		RuleFor(_ => _.Dto.Id)
			.ValidGuid(string.Format(ErrorMessages.Required, StorageOrderDto.FormLabel.Id));
	}
}
