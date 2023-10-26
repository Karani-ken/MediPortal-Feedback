using MediPortal_Feedback.Models;
using Microsoft.EntityFrameworkCore;

namespace MediPortal_Feedback.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Feedback> Feedbacks { get; set; }
    }
}
