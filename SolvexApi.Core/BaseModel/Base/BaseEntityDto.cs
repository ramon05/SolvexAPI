﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SolvexApi.Core.BaseModel.Base
{
    public interface IBaseEntityDto : IBaseDto
    {
        DateTimeOffset? DeletedDate { get; set; }
        DateTimeOffset CreatedDate { get; set; }
        DateTimeOffset? UpdatedDate { get; set; }
        string CreatedBy { get; set; }
        string DeletedBy { get; set; }
        string UpdatedBy { get; set; }
    }
    public class BaseEntityDto : BaseDto, IBaseEntityDto
    {
        public DateTimeOffset? DeletedDate { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string DeletedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
