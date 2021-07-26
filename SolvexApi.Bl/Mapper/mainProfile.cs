using AutoMapper;
using GenericApi.Bl.DTOs;
using GenericApi.Model.Entities;

namespace GenericApi.Bl.Mapper
{
    public class mainProfile : Profile
	{
		public mainProfile()
		{
			CreateMap<Document, DocumentDto>().ReverseMap();
			CreateMap<WorkShop, WorkShopDto>().ReverseMap();
			CreateMap<WorkShopDay, WorkShopDayDto>().ReverseMap();
			CreateMap<User, UserDto>().
				ForMember(dto => dto.PhotoFileName, config => config.MapFrom(entity => entity.Photo.FileName));
			CreateMap<UserDto, User>();
			CreateMap<WorkShopMemberDto, WorkShopMember>().ReverseMap();
		}
	}
}
