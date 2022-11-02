using Ardalis.GuardClauses;
using FluentValidation;
using FrontDeskApp.Application.Common.Extensions;
using FrontDeskApp.Application.Common.Interfaces.Services;
using FrontDeskApp.Shared.Constants;

namespace FrontDeskApp.Application.StorageOrders.Commands.UpdateStorageOrder;

internal sealed class UpdateStorageOrderCommandValidator : AbstractValidator<UpdateStorageOrderCommand>
{
	private readonly IStorageOrderService _service;

	public UpdateStorageOrderCommandValidator(
		IStorageOrderService service)
	{
		_service = Guard.Against.Null(service, nameof(service));

		RuleFor(_ => _.Dto.Id)
			.ValidGuid(string.Format(ErrorMessages.Required, StorageOrderDto.FormLabel.Id));

		RuleFor(_ => _.Dto.CustomerId)
			.ValidGuid(string.Format(ErrorMessages.Required, StorageOrderDto.FormLabel.CustomerId));

		RuleFor(_ => _.Dto.StorageId)
			.ValidGuid(string.Format(ErrorMessages.Required, StorageOrderDto.FormLabel.StorageId));

		RuleFor(_ => _.Dto.RetrievedDate)
			.Cascade(CascadeMode.Stop)
			.NotNull()
			.LessThanOrEqualTo(DateTime.Now)
			.WithMessage("Cannot be future date.");
	}
}
