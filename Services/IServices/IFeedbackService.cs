using MediPortal_Feedback.Models;

namespace MediPortal_Feedback.Services.IServices
{
    public interface IFeedbackService
    {
        Task<string> AddFeedback(Feedback feedback);
        Task<string> DeleteFeedback(Feedback feedback);
        Task<List<Feedback>> GetFeedbacks(Guid id);//get doctors feedback
        Task<List<Feedback>> GetAllFeedbacks();//get all feedbacks
    }
}
