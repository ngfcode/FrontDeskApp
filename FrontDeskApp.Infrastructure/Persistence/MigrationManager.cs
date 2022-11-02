using System.Diagnostics.CodeAnalysis;
using FrontDeskApp.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FrontDeskApp.Infrastructure.Persistence;

[ExcludeFromCodeCoverage]
public static class MigrationManager
{
	public static async Task<IHost> MigrateDatabase(
		this IHost app)
	{
		using (var scope = app.Services.CreateScope())
		{
			var services = scope.ServiceProvider;
			try
			{

				var context = services.GetRequiredService<AppDbContext>();
				if (context.Database.IsSqlServer())
				{
					context.Database.Migrate();
				}

				var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
				var roleManager = services.GetRequiredService<RoleManager<ApplicationRole>>();

				await AppDbContextSeed.SeedDefaultUserAsync(userManager, roleManager);

			}

			catch (Exception ex)
			{
				var logger = scope.ServiceProvider.GetRequiredService<ILogger>();
				logger.LogError(ex, "An error occurred while migrating or seeding the database.");

				throw;
			}
		}

		return app;
	}
}
