using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAccessLayer
{
	public class StudentRegister:IdentityUser
	{
		[Required(ErrorMessage = "First name is required")]
		public string? FirstName { get; set; }
		[Required(ErrorMessage = "Last name is required")]
		public string? LastName { get; set; }
		[Required(ErrorMessage = "TeacherId  is required")]
		public string? StudendId { get; set; }
		[Required(ErrorMessage = "EnrollNo. is required")]
		public string? EnrollNo { get; set; }

		[Required(ErrorMessage = "DateOfBirth  is required")]
		public DateOnly? DateOfBirth { get; set; }
		[Required(ErrorMessage = "Address  is required")]
		public string? Address { get; set; }
		[Required(ErrorMessage = "MobileNo.  is required")]
		[Phone]
		public int? Mobile { get; set; }
		[Required(ErrorMessage = "Department  is required")]
		public string? Department { get; set; }
		[Required(ErrorMessage = "Branch  is required")]
		public string? Branch { get; set; }

		[Required(ErrorMessage = "Password  is required")]
		[StringLength(15, MinimumLength = 6, ErrorMessage = "The length of password atleast 6 ")]
		public string? Password { get; set; }
		[Required(ErrorMessage = "ConfirmPassword  is required")]
		[Compare("Password", ErrorMessage = "Enter the correct Paswword")]
		public string? ConfirmPassword { get; set; }

	}
}
