using MediPortal_Feedback.Data;
using MediPortal_Feedback.Models;
using MediPortal_Feedback.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace MediPortal_Feedback.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly ApplicationDbContext _context;

        public FeedbackService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> AddFeedback(Feedback feedback)
        {
            await _context.Feedbacks.AddAsync(feedback);
            await _context.SaveChangesAsync();
            return "Thank you for your feedback";
        }

        public async Task<string> DeleteFeedback(Feedback feedback)
        {
            _context.Feedbacks.Remove(feedback);
            await _context.SaveChangesAsync();
            return "Feedback was deleted successfully";
        }

        public async Task<List<Feedback>> GetAllFeedbacks()
        {
            return await _context.Feedbacks.ToListAsync();
        }

        public async Task<List<Feedback>> GetFeedbacks(Guid id)
        {
            
            return await _context.Feedbacks.Where(f => f.DoctorId == id).ToListAsync();
        }
    }
}
