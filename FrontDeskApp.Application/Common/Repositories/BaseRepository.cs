using FrontDeskApp.Application.Common.Interfaces;
using FrontDeskApp.Application.Common.Interfaces.Repositories;
using FrontDeskApp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FrontDeskApp.Application.Common.Repositories;

/// <summary>
/// A base repository for performing the command transactions, this also inherits the IBaseReadRepository for quering the objects.
/// All methods can be overriden if different implementation is needed.
/// </summary>
/// <typeparam name="T">This is the entity object to be accessed or to conduct transaction.</typeparam>
public abstract class BaseRepository<T> : BaseReadRepository<T>, IRepository<T>
	where T : class
{
	protected BaseRepository(
		IAppDbContext dbContext,
		ILogger<BaseRepository<T>> logger)
		: base(dbContext, logger)
	{
	}

	public virtual async Task<T> AddAsync(
		T entity,
		CancellationToken cancellationToken = default)
	{
		_dbSet.Add(entity);
		await _dbContext.SaveChangesAsync(cancellationToken);

		return entity;
	}

	public virtual async Task<IEnumerable<T>> AddRangeAsync(
		IEnumerable<T> entities,
		CancellationToken cancellationToken = default)
	{
		_dbSet.AddRange(entities);
		await _dbContext.SaveChangesAsync(cancellationToken);

		return entities;
	}

	public virtual async Task<T> UpdateAsync(
		T entity,
		CancellationToken cancellationToken = default)
	{
		_dbContext.Entry(entity).State = EntityState.Modified;
		if (entity is AuditEntity auditEntity)
		{

			_dbContext.Entry(auditEntity).Property(_ => _.CreatedId).IsModified = false;
			_dbContext.Entry(auditEntity).Property(_ => _.CreatedName).IsModified = false;
			_dbContext.Entry(auditEntity).Property(_ => _.CreatedDateTime).IsModified = false;

		}

		int recordsUpdated = await _dbContext.SaveChangesAsync(cancellationToken);
		if (recordsUpdated > 0)
		{

			var baseEntity = entity as BaseEntity;
			var id = _dbContext.Entry(baseEntity).Property(_ => _.Id).CurrentValue;
			entity = await GetByIdAsync(id, cancellationToken);

			return entity;

		}

		return null;
	}

	/// <summary>
	/// This soft deletes the entity and increments the soft delete flag.
	/// </summary>
	/// <param name="entity">The entity to be deleted, this should have been retrieved first from the database.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns></returns>
	public virtual async Task DeleteAsync(
		T entity,
		CancellationToken cancellationToken = default)
	{
		//_dbSet.Remove(entity);
		_dbContext.Entry(entity).State = EntityState.Deleted;
		if (entity is AuditEntity auditEntity)
		{

			auditEntity.IsSoftDeleted++;
			//_dbSet.Update(entity);
			await _dbContext.SaveChangesAsync(cancellationToken);

		}
	}

	public virtual async Task DeleteRangeAsync(
		IEnumerable<T> entities,
		CancellationToken cancellationToken = default)
	{
		_dbSet.RemoveRange(entities);
		await _dbContext.SaveChangesAsync(cancellationToken);
	}

	public IAppDbContext GetAppDbContext()
	{
		return _dbContext;
	}
}
