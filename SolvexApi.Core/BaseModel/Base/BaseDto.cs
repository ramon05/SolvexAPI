using System;
using System.Collections.Generic;
using System.Text;

namespace SolvexApi.Core.BaseModel.Base
{

	public interface IBaseDto
	{
		int? Id { get; set; }
		bool Deleted { get; set; }
	}
	public class BaseDto : IBaseDto
	{
		public virtual int? Id { get; set; }
		public virtual bool Deleted { get; set; }
	}

}
