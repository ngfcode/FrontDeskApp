using Ardalis.Specification;
using FrontDeskApp.Application.Common.Results;

namespace FrontDeskApp.Application.Common.Interfaces.Services;

/// <summary>
/// An interface that defines all query methods.
/// </summary>
/// <typeparam name="TEntity">The entity object to use for retrieving data.</typeparam>
/// <typeparam name="TDto">The expected dto object to be returned.</typeparam>
public interface IReadService<TEntity, TDto>
	where TEntity : class
	where TDto : class
{
	Task<DtoResult<TDto>> GetByIdAsync(
		Guid id,
		CancellationToken cancellationToken = default);
	Task<DtoResult<TDto>> GetBySpecificationAsync(
		ISpecification<TEntity> spec,
		CancellationToken cancellationToken = default);
	Task<DtoResult<TResult>> GetBySpecificationAsync<TResult>(
		ISpecification<TEntity> spec,
		CancellationToken cancellationToken = default);

	Task<QueryResult<TDto>> ListAsync(
		CancellationToken cancellationToken = default);
	Task<QueryResult<TResult>> ListBySpecificationAsync<TResult>(
		ISpecification<TEntity> spec,
		CancellationToken cancellationToken = default)
		where TResult : class;
	Task<QueryResult<TResult>> ListBySpecificationAsync<TResult>(
		ISpecification<TEntity> spec,
		int currentPage = 0,
		int pageSize = 0,
		CancellationToken cancellationToken = default)
		where TResult : class;

	Task<int> CountAsync(
		CancellationToken cancellationToken = default);
	Task<int> CountBySpecificationAsync(
		ISpecification<TEntity> spec,
		CancellationToken cancellationToken = default);

	Task<bool> AnyAsync(
		CancellationToken cancellationToken = default);
	Task<bool> AnyBySpecificationAsync(
		ISpecification<TEntity> spec,
		CancellationToken cancellationToken = default);
}
