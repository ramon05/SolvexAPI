using GenericApi.Core.BaseModel.Base;
using GenericApi.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Bl.DTOs
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
