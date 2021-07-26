using GenericApi.Core.BaseModel.Base;
using System;

namespace GenericApi.Bl.DTOs
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
