using GenericApi.Core.BaseModel.Base;
using GenericApi.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Bl.DTOs
{
    public class MemberDto : BaseEntityDto
    {
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public WorkShopMemberDocumentType DocumentType { get; set; }
        public string DocumentTypeValue { get; set; }
        public Gender Gender { get; set; }
        public DateTime? Dob { get; set; }
        public int? PhotoId { get; set; }
        public string PhotoFileName { get; set; }
    }
}
