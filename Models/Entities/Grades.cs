using System.ComponentModel.DataAnnotations;

namespace Webtonic.Models.Entities
{
    public class Grades
    {
        [Display(Name = "Student Number")]
        public string StudentId { get; set; }
        public string CourseId { get; set; }
        public string Grade { get; set; }
    }
}