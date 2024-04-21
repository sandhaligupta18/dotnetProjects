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
        [Required]
        public string? StudentName { get; set; }
        [Required]
        public string? StudentPassword { get; set; }
        [Required]
        public string? StudentEmail { get; set; }
        [Required]
        public string?  StudentEnrollNo{ get; set; }
    }
}
