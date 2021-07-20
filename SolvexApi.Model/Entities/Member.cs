using SolvexApi.Core.BaseModel.Base;
using SolvexApi.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolvexApi.Model.Entities
{
    public class Member : BaseEntity
    {
        public Member()
        {
            WorkShops = new HashSet<WorkShopMember>();
        }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public WorkShopMemberDocumentType DocumentType { get; set; }
        public string DocumentTypeValue { get; set; }
        public Gender Gender { get; set; }
        public DateTime? Dob { get; set; }

        public int? PhotoId { get; set; }
        public virtual Document Photo { get; set; }
        public virtual ICollection<WorkShopMember> WorkShops { get; set; }
    }
}
