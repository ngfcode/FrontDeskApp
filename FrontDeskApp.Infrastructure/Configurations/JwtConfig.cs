using System.Diagnostics.CodeAnalysis;

namespace FrontDeskApp.Infrastructure.Configurations;

[ExcludeFromCodeCoverage]
public sealed class JwtConfig
{
	public string ValidAudience { get; init; }
	public string ValidIssuer { get; init; }
	public string Secret { get; init; }
	public TimeSpan TokenLifeTime { get; init; }
	public int RefreshTokenLifeTimeInDays { get; init; }
}
