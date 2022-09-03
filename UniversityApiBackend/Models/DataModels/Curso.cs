using System.ComponentModel.DataAnnotations;

namespace UniversityApiBackend.Models.DataModels
{
    public enum level
    {
        essencial = 0,
        intermediate,
        advanced
    }
    public class Curso : BaseEntity
    {

        [Required, StringLength(int.MaxValue)]
        public string Name { get; set; } = string.Empty;
        [Required, StringLength(280)]
        public string ShortDescription { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string TargetAudiences { get; set; } = string.Empty;

        [Required]
        public string Goals { set; get; } = string.Empty;

        [Required]
        public string Requirements { set; get; } = string.Empty;

        [Required]
        public level Level { set; get; }
    }
}
