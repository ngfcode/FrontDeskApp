using Ardalis.GuardClauses;
using FluentValidation;
using FrontDeskApp.Application.Common.Extensions;
using FrontDeskApp.Application.Common.Interfaces.Services;
using FrontDeskApp.Application.Storages;
using FrontDeskApp.Application.Storages.Specifications;
using FrontDeskApp.Shared.Constants;

namespace FrontDeskApp.Application.StorageOrders.Commands.CreateStorageOrder;

internal sealed class CreateStorageOrderCommandValidator : AbstractValidator<CreateStorageOrderCommand>
{
	private readonly IStorageService _storageSvc;

	public CreateStorageOrderCommandValidator(
		IStorageService service)
	{
		_storageSvc = Guard.Against.Null(service, nameof(service));

		RuleFor(_ => _.Dto.CustomerId)
			.ValidGuid(string.Format(ErrorMessages.Required, StorageOrderDto.FormLabel.CustomerId));

		RuleFor(_ => _.Dto.StorageId)
			.ValidGuid(string.Format(ErrorMessages.Required, StorageOrderDto.FormLabel.StorageId));

		RuleFor(_ => _.Dto.StoredDate)
			.Cascade(CascadeMode.Stop)
			.NotNull()
			.LessThanOrEqualTo(DateTime.Now)
			.WithMessage("Cannot be future date.");

		RuleFor(_ => _.Dto)
			.MustAsync(async (dto, cancellationToken) => await IsCorrectBoxSize(dto, cancellationToken))
			.WithMessage("Box size does not match.");
	}

	private async Task<bool> IsCorrectBoxSize(
		StorageOrderDto.CreateDto dto,
		CancellationToken cancellationToken = default)
	{
		bool isExists = await _storageSvc.AnyBySpecificationAsync(
			new StorageBySearchCriteriaSpec(
				new StorageDto.SearchCriteria
				{
					Id = dto.StorageId,
					SizeType = dto.BoxSize,
					IsPagingEnabled = false
				}),
			cancellationToken);

		return isExists;
	}
}
