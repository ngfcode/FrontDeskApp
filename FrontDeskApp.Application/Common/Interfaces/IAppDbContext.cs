using FrontDeskApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace FrontDeskApp.Application.Common.Interfaces;

/// <summary>
/// An interface for defining the DB Context.
/// </summary>
public interface IAppDbContext
{
	#region Public Data Members
	DatabaseFacade Database { get; }
	#endregion

	#region Entities
	DbSet<Customer> Customer { get; set; }
	DbSet<Storage> Storage { get; set; }
	DbSet<StorageOrder> StorageOrder { get; set; }
	DbSet<StorageType> StorageType { get; set; }
	#endregion

	DbSet<T> Set<T>() where T : class;
	EntityEntry<T> Entry<T>(T entity)
		where T : class;

	int SaveChanges();
	Task<int> SaveChangesAsync(
		CancellationToken cancellationToken = default);
}
