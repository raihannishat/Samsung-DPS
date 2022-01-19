using AutoMapper;
using Entity = Samsung.Placing.Entities;
using BusinessObject = Samsung.Placing.BusinessObjects;

namespace Samsung.Placing
{
    public class PlacingProfile : Profile
    {
        public PlacingProfile()
        {
            CreateMap<Entity.Developer, BusinessObject.Developer>().ReverseMap();
            CreateMap<Entity.Team, BusinessObject.Team>().ReverseMap();
        }
    }
}
