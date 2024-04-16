﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAccessLayer
{
	public class RegisterUser:IdentityUser
	{
		public string? Name { get; set; }
		public int Age { get; set; }
		public string? Address { get; set; }
		public int? EnrollNo { get; set; }
		public int? Mobile { get; set; }
		public string? Password { get; set; }
		public string? ConfirmPassword { get; set; }

	}
}