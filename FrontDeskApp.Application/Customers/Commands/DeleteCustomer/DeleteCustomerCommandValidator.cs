using Ardalis.GuardClauses;
using FluentValidation;
using FrontDeskApp.Application.Common.Extensions;
using FrontDeskApp.Application.Common.Interfaces.Services;
using FrontDeskApp.Shared.Constants;

namespace FrontDeskApp.Application.Customers.Commands.DeleteCustomer;

internal sealed class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
{
	private readonly ICustomerService _service;

	public DeleteCustomerCommandValidator(
		ICustomerService service)
	{
		_service = Guard.Against.Null(service, nameof(service));

		RuleFor(_ => _.Dto.Id)
			.ValidGuid(string.Format(ErrorMessages.Required, CustomerDto.FormLabel.Id));
	}
}
