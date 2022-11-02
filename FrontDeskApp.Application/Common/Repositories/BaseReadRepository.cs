using System.Diagnostics.CodeAnalysis;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using FrontDeskApp.Application.Common.Interfaces;
using FrontDeskApp.Application.Common.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FrontDeskApp.Application.Common.Repositories;

/// <summary>
/// A base repository that handles common methods for reading records.
/// All methods can be overriden if different implementation is needed.
/// </summary>
/// <typeparam name="T"></typeparam>
[ExcludeFromCodeCoverage]
public abstract class BaseReadRepository<T> : IReadRepository<T>
	where T : class
{
	protected readonly DbSet<T> _dbSet;
	protected readonly IAppDbContext _dbContext;
	protected readonly ISpecificationEvaluator _specificationEvaluator;
	protected readonly ILogger<BaseReadRepository<T>> _logger;

	protected BaseReadRepository(
		IAppDbContext dbContext,
		ILogger<BaseReadRepository<T>> logger)
		: this(dbContext, SpecificationEvaluator.Default, logger)
	{
	}

	protected BaseReadRepository(
		IAppDbContext dbContext,
		ISpecificationEvaluator specificationEvaluator,
		ILogger<BaseReadRepository<T>> logger)
	{
		_dbContext = Guard.Against.Null(dbContext, nameof(dbContext));
		_specificationEvaluator = Guard.Against.Null(specificationEvaluator, nameof(specificationEvaluator));
		_logger = Guard.Against.Null(logger, nameof(logger));

		_dbSet = _dbContext.Set<T>();
	}

	#region Returns a single record
	public virtual async Task<T> GetByIdAsync(
		Guid id,
		CancellationToken cancellationToken = default)
	{
		return await _dbSet.FindAsync(new object[] { id }, cancellationToken);
	}

	public virtual async Task<T> GetBySpecificationAsync(
		ISpecification<T> spec,
		CancellationToken cancellationToken = default)
	{
		return await ApplySpecification(spec)
			.FirstOrDefaultAsync(cancellationToken);
	}

	public virtual async Task<TResult> GetBySpecificationAsync<TResult>(
		ISpecification<T, TResult> spec,
		CancellationToken cancellationToken = default)
	{
		return await ApplySpecification(spec)
			.FirstOrDefaultAsync(cancellationToken);
	}
	#endregion

	#region Retuns a list of recrds
	public virtual async Task<List<T>> ListAsync(
		CancellationToken cancellationToken = default)
	{
		return await _dbSet.ToListAsync(cancellationToken);
	}

	public virtual async Task<IList<T>> ListAsync(
		ISpecification<T> spec,
		CancellationToken cancellationToken = default)
	{
		var query = await ApplySpecification(spec)
			.ToListAsync(cancellationToken);

		return spec.PostProcessingAction == null ? query : spec.PostProcessingAction(query).ToList();
	}

	public virtual async Task<IList<TResult>> ListAsync<TResult>(
		ISpecification<T, TResult> spec,
		CancellationToken cancellationToken = default)
	{
		var query = await ApplySpecification(spec)
			.ToListAsync(cancellationToken);

		return spec.PostProcessingAction == null ? query : spec.PostProcessingAction(query).ToList();
	}
	#endregion

	#region Returns the number of records and determines if there's a record in the table
	public virtual async Task<int> CountAsync(
		CancellationToken cancellationToken = default)
	{
		return await _dbSet.CountAsync(cancellationToken);
	}

	public virtual async Task<int> CountAsync(
		ISpecification<T> spec,
		CancellationToken cancellationToken = default)
	{
		return await ApplySpecification(spec, true)
			.CountAsync(cancellationToken);
	}

	public virtual async Task<bool> AnyAsync(
		CancellationToken cancellationToken = default)
	{
		return await _dbSet.AnyAsync(cancellationToken);
	}

	public virtual async Task<bool> AnyAsync(
		ISpecification<T> spec,
		CancellationToken cancellationToken = default)
	{
		return await ApplySpecification(spec)
			.AnyAsync(cancellationToken);
	}
	#endregion

	#region Protected Methods
	protected virtual IQueryable<T> ApplySpecification(
		ISpecification<T> specification,
		bool evaluateCriteriaOnly = false)
	{
		return _specificationEvaluator.GetQuery(_dbSet.AsQueryable(), specification, evaluateCriteriaOnly);
	}

	protected virtual IQueryable<TResult> ApplySpecification<TResult>(
		ISpecification<T, TResult> specification)
	{
		return _specificationEvaluator.GetQuery(_dbSet.AsQueryable(), specification);
	}
	#endregion
}
