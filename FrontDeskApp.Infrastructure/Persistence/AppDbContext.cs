using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Ardalis.GuardClauses;
using FrontDeskApp.Application.Common.Interfaces;
using FrontDeskApp.Application.Common.Interfaces.Services;
using FrontDeskApp.Domain.Common;
using FrontDeskApp.Domain.Entities;
using FrontDeskApp.Infrastructure.Identity;
using FrontDeskApp.Infrastructure.Persistence.Configurations;
using FrontDeskApp.Infrastructure.Persistence.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FrontDeskApp.Infrastructure.Persistence;

[ExcludeFromCodeCoverage]
public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid,
	ApplicationUserClaim,
	ApplicationUserRole,
	ApplicationUserLogin,
	ApplicationRoleClaim,
	ApplicationUserToken>, IAppDbContext
{
	#region Account
	public DbSet<ApplicationRole> ApplicationRole { get; set; }
	public DbSet<ApplicationRoleClaim> ApplicationRoleClaim { get; set; }
	public DbSet<ApplicationUser> ApplicationUser { get; set; }
	public DbSet<ApplicationUserClaim> ApplicationUserClaim { get; set; }
	public DbSet<ApplicationUserLogin> ApplicationUserLogin { get; set; }
	public DbSet<ApplicationUserRole> ApplicationUserRole { get; set; }
	public DbSet<ApplicationUserToken> ApplicationUserToken { get; set; }
	#endregion

	#region Entities
	public DbSet<Customer> Customer { get; set; }
	public DbSet<Storage> Storage { get; set; }
	public DbSet<StorageOrder> StorageOrder { get; set; }
	public DbSet<StorageType> StorageType { get; set; }
	#endregion

	#region Private Data Members
	private readonly ICurrentUserService _currentUserService;
	private readonly IDomainEventService _domainEventService;
	private readonly IDateTimeService _dateTime;
	#endregion

	public AppDbContext(
		DbContextOptions<AppDbContext> options,
		ICurrentUserService currentUserService,
		IDomainEventService domainEventService,
		IDateTimeService dateTime)
		: base(options)
	{
		_currentUserService = Guard.Against.Null(currentUserService, nameof(currentUserService));
		_domainEventService = Guard.Against.Null(domainEventService, nameof(domainEventService));
		_dateTime = Guard.Against.Null(dateTime, nameof(dateTime));
	}

	/// <summary>
	/// Overrides the SaveChangesAsync method to set the audit trails.
	/// </summary>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	public override async Task<int> SaveChangesAsync(
		CancellationToken cancellationToken = default)
	{
		foreach (EntityEntry<AuditEntity> entry in ChangeTracker.Entries<AuditEntity>())
		{
			// Applies auditing fields
			switch (entry.State)
			{

				case EntityState.Added:
					entry.Entity.CreatedId = _currentUserService.UserId;
					entry.Entity.CreatedName = _currentUserService.UserName;
					entry.Entity.CreatedDateTime = _dateTime.Now;
					entry.Entity.UpdatedId = null;
					entry.Entity.UpdatedName = null;
					entry.Entity.UpdatedDateTime = null;
					break;

				case EntityState.Modified:
					entry.Entity.UpdatedId = _currentUserService.UserId;
					entry.Entity.UpdatedName = _currentUserService.UserName;
					entry.Entity.UpdatedDateTime = _dateTime.Now;
					break;

				case EntityState.Deleted:
					entry.State = EntityState.Modified;
					entry.Entity.UpdatedId = _currentUserService.UserId;
					entry.Entity.UpdatedName = _currentUserService.UserName;
					entry.Entity.UpdatedDateTime = _dateTime.Now;
					entry.Entity.IsSoftDeleted = entry.Entity.IsSoftDeleted++;
					break;

			}
		}

		var result = await base.SaveChangesAsync(cancellationToken);
		await DispatchEventsAsync();

		return result;
	}

	protected override void OnModelCreating(
		ModelBuilder builder)
	{
		// Create IEntityTypeConfiguraton for each entity to define the table properties
		builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

		foreach (var entityType in builder.Model.GetEntityTypes())
		{
			// Removes all soft deleted records from the query
			if (typeof(ISoftDelete).IsAssignableFrom(entityType.ClrType))
			{
				entityType.AddSoftDeleteQueryFilter();
			}
		}

		base.OnModelCreating(builder);

		#region Seed Data
		// Create Storage Types
		var storageTypeIds = new List<Guid>
		{
			Guid.NewGuid(),
			Guid.NewGuid(),
			Guid.NewGuid()
		};

		builder.Entity<StorageType>().HasData(
			new StorageType { Id = storageTypeIds[0], Code = "SMALL-TYPE", Name = "Small Type Storage", SizeType = 1 },
			new StorageType { Id = storageTypeIds[1], Code = "MEDIUM-TYPE", Name = "Medium Type Storage", SizeType = 2 },
			new StorageType { Id = storageTypeIds[2], Code = "LARGE-TYPE", Name = "Large Type Storage", SizeType = 3 }
			);

		// Create Storages
		foreach (var item in storageTypeIds)
		{
			for (int i = 1; i <= 50; i++)
			{
				builder.Entity<Storage>().HasData(
					new Storage { Id = Guid.NewGuid(), StorageTypeId = item, Location = $"LOC{i:00}", IsAvailable = true });
			}
		}

		// Create Customers
		builder.Entity<Customer>().HasData(
			new Customer { Id = Guid.NewGuid(), FirstName = "Noel", MiddleName = "Gonzales", LastName = "Francisco", PhoneNo = "123456789" },
			new Customer { Id = Guid.NewGuid(), FirstName = "Tony", LastName = "Starks", PhoneNo = "987654321" }
			);
		#endregion
	}

	private async Task DispatchEventsAsync()
	{
		while (true)
		{
			var domainEventEntity = ChangeTracker.Entries<IHasDomainEvent>()
				.Select(x => x.Entity.DomainEvents)
				.SelectMany(x => x)
				.Where(domainEvent => !domainEvent.IsPublished)
				.FirstOrDefault();
			if (domainEventEntity is null)
				break;

			domainEventEntity.IsPublished = true;
			await _domainEventService.PublishAsync(domainEventEntity);
		}
	}
}
