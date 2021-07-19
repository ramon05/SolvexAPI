using SolvexApi.Core.Enums;
using SolvexApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolvexApi.Bl.DTOs
{
    public class WorkShopMemberDto
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public WorkShopMemberDocumentType DocumentType { get; set; }
        public string DocumentTypeValue { get; set; }
        public Gender Gender { get; set; }
        public DateTime? Dob { get; set; }
        public DateTimeOffset? DeletedDate { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string DeletedBy { get; set; }
        public string UpdatedBy { get; set; }
        public int? PhotoId { get; set; }
        public virtual Document Photo { get; set; }
    }
}
