using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using System.Reflection;

namespace NLayer.Repository
{
    public class AppDbContext : DbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>()
           .HasKey(t => new { t.UserId, t.RoleId });

            modelBuilder.Entity<UserRole>()
           .HasOne(pt => pt.User)
           .WithMany(p => p.UserRoles)
           .HasForeignKey(pt => pt.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(pt => pt.Role)
                .WithMany(t => t.UserRoles)
                .HasForeignKey(pt => pt.RoleId);


        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
	    public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<RadioButtonSurveyQuestion> RadioButtonSurveyQuestions { get; set; }
        public DbSet<CheckBoxSurveyQuestion> CheckBoxSurveyQuestions { get; set; }
        public DbSet<SurveyQuestionItem> SurveyQuestionItems { get; set; }
        public DbSet<TextAreaSurveyQuestion> TextAreaSurveyQuestions { get; set; }
        public DbSet<TextBoxSurveyQuestion> TextBoxSurveyQuestions { get; set; }
        public DbSet<OpenEndedQuestionAnswer> OpenEndedQuestionAnswers { get; set; }





	}
}
