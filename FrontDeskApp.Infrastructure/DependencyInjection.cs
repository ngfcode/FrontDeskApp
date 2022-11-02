using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;
using System.Text;
using FrontDeskApp.Application;
using FrontDeskApp.Application.Common.Interfaces;
using FrontDeskApp.Application.Common.Interfaces.Repositories;
using FrontDeskApp.Application.Common.Interfaces.Services;
using FrontDeskApp.Infrastructure.Configurations;
using FrontDeskApp.Infrastructure.Identity;
using FrontDeskApp.Infrastructure.Mappings;
using FrontDeskApp.Infrastructure.Persistence;
using FrontDeskApp.Infrastructure.Repositories;
using FrontDeskApp.Infrastructure.Services;
using FrontDeskApp.Shared.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace FrontDeskApp.Infrastructure;

[ExcludeFromCodeCoverage]
public static class DependencyInjection
{
	public static IServiceCollection AddInfrastructure(
		this IServiceCollection services,
		IConfiguration configuration)
	{
		services
			.AddApplication()
			.AddMappings();

		// DbContext
		services.AddDbContext<AppDbContext>(options =>
			{
				options.UseSqlServer(
					configuration.GetConnectionString("AppDbContext"),
					b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName))
					.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
				options.LogTo(Console.WriteLine);
			}, ServiceLifetime.Transient);
		services.AddTransient<IAppDbContext>(provider => provider.GetService<AppDbContext>());

		// Configurations
		var jwtOptions = configuration
							.GetSection("JWT")
							.Get<JwtConfig>();
		services
			// Jwt configuration
			.AddSingleton(jwtOptions)
			// Email configuration
			.AddSingleton(configuration
				.GetSection("EmailConfiguration")
				.Get<EmailConfig>());

		// Adds Identity
		services
			.AddIdentity<ApplicationUser, ApplicationRole>(options =>
			{
				// Password restrictions
				options.Password.RequireUppercase = true;
				options.Password.RequireDigit = true;
				options.Password.RequiredUniqueChars = 1;
				options.Password.RequireNonAlphanumeric = true;

				// Lock account after number of tries
				options.Lockout.MaxFailedAccessAttempts = 3;
				options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(DefaultValues.LockoutTimeSpanInMinutes);

				// Email confirmation
				options.User.RequireUniqueEmail = true;
				options.SignIn.RequireConfirmedEmail = true;
			})
			.AddEntityFrameworkStores<AppDbContext>()
			.AddDefaultTokenProviders();
		services.Configure<IdentityOptions>(options =>
			options.ClaimsIdentity.UserIdClaimType = ClaimTypes.NameIdentifier);
		services.Configure<DataProtectionTokenProviderOptions>(options =>
			options.TokenLifespan = TimeSpan.FromHours(2));

		// Token Validation Parameters
		var tokenValidationParams = new TokenValidationParameters()
		{
			ValidateIssuer = true,
			ValidateAudience = true,
			ValidateLifetime = true,
			ValidateIssuerSigningKey = true,
			ValidAudience = jwtOptions.ValidAudience,
			ValidIssuer = jwtOptions.ValidIssuer,
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Secret)),
			ClockSkew = TimeSpan.Zero
		};
		services.AddSingleton(tokenValidationParams);

		services
			// Add authentication
			.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
			})

			// Add Jwt bearer
			.AddJwtBearer(options =>
			{
				options.SaveToken = true;
				options.RequireHttpsMetadata = false;
				options.TokenValidationParameters = tokenValidationParams;
				options.Events = new JwtBearerEvents
				{
					OnAuthenticationFailed = context =>
					{
						if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
						{
							context.Response.Headers.Add("IS-TOKEN-EXPIRED", "true");
						}

						return Task.CompletedTask;
					}
				};
			});

		#region Repositories
		services
			.AddScoped<ICustomerRepository, CustomerRepository>()
			.AddScoped<IStorageOrderRepository, StorageOrderRepository>()
			.AddScoped<IStorageRepository, StorageRepository>()
			.AddScoped<IStorageTypeRepository, StorageTypeRepository>();
		#endregion

		#region Services
		services
			.AddTransient<IDateTimeService, DateTimeService>()
			.AddTransient<IIdentityService, IdentityService>()
			.AddTransient<IDomainEventService, DomainEventService>()
			.AddTransient<IEmailService, EmailService>();

		services
			.AddScoped<ICustomerService, CustomerService>()
			.AddScoped<IStorageOrderService, StorageOrderService>()
			.AddScoped<IStorageService, StorageService>()
			.AddScoped<IStorageTypeService, StorageTypeService>();
		#endregion

		return services;
	}
}
