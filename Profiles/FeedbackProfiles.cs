using AutoMapper;
using MediPortal_Feedback.Models;
using MediPortal_Feedback.Models.Dtos;

namespace MediPortal_Feedback.Profiles
{
    public class FeedbackProfiles:Profile
    {
        public FeedbackProfiles()
        {
            CreateMap<Feedback, FeedbackRequestDto>().ReverseMap();
        }
    }
}
