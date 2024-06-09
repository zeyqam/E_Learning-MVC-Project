namespace E_Learning_MVC_Project.Models
{
    public class Course:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int Duration { get; set; } 
        public int StudentsCount { get; set; }
        public int Rating { get; set; }
        public int ReviewsCount { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
    }
}
