using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Core.BaseModel.Base
{
    public interface IBaseEntity : IBase
    {
        DateTimeOffset? DeletedDate { get; set; }
        DateTimeOffset CreatedDate { get; set; }
        DateTimeOffset? UpdatedDate { get; set; }
        string CreatedBy { get; set; }
        string DeletedBy { get; set; }
        string UpdatedBy { get; set; }
    }
    public class BaseEntity : Base, IBaseEntity
    {
        public DateTimeOffset? DeletedDate { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string DeletedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
