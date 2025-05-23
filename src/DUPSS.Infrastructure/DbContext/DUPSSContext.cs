using DUPSS.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DUPSS.Infrastructure.DbContext
{
    public class DUPSSContext : IdentityDbContext<AppUser>
    {
        public DbSet<BookingRequest> BookingRequests { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseRegistration> CourseRegistrations { get; set; }
        public DbSet<CourseSection> CourseSections { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<QuestionOption> QuestionOptions { get; set; }
        public DbSet<QuestionOptionTestResult> QuestionOptionTestResults { get; set; }
        public DbSet<QueuingCourse> QueuingCourses { get; set; }
        public DbSet<QueuingStep> QueuingSteps { get; set; }
        public DbSet<Reason> Reasons { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestQuestion> TestQuestions {get; set; }
        public DbSet<TestRecommendation> TestRecommendations { get; set; }
        public DbSet<TestResult> TestResults { get; set; }
        public DbSet<Tracking> Trackings { get; set; }
        public DbSet<Workshop> Workshops { get; set; }
        public DbSet<WorkshopRegistration> WorkshopRegistrations { get; set; }
        public DbSet<Blog> Blogs { get; set; }

        public DUPSSContext(DbContextOptions<DUPSSContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //// Configure the Tracking -> Step relationship to prevent cascade delete
            builder.Entity<Tracking>(entiy => 
                entiy.HasOne(t => t.Step)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction) // Prevent cascade delete for Tracking -> Step relationship
            )
                ;

            // Configure the CourseRegistration -> Tracking relationship
            builder.Entity<CourseRegistration>()
                .HasMany(cr => cr.Trackings)
                .WithOne(x => x.CourseRegistration)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure Comment self-referencing relationship
            builder.Entity<Comment>()
                .HasOne(c => c.ParentComment)
                .WithMany(c => c.Replies)
                .HasForeignKey(c => c.ParentCommentId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
