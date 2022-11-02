using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;
using Ardalis.GuardClauses;
using FrontDeskApp.Application.Common.Interfaces.Services;

namespace FrontDeskApp.Web.Api.Services;

[ExcludeFromCodeCoverage]
internal sealed class CurrentUserService : ICurrentUserService
{
	public Guid UserId => new Guid(_httpContextAccessor.HttpContext?
		.User?.FindFirstValue(nameof(ICurrentUserService.UserId)));
	public string UserName => _httpContextAccessor.HttpContext?
		.User?.FindFirstValue(ClaimTypes.Name);
	public string Email => _httpContextAccessor.HttpContext?
		.User?.FindFirstValue(ClaimTypes.Email);
	public bool IsAuthenticated { get; }

	private readonly IHttpContextAccessor _httpContextAccessor;

	public CurrentUserService(
		IHttpContextAccessor httpContextAccessor)
	{
		_httpContextAccessor = Guard.Against.Null(httpContextAccessor, nameof(httpContextAccessor));
	}
}
