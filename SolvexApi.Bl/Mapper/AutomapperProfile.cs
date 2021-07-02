using AutoMapper;
using SolvexApi.Bl.DTOs;
using SolvexApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolvexApi.Bl.Mapper
{
	public class AutomapperProfile : Profile
	{
		public AutomapperProfile()
		{
			CreateMap<Document, DocumentDto>().ReverseMap();
		}
	}
}
