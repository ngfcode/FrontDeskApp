using FrontDeskApp.Application.Common.Interfaces.Services;
using FrontDeskApp.Infrastructure;
using FrontDeskApp.Infrastructure.Identity;
using FrontDeskApp.Infrastructure.Persistence;
using FrontDeskApp.Shared.Constants;
using FrontDeskApp.Web.Api.Filters;
using FrontDeskApp.Web.Api.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;

Log.Logger = new LoggerConfiguration()
	.MinimumLevel.Override("Microsoft", LogEventLevel.Information)
	.Enrich.FromLogContext()
	.WriteTo.Console()
	.CreateBootstrapLogger();

var builder = WebApplication.CreateBuilder(args);

Log.Information("Starting Web Host");

var originName = "_myAllowSpecificOrigins";

// Add services to the container.
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddSingleton<ICurrentUserService, CurrentUserService>();

builder.Services
	.AddCors(options =>
	{
		options.AddPolicy(name: originName,
			opt =>
			{
				opt.WithOrigins(new string[] { builder.Configuration[DefaultValues.OriginSite] });
				opt.AllowAnyHeader();
				opt.AllowAnyMethod();
				opt.AllowCredentials();
			});
	});

builder.Services
	.AddHttpContextAccessor()
	.AddHealthChecks()
	.AddDbContextCheck<AppDbContext>();

builder.Services
	.AddControllers();

// Filters
builder.Services
	.AddScoped<LogActionFilterService>();

// Serilog
builder.Host
	.UseSerilog((context, services, configuration) => configuration
		.ReadFrom.Configuration(context.Configuration)
		.ReadFrom.Services(services)
		.Enrich.FromLogContext());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services
	.AddSwaggerGen(swagger =>
	{
		swagger.SwaggerDoc("v1",
			new OpenApiInfo()
			{
				Version = "v1",
				Title = "FrontDesk System",
				Description = "Web Api for FrontDesk System"
			});

		swagger.CustomSchemaIds(type => type.FullName.Replace("+", "."));

		swagger.AddSecurityDefinition("Bearer",
			new OpenApiSecurityScheme()
			{
				Name = "Authorization",
				Type = SecuritySchemeType.ApiKey,
				Scheme = "Bearer",
				BearerFormat = "JWT",
				In = ParameterLocation.Header,
				Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\""
			});

		swagger.AddSecurityRequirement(new OpenApiSecurityRequirement()
		{
			{
				new OpenApiSecurityScheme()
				{
					Reference = new OpenApiReference()
					{
						Type = ReferenceType.SecurityScheme,
						Id = "Bearer"
					}
				},
				Array.Empty<string>()
			}
		});

		swagger.TagActionsBy(options =>
		{
			if (!string.IsNullOrWhiteSpace(options.GroupName))
			{
				return new[] { options.GroupName };
			}

			var controllerActionDescriptor = options.ActionDescriptor as ControllerActionDescriptor;
			if (controllerActionDescriptor is object)
			{
				return new[] { controllerActionDescriptor.ControllerName };
			}

			throw new InvalidOperationException("Unable to determine tag for endpoint.");
		});

		swagger.DocInclusionPredicate((name, api) => true);
	});

var app = builder.Build();

// Migrate and Seed Data
await app.MigrateDatabase();

// Configure Serilog
app.UseSerilogRequestLogging(configure =>
{
	configure.MessageTemplate = "HTTP {RequestMethod} {RequestPath} ({UserId}) responded {StatusCode} in {Elapsed:0.0000}ms";
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(options =>
	{
		options.SwaggerEndpoint("/swagger/v1/swagger.json", "Web Api v1");
	});
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(originName);

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllers();
	endpoints.MapHealthChecks("/health");
});

app.Run();
