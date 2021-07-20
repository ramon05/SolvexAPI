using SolvexApi.Core.BaseModel.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolvexApi.Bl.DTOs
{
    public class WorkShopDto : BaseEntityDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ContentSupport { get; set; }
    }
}
