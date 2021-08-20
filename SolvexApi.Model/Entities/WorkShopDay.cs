﻿using GenericApi.Core.BaseModel.Base;
using GenericApi.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Model.Entities
{
    public class WorkShopDay : BaseEntity
    {
        public WeekDay Day { get; set; }
        public WorkShopDayMode Mode { get; set; }
        public string ModeLocation { get; set; }
        public DateTimeOffset StartHour { get; set; }
        public DateTimeOffset? EndHour { get; set; }
        public int WorkShopId { get; set; }
        public virtual WorkShop WorkShop { get; set; }
    }
}
