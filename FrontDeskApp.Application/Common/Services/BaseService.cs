using FrontDeskApp.Application.Common.Dtos;
using FrontDeskApp.Application.Common.Interfaces;
using FrontDeskApp.Application.Common.Interfaces.Repositories;
using FrontDeskApp.Application.Common.Interfaces.Services;
using FrontDeskApp.Application.Common.Results;
using FrontDeskApp.Shared.Constants;
using MapsterMapper;
using Microsoft.Extensions.Logging;

namespace FrontDeskApp.Application.Common.Services;

/// <summary>
/// A base service for performing the command transactions, this also inherits the IReadService for quering the objects.
/// All methods can be overriden if different implementation is needed.
/// </summary>
/// <typeparam name="TEntity"></typeparam>
/// <typeparam name="TDto"></typeparam>
public abstract class BaseService<TEntity, TDto> : BaseReadService<TEntity, TDto>, IService<TEntity, TDto>
	where TEntity : class
	where TDto : class
{
	protected readonly IRepository<TEntity> _repository;

	protected BaseService(
		IRepository<TEntity> repository,
		ILogger<BaseService<TEntity, TDto>> logger,
		IMapper mapper)
		: base(repository, logger, mapper)
	{
		_repository = repository;
	}

	public virtual async Task<DtoResult<TDto>> AddAsync(
		TDto dto,
		CancellationToken cancellationToken = default)
	{
		var entity = _mapper.Map<TEntity>(dto);
		entity = await _repository.AddAsync(entity, cancellationToken);
		if (entity is not null)
		{
			return new DtoResult<TDto>(_mapper.Map<TDto>(entity));
		}

		return new DtoResult<TDto>(ErrorMessages.AddError);
	}

	public virtual async Task<IEnumerable<TDto>> AddRangeAsync(
		IEnumerable<TDto> dtos,
		CancellationToken cancellationToken = default)
	{
		var entities = _mapper.Map<IEnumerable<TEntity>>(dtos);
		var result = await _repository.AddRangeAsync(entities, cancellationToken);
		if (result is not null)
		{
			return _mapper.Map<IEnumerable<TDto>>(result);
		}

		return null;
	}

	public virtual async Task<DtoResult<TDto>> UpdateAsync(
		TDto dto,
		CancellationToken cancellationToken = default)
	{
		var id = (Guid?)dto.GetType().GetProperty(nameof(BaseDto.Dto.Id)).GetValue(dto, null);
		if (id is not null)
		{

			var entity = await _repository.GetByIdAsync(id.Value, cancellationToken);
			if (entity is null)
			{
				return new DtoResult<TDto>(ErrorMessages.NotFound);
			}

			entity = _mapper.Map<TEntity>(dto);
			entity = await _repository.UpdateAsync(entity, cancellationToken);

			if (entity is not null)
			{
				return new DtoResult<TDto>(_mapper.Map<TDto>(entity));
			}
		}

		return new DtoResult<TDto>(ErrorMessages.UpdateError);
	}

	public virtual async Task<DtoResult<TDto>> DeleteAsync<TDelete>(
		TDelete dto,
		CancellationToken cancellationToken = default)
		where TDelete : class
	{
		var id = (Guid?)dto.GetType().GetProperty(nameof(BaseDto.Dto.Id)).GetValue(dto, null);
		if (id is object)
		{

			var entity = await _repository.GetByIdAsync(id.Value, cancellationToken);
			if (entity is null)
			{
				return new DtoResult<TDto>(ErrorMessages.NotFound);
			}

			await _repository.DeleteAsync(entity, cancellationToken);

		}

		return new DtoResult<TDto>();
	}

	public virtual async Task DeleteRangeAsync(
		IEnumerable<TDto> dtos,
		CancellationToken cancellationToken = default)
	{
		var entities = _mapper.Map<IEnumerable<TEntity>>(dtos);
		await _repository.DeleteRangeAsync(entities, cancellationToken);
	}
}
