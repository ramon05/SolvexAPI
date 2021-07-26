﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Core.Adstract
{
    public interface IEntityOperationResult<TDto>
    {
        bool IsSuccess { get; }
        TDto Entity { get; set; }
        ICollection<string> Errors { get; set; }
    }

    public class EntityOperationResult<TDto> : IEntityOperationResult<TDto>
    {
        public EntityOperationResult(TDto entity = default)
        {
            Errors = new List<string>();
            Entity = entity;
        }
        public bool IsSuccess => Errors.Count == 0;
        public TDto Entity { get; set; }
        public ICollection<string> Errors { get; set; }
    }
}
