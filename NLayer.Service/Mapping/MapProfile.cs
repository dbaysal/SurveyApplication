using AutoMapper;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.DTOs.RequestDTOs;
using NLayer.Core.DTOs.ResponseDTOs;
using NLayer.Core.Models;

namespace NLayer.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
	        CreateMap<User, AuthenticatedUser>().ReverseMap();
	        CreateMap<User, Login>().ReverseMap();
	        CreateMap<Survey, CreateNewSurvey>().ReverseMap();
            CreateMap<Survey, SurveyDisplay>().ReverseMap();

        }

    }
}
