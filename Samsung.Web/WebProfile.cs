using AutoMapper;
using Samsung.Placing.BusinessObjects;
using Samsung.Web.Areas.Admin.Models;

namespace Samsung.Web
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            CreateMap<CreateDeveloperModel, Developer>().ReverseMap();
            CreateMap<EditDeveloperModel, Developer>().ReverseMap();
            CreateMap<EditTeamModel, Team>().ReverseMap();
            CreateMap<CreateTeamModel, Team>().ReverseMap();
        }
    }
}
