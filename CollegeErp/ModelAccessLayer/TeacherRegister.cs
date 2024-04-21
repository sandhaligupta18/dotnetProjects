using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAccessLayer
{
    public class TeacherRegister:IdentityUser
    {
        public string? TeacherName { get; set;}
        public string? TeacherPassword { get; set;}
        public string? TeacherEmail { get; set;}
        public string? TeacherId { get; set;}
    }
}
