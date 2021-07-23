using System.ComponentModel.DataAnnotations;

namespace Webtonic.Models.Entities
{
    public class Students
    {
        [Display(Name = "Student Number")]
        public string StudentId { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
    }
}