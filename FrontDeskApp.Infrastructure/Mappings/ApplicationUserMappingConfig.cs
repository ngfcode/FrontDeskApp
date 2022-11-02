using System.Diagnostics.CodeAnalysis;
using FrontDeskApp.Application.Accounts;
using FrontDeskApp.Infrastructure.Identity;
using Mapster;

namespace FrontDeskApp.Infrastructure.Mappings;

[ExcludeFromCodeCoverage]
public sealed class ApplicationUserMappingConfig : IRegister
{
	public void Register(
		TypeAdapterConfig config)
	{
		config.NewConfig<ApplicationUser, AccountDto.Dto>();
		config.NewConfig<ApplicationUser, AccountDto.LoginResponseDto>();
		config.NewConfig<ApplicationUser, AccountDto.RegisterResponseDto>();
		config.NewConfig<ApplicationUser, AccountDto.QueryDto>();

		config.NewConfig<AccountDto.RegisterDto, ApplicationUser>();
	}
}
