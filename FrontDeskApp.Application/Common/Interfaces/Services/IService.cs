using FrontDeskApp.Application.Common.Results;

namespace FrontDeskApp.Application.Common.Interfaces.Services;

/// <summary>
/// An interface for performing the command transactions, this also inherits the IReadService for quering the objects.
/// </summary>
/// <typeparam name="TEntity">The entity object to be used during the transactions.</typeparam>
/// <typeparam name="TDto">The dto object that contains the information during the transactions.</typeparam>
public interface IService<TEntity, TDto> : IReadService<TEntity, TDto>
	where TEntity : class
	where TDto : class
{
	Task<DtoResult<TDto>> AddAsync(
		TDto dto,
		CancellationToken cancellationToken = default);
	Task<IEnumerable<TDto>> AddRangeAsync(
		IEnumerable<TDto> dtos,
		CancellationToken cancellationToken = default);
	Task<DtoResult<TDto>> UpdateAsync(
		TDto dto,
		CancellationToken cancellationToken = default);
	Task<DtoResult<TDto>> DeleteAsync<TDelete>(
		TDelete dto,
		CancellationToken cancellationToken = default)
		where TDelete : class;
	Task DeleteRangeAsync(
		IEnumerable<TDto> dtos,
		CancellationToken cancellationToken = default);
}
