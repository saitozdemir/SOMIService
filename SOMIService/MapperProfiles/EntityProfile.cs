using AutoMapper;
using SOMIService.Models.Entities;
using SOMIService.ViewModels;

namespace SOMIService.MapperProfiles
{
    public class EntityProfile:Profile
    {
        public EntityProfile()
        {
            CreateMap<SubscriptionType, SubscriptionTypeViewModel>().ReverseMap();
        }
    }
}
