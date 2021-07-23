using System.ComponentModel.DataAnnotations;

namespace Webtonic.Models.Entities
{
    public class StudentResults
    {
        [Display(Name = "Student Number")]
        public string StudentId { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        [Display(Name = "Course Code")]
        public string CourseId { get; set; }
        [Display(Name = "Course Description")]
        public string CourseName { get; set; }
        public string Grade{ get; set;}
    }
}