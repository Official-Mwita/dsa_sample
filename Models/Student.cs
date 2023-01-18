using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DSA.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Student First Name")]
        public string FirstName { get; set; }

        [DisplayName("Student Last Name")]
        public string LastName { get; set; }

        [DisplayName("Student Grade")]
        public string StudentGrade { get; set; }

        [Required]
        [DisplayName("Student School Email Address")]//There are even more validation annotations that one can use. Use official documentation for more
        public string StudentEmail { get; set; }
    }
}
