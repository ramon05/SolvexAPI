using SolvexApi.Core.BaseModel.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolvexApi.Model.Entities
{
	public class Document : BaseEntity
	{
		public string FileName { get; set; } //file-store name
		public string OriginalName { get; set; } //selected file
		public string ContentType { get; set; }
	}
}
