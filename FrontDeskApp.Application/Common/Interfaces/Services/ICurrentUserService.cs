namespace FrontDeskApp.Application.Common.Interfaces.Services;

/// <summary>
/// An interface the defines the current user that has been authenticated that can be used for auditing.
/// </summary>
public interface ICurrentUserService
{
	Guid UserId { get; }
	string UserName { get; }
	string Email { get; }
	bool IsAuthenticated { get; }
}
