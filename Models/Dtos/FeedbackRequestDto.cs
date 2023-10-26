namespace MediPortal_Feedback.Models.Dtos
{
    public class FeedbackRequestDto
    {
        

        public int rating { get; set; }
        public string Message { get; set; } = string.Empty;
        public Guid DoctorId { get; set; }
        
    }
}
