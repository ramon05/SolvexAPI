using SolvexApi.Core.BaseModel.Base;
using SolvexApi.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolvexApi.Bl.DTOs
{
    public class WorkShopDayDto : BaseEntityDto
    {
        public WeekDay Day { get; set; }
        public WorkShopDayMode Mode { get; set; }
        public string ModeLocation { get; set; }
        public TimeSpan StartHour { get; set; }
        public TimeSpan? EndHour { get; set; }
    }
}
