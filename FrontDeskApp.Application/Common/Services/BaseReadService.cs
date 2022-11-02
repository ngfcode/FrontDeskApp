using Ardalis.GuardClauses;
using Ardalis.Specification;
using FrontDeskApp.Application.Common.Interfaces.Repositories;
using FrontDeskApp.Application.Common.Interfaces.Services;
using FrontDeskApp.Application.Common.Results;
using FrontDeskApp.Shared.Constants;
using MapsterMapper;
using Microsoft.Extensions.Logging;

namespace FrontDeskApp.Application.Common.Services;

/// <summary>
/// A base service that handles common methods for reading records.
/// All methods can be overriden if different implementation is needed.
/// </summary>
/// <typeparam name="TEntity"></typeparam>
/// <typeparam name="TDto"></typeparam>
public abstract class BaseReadService<TEntity, TDto> : IReadService<TEntity, TDto>
	where TEntity : class
	where TDto : class
{
	protected readonly IReadRepository<TEntity> _repositoryRead;
	protected readonly ILogger<BaseService<TEntity, TDto>> _logger;
	protected readonly IMapper _mapper;

	protected BaseReadService(
		IReadRepository<TEntity> repository,
		ILogger<BaseService<TEntity, TDto>> logger,
		IMapper mapper)
	{
		_repositoryRead = Guard.Against.Null(repository, nameof(repository));
		_logger = Guard.Against.Null(logger, nameof(logger));
		_mapper = Guard.Against.Null(mapper, nameof(mapper));
	}

	public virtual async Task<DtoResult<TDto>> GetByIdAsync(
		Guid id,
		CancellationToken cancellationToken = default)
	{
		var entity = await _repositoryRead.GetByIdAsync(id, cancellationToken);
		if (entity is object)
		{
			return new DtoResult<TDto>(_mapper.Map<TDto>(entity));
		}

		return new DtoResult<TDto>(ErrorMessages.NotFound);
	}

	public virtual async Task<DtoResult<TDto>> GetBySpecificationAsync(
		ISpecification<TEntity> spec,
		CancellationToken cancellationToken = default)
	{
		var entity = await _repositoryRead.GetBySpecificationAsync(
			spec,
			cancellationToken);
		if (entity is object)
		{
			return new DtoResult<TDto>(_mapper.Map<TDto>(entity));
		}

		return new DtoResult<TDto>(ErrorMessages.NotFound);
	}

	public virtual async Task<DtoResult<TResult>> GetBySpecificationAsync<TResult>(
		ISpecification<TEntity> spec,
		CancellationToken cancellationToken = default)
	{
		var entity = await _repositoryRead.GetBySpecificationAsync(
			spec,
			cancellationToken);
		if (entity is object)
		{
			return new DtoResult<TResult>(_mapper.Map<TResult>(entity));
		}

		return new DtoResult<TResult>(ErrorMessages.NotFound);
	}

	public virtual async Task<QueryResult<TDto>> ListAsync(
		CancellationToken cancellationToken = default)
	{
		var query = await _repositoryRead.ListAsync(cancellationToken);
		return new QueryResult<TDto>(_mapper.Map<IList<TDto>>(query));
	}

	/// <summary>
	/// This method list all records based from specification, without paging and returning all records.
	/// </summary>
	/// <typeparam name="TResult"></typeparam>
	/// <param name="spec"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	public virtual async Task<QueryResult<TResult>> ListBySpecificationAsync<TResult>(
		ISpecification<TEntity> spec,
		CancellationToken cancellationToken = default)
		where TResult : class
	{
		var entties = await _repositoryRead.ListAsync(spec, cancellationToken);
		if (entties is object && entties.Count > 0)
		{

			return new QueryResult<TResult>(
				_mapper.Map<IList<TResult>>(entties));

		}

		return new QueryResult<TResult>();
	}

	/// <summary>
	/// This method list all records based from specification, and includes total records.
	/// </summary>
	/// <typeparam name="TResult"></typeparam>
	/// <param name="spec"></param>
	/// <param name="currentPage"></param>
	/// <param name="pageSize"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	public virtual async Task<QueryResult<TResult>> ListBySpecificationAsync<TResult>(
		ISpecification<TEntity> spec,
		int currentPage = 0,
		int pageSize = 0,
		CancellationToken cancellationToken = default)
		where TResult : class
	{
		var entties = await _repositoryRead.ListAsync(spec, cancellationToken);
		if (entties is object && entties.Count > 0)
		{

			int totalRecords = await _repositoryRead
				.CountAsync(spec, cancellationToken);

			return new QueryResult<TResult>(
				_mapper.Map<IList<TResult>>(entties),
				totalRecords,
				currentPage,
				pageSize);

		}

		return new QueryResult<TResult>();
	}

	public async Task<int> CountAsync(
		CancellationToken cancellationToken = default)
	{
		return await _repositoryRead.CountAsync(cancellationToken);
	}

	public async Task<int> CountBySpecificationAsync(
		ISpecification<TEntity> spec,
		CancellationToken cancellationToken = default)
	{
		return await _repositoryRead.CountAsync(spec, cancellationToken);
	}

	public async Task<bool> AnyAsync(
		CancellationToken cancellationToken = default)
	{
		return await _repositoryRead.AnyAsync(cancellationToken);
	}

	public async Task<bool> AnyBySpecificationAsync(
		ISpecification<TEntity> spec,
		CancellationToken cancellationToken = default)
	{
		return await _repositoryRead.AnyAsync(spec, cancellationToken);
	}
}
