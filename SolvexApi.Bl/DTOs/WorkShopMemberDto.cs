using SolvexApi.Core.BaseModel.Base;
using SolvexApi.Core.Enums;
using SolvexApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolvexApi.Bl.DTOs
{
    public class WorkShopMemberDto : BaseEntityDto
    {
        public WorkShopMemberRole Role { get; set; }
        public int WorkShopId { get; set; }
        public int MemberId { get; set; }
    }
}
