using Ardalis.Specification;

namespace FrontDeskApp.Application.Common.Interfaces.Repositories;

/// <summary>
/// An interface for defining all get methods to the database, and using Specification Pattern.
/// </summary>
/// <typeparam name="T">Is the entity to be accessed.</typeparam>
public interface IReadRepository<T>
	where T : class
{
	Task<T> GetByIdAsync(
		Guid id,
		CancellationToken cancellationToken = default);
	Task<T> GetBySpecificationAsync(
		ISpecification<T> spec,
		CancellationToken cancellationToken = default);
	Task<TResult> GetBySpecificationAsync<TResult>(
		ISpecification<T, TResult> spec,
		CancellationToken cancellationToken = default);

	Task<List<T>> ListAsync(
		CancellationToken cancellationToken = default);
	Task<IList<T>> ListAsync(
		ISpecification<T> spec,
		CancellationToken cancellationToken = default);
	Task<IList<TResult>> ListAsync<TResult>(
		ISpecification<T, TResult> spec,
		CancellationToken cancellationToken = default);

	Task<int> CountAsync(
		CancellationToken cancellationToken = default);
	Task<int> CountAsync(
		ISpecification<T> spec,
		CancellationToken cancellationToken = default);

	Task<bool> AnyAsync(
		CancellationToken cancellationToken = default);
	Task<bool> AnyAsync(
		ISpecification<T> spec,
		CancellationToken cancellationToken = default);
}
