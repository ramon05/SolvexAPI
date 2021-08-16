using GenericApi.Core.BaseModel.Base;
using GenericApi.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Model.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime? Dob { get; set; }
        public DocumentType DocumentType { get; set; }
        public string DocumentTypeValue { get; set; }
        public int? PhotoId { get; set; }
        public virtual Document Photo { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        public UserRole UserRole { get; set; }
    }
}
