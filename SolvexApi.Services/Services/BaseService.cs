using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using GenericApi.Bl.Extensions;
using GenericApi.Core.Adstract;
using GenericApi.Core.BaseModel.Base;
using GenericApi.Model.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericApi.Services.Services
{
    public interface IBaseService<TEntity, TDto>
    {
        Task<IEnumerable<TDto>> ProjectToDto(IQueryable<TEntity> query);
        IQueryable<TEntity> AsQuery();
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<TDto> GetByIdAsync(int id);
        Task<IEntityOperationResult<TDto>> AddAsync(TDto dto);
        Task<IEntityOperationResult<TDto>> UpdateAsync(int id, TDto dto);
        Task<IEntityOperationResult<TDto>> DeleteByIdAsync(int id);
        IMapper _mapper { get; }
    }
    public class BaseService<TEntity, TDto> : IBaseService<TEntity, TDto>
        where TEntity : class, IBase
        where TDto : class, IBaseDto
    {
        public IMapper _mapper { get; }
        protected readonly IBaseRepository<TEntity> _repository;
        protected readonly IValidator<TDto> _validator;
        public BaseService(IBaseRepository<TEntity> repository, IMapper mapper, IValidator<TDto> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }

        public virtual async Task<IEnumerable<TDto>> ProjectToDto(IQueryable<TEntity> query)
        {
            var list = query.ProjectTo<TDto>(_mapper.ConfigurationProvider);
            return await list.ToListAsync();
        }
        public virtual IQueryable<TEntity> AsQuery()
        {
            return _repository.Query();
        }
        public virtual async Task<IEnumerable<TDto>> GetAllAsync()
        {
            var result = await _repository.Query().ToListAsync();
            var dtos = _mapper.Map<IEnumerable<TDto>>(result);
            return dtos;
        }
        public virtual async Task<TDto> GetByIdAsync(int id)
        {
            var entity = await _repository.Get(id);
            var dto = _mapper.Map<TDto>(entity);
            return dto;
        }
        public virtual async Task<IEntityOperationResult<TDto>> AddAsync(TDto dto)
        {
            var validationResult = _validator.Validate(dto);
            if (validationResult.IsValid is false)
                return validationResult.ToOperationResult<TDto>();

            TEntity entity = _mapper.Map<TEntity>(dto);
            var entityResult = await _repository.Add(entity);

            _mapper.Map(entityResult, dto);

            var result = dto.ToOperationResult();
            return result;
        }
        public virtual async Task<IEntityOperationResult<TDto>> UpdateAsync(int id, TDto dto)
        {
            var validationResult = _validator.Validate(dto);
            if (validationResult.IsValid is false)
                return validationResult.ToOperationResult<TDto>();

            var entity = await _repository.Get(id);

            if (entity is null)
                return null;

            _mapper.Map(dto, entity);

            entity = await _repository.Update(entity);
            _mapper.Map(entity, dto);

            var result = dto.ToOperationResult();
            return result;
        }
        public virtual async Task<IEntityOperationResult<TDto>> DeleteByIdAsync(int id)
        {
            var entity = await _repository.Get(id);

            if (entity is null)
                return null;

            entity = await _repository.Delete(id);
            var dto = _mapper.Map<TDto>(entity);

            var result = dto.ToOperationResult();
            return result;
        }
    }
}
