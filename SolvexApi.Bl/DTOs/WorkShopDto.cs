using System;
using System.Collections.Generic;
using System.Text;

namespace SolvexApi.Bl.DTOs
{
    public class WorkShopDto
    {
        public WorkShopDto()
        {
            Days = new HashSet<WorkShopDayDto>();
        }
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ContentSupport { get; set; }
        public DateTimeOffset? DeletedDate { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string DeletedBy { get; set; }
        public string UpdatedBy { get; set; }
        public virtual ICollection<WorkShopDayDto> Days { get; set; }
    }
}
