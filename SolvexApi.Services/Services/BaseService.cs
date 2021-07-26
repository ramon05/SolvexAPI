using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using GenericApi.Bl.Extensions;
using GenericApi.Core.Adstract;
using GenericApi.Core.BaseModel.Base;
using GenericApi.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GenericApi.Services.Services
{
    public interface IBaseService<TEntity, TDto>
    {
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<TDto> GetAsync(int id);
        Task<IEntityOperationResult<TDto>> AddAsync(TDto dto);
        Task<IEntityOperationResult<TDto>> UpdateAsync(int id, TDto dto);
        Task<IEntityOperationResult<TDto>> DeleteByIdAsync(int id);
    }
    public class BaseService<TEntity, TDto> : IBaseService<TEntity, TDto>
        where TEntity : class, IBase
        where TDto : class, IBaseDto
    {
        protected readonly IBaseRepository<TEntity> _repository;
        protected readonly IMapper _mapper;
        protected readonly IValidator<TDto> _validator;

        public BaseService(IBaseRepository<TEntity> repository, IMapper mapper, IValidator<TDto> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<IEnumerable<TDto>> GetAllAsync()
        {
            var result = await _repository.Query().ToListAsync();
            var dtos = _mapper.Map<IEnumerable<TDto>>(result);
            return dtos;
        }

        public async Task<TDto> GetAsync(int id)
        {
            var result = await _repository.Query().ToListAsync();
            var dto = _mapper.Map<TDto>(result);
            return dto;
        }

        public async Task<IEntityOperationResult<TDto>> AddAsync(TDto dto)
        {
            var validationResult = _validator.Validate(dto);
            if(validationResult.IsValid is false)
                return validationResult.ToOperationResult<TDto>();

            TEntity entity = _mapper.Map<TEntity>(dto);
            var Entityresult = await _repository.Add(entity);

            _mapper.Map(Entityresult, dto);

            var result = dto.ToOperationResult<TDto>();
            return result;
        }

        public async Task<IEntityOperationResult<TDto>> UpdateAsync(int id, TDto dto)
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

            var result = dto.ToOperationResult<TDto>();
            return result;
        }

        public async Task<IEntityOperationResult<TDto>> DeleteByIdAsync(int id)
        {
            var entity = await _repository.Get(id);

            if (entity is null)
                return null;

            entity = await _repository.Delete(id);
            var dto = _mapper.Map<TDto>(entity);

            var result = dto.ToOperationResult<TDto>();
            return result;
        }
    }
}
