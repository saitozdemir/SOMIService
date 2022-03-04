using AutoMapper;
using SOMIService.Models;
using SOMIService.Models.Entities;
using SOMIService.ViewModels;

namespace SOMIService.MapperProfiles
{
    public class FailureProfile:Profile
    {
        public FailureProfile()
        {
            CreateMap<FailureLogging, CustomerFailureViewModel>().ReverseMap();
        }
    }
}
