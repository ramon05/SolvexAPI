using SolvexApi.Core.BaseModel.Base;
using SolvexApi.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolvexApi.Model.Entities
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
