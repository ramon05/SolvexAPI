using GenericApi.Core.BaseModel.Base;
using GenericApi.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Model.Entities
{
    public class WorkShopMember : BaseEntity
    {
        public WorkShopMemberRole Role { get; set; }
        public int WorkShopId { get; set; }
        public int MemberId { get; set; }
        public virtual WorkShop WorkShop { get; set; }
        public virtual Member Member { get; set; }
    }
}
