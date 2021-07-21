using AutoMapper;
using SolvexApi.Bl.DTOs;
using SolvexApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolvexApi.Bl.Mapper
{
	public class mainProfile : Profile
	{
		public mainProfile()
		{
			CreateMap<Document, DocumentDto>().ReverseMap();
			CreateMap<WorkShop, WorkShopDto>().ReverseMap();
			CreateMap<WorkShopDay, WorkShopDayDto>().ReverseMap();
			CreateMap<Member, MemberDto>().
				ForMember(dto => dto.PhotoFileName, config => config.MapFrom(entity => entity.Photo.FileName));
			CreateMap<MemberDto, Member>();
			CreateMap<WorkShopMemberDto, WorkShopMember>().ReverseMap();
		}
	}
}
