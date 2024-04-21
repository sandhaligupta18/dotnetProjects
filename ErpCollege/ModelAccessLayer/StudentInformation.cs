using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAccessLayer
{
    public class StudentInformation
    {
        [Key]
        public int Id { get; set; }
        [Required (ErrorMessage = "Name  is required")]
        public string? Name { get; set;}
        [Required(ErrorMessage = "Course Name  is required")]
        public string? CourseName { get; set;}
        [Required(ErrorMessage = "Branch  is required")]
        public string? Branch { get; set;}
        [Required]
        public string? Email { get; set; }
        [Required(ErrorMessage = "MobileNo.  is required")]
        public int Contact { get; set; }
        [Required]
        [Display(Name = "Father's Name")]
        public string? FatherName { get; set; }
        [Required]
        [Display( Name = " Mother's Name")]
        public string? MotherName { get; set; }
        [Required(ErrorMessage = "DateOfBirth  is required")]
        public DateOnly DOB { get; set; }
        [Required]
        public string? Category { get; set; }
        [Required(ErrorMessage = "Address  is required")]
        public string? Address { get; set; }
        [Required]
        public string? RegistrationNo { get; set; }
        [Required(ErrorMessage = "EnrollNo. is required")]
        public string? EnrollmentNo { get; set; }
        [Required]
        public string? Status { get; set; }
        [Required(ErrorMessage = "Please Fill the Admission Date")]
        public string? AdmissionDate { get; set; }
        [Required]
        public string? Gender { get; set; }
    }
}
