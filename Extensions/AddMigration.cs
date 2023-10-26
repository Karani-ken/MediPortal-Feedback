using MediPortal_Feedback.Data;
using Microsoft.EntityFrameworkCore;

namespace MediPortal_Feedback.Extensions
{
    public static class AddMigration
    {
        public static IApplicationBuilder UseMigration(this IApplicationBuilder app)
        {

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var _db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }

            return app;
        }
    }
}
