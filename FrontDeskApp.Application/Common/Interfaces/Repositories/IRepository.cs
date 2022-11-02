namespace FrontDeskApp.Application.Common.Interfaces.Repositories;

/// <summary>
/// An interface for performing the command transactions to the database.
/// </summary>
/// <typeparam name="T">The entity to be used for transactions.</typeparam>
public interface IRepository<T> : IReadRepository<T>
	where T : class
{
	Task<T> AddAsync(
		T entity,
		CancellationToken cancellationToken = default);
	Task<IEnumerable<T>> AddRangeAsync(
		IEnumerable<T> entities,
		CancellationToken cancellationToken = default);

	Task<T> UpdateAsync(
		T entity,
		CancellationToken cancellationToken = default);

	Task DeleteAsync(
		T entity,
		CancellationToken cancellationToken = default);
	Task DeleteRangeAsync(
		IEnumerable<T> entities,
		CancellationToken cancellationToken = default);
}
