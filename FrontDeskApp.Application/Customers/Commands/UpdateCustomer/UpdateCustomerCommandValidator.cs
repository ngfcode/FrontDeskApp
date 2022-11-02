using Ardalis.GuardClauses;
using FluentValidation;
using FrontDeskApp.Application.Common.Extensions;
using FrontDeskApp.Application.Common.Interfaces.Services;
using FrontDeskApp.Shared.Constants;

namespace FrontDeskApp.Application.Customers.Commands.UpdateCustomer;

internal sealed class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
	private readonly ICustomerService _service;

	public UpdateCustomerCommandValidator(
		ICustomerService service)
	{
		_service = Guard.Against.Null(service, nameof(service));

		RuleFor(_ => _.Dto.Id)
			.ValidGuid(string.Format(ErrorMessages.Required, CustomerDto.FormLabel.Id));

		RuleFor(_ => _.Dto.FirstName)
			.Cascade(CascadeMode.Stop)
			.NotEmptyNotNull(string.Format(ErrorMessages.Required, CustomerDto.FormLabel.FirstName))
			.MaximumLength(MaxLengths.Customer.FirstName)
			.WithMessage(string.Format(ErrorMessages.MaxLength, CustomerDto.FormLabel.FirstName, MaxLengths.Customer.FirstName));

		RuleFor(_ => _.Dto.MiddleName)
			.Cascade(CascadeMode.Stop)
			.MaximumLength(MaxLengths.Customer.MiddleName)
			.WithMessage(string.Format(ErrorMessages.MaxLength, CustomerDto.FormLabel.MiddleName, MaxLengths.Customer.MiddleName));

		RuleFor(_ => _.Dto.LastName)
			.Cascade(CascadeMode.Stop)
			.NotEmptyNotNull(string.Format(ErrorMessages.Required, CustomerDto.FormLabel.LastName))
			.MaximumLength(MaxLengths.Customer.LastName)
			.WithMessage(string.Format(ErrorMessages.MaxLength, CustomerDto.FormLabel.LastName, MaxLengths.Customer.LastName));

		RuleFor(_ => _.Dto.PhoneNo)
			.Cascade(CascadeMode.Stop)
			.NotEmptyNotNull(string.Format(ErrorMessages.Required, CustomerDto.FormLabel.PhoneNo))
			.MaximumLength(MaxLengths.Customer.PhoneNo)
			.WithMessage(string.Format(ErrorMessages.MaxLength, CustomerDto.FormLabel.PhoneNo, MaxLengths.Customer.PhoneNo))
			.Matches("^\\+?[1-9][0-9]{7,14}$")
			.WithMessage("Phone No. is not in the correct format.");
	}
}
