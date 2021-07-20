using SolvexApi.Core.BaseModel.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolvexApi.Bl.DTOs
{
	public class DocumentDto : BaseEntityDto
	{
		public string FileName { get; set; } //file-store name
		public string OriginalName { get; set; } //selected file
		public string ContentType { get; set; }
	}
}
