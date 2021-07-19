﻿using AutoMapper;
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
			CreateMap<WorkShop, WorkShopDto>().ReverseMap();
			CreateMap<WorkShopDay, WorkShopDayDto>().ReverseMap();
			CreateMap<WorkShopMember, WorkShopMemberDto>().ReverseMap();
		}
	}
}
