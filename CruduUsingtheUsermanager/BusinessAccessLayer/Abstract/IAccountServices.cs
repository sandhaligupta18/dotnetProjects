﻿using ModelAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Abstract
{
	public interface IAccountServices
	{
		public Task<bool> CreateUser(RegisterUsers user);
		public Task<IEnumerable<RegisterUsers>> GetAllUsers();
	}
}