using SolvexApi.Core.BaseModel.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolvexApi.Bl.DTOs
{
	public class DocumentDto
	{
		public int Id { get; set; }
		public bool Deleted { get; set; }
		public string FileName { get; set; } //file-store name
		public string OriginalName { get; set; } //selected file
		public string ContentType { get; set; }
		public DateTimeOffset? DeletedDate { get; set; }
		public DateTimeOffset CreatedDate { get; set; }
		public DateTimeOffset? UpdatedDate { get; set; }
		public string CreatedBy { get; set; }
		public string DeletedBy { get; set; }
		public string UpdatedBy { get; set; }
	}
}
