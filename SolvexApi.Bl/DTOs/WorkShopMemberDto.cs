using GenericApi.Core.BaseModel.Base;
using GenericApi.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Bl.DTOs
{
    public class WorkShopMemberDto : BaseEntityDto
    {
        public WorkShopMemberRole Role { get; set; }
        public int WorkShopId { get; set; }
        public int MemberId { get; set; }
    }
}
