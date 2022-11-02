using System.Diagnostics.CodeAnalysis;
using FrontDeskApp.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace FrontDeskApp.Infrastructure.Persistence;

[ExcludeFromCodeCoverage]
public static class AppDbContextSeed
{
	public static async Task SeedDefaultUserAsync(
		UserManager<ApplicationUser> userManager,
		RoleManager<ApplicationRole> roleManager)
	{
		ApplicationRole adminRole = new ApplicationRole()
		{
			Code = "ADMIN",
			Name = "Administrator",
		};
		if (!roleManager.Roles.Any(r => r.Name == adminRole.Name))
		{
			await roleManager.CreateAsync(adminRole);
		}

		// TODO: This should be changed once it has been seed to the database.
		ApplicationUser admin = new()
		{
			UserName = "admin@localhost.com",
			Email = "admin@localhost.com",
			FirstName = "Admin",
			LastName = "Administrator",
			IsActivated = true,
			EmailConfirmed = true
		};

		if (!userManager.Users.Any(u => u.UserName == admin.UserName))
		{

			var result = await userManager.CreateAsync(admin, "Admin1str@t0r123");
			if (result.Succeeded)
				await userManager.AddToRolesAsync(admin, new[] { adminRole.Name });

		}
	}
}
