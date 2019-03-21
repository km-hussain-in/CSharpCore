using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DemoApp.Models
{
    public class Feedback
    {
        [Key]
        public string Name {get; set;}

        [StringLength(128)]
        public string Comment {get; set;}

        [Range(1, 5)]
        public int Rating {get; set;}
    }

    public class FeedbackModel : DbContext
    {
        public DbSet<Feedback> Feedbacks {get; set;}

        public FeedbackModel(DbContextOptions<FeedbackModel> options) : base(options) 
        {
            Database.EnsureCreated();
        }
    }
}
