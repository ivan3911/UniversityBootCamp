using System.ComponentModel.DataAnnotations;

namespace UniversityApiBackend.Models.DataModels
{
    public class Category : BaseEntity
    {
        [Required]
        public string Name { set; get; } = string.Empty;

        public ICollection<Course> Courses { get; set; } = new List<Course>();  
    }
}
