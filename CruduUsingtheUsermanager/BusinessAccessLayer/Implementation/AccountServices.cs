using BusinessAccessLayer.Abstract;
using DataAccessLayer.ApplicationDB_Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ModelAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Implementation
{
	public class AccountServices:IAccountServices
	{
		private readonly AppDB_Context _appDBContext;
		private readonly UserManager<RegisterUsers> _userManager;

		public AccountServices(AppDB_Context appDBContext, UserManager<RegisterUsers> userManager)
		{
			_appDBContext = appDBContext;
			_userManager = userManager;
		}


		public async Task<IEnumerable<RegisterUsers>> GetAllUsers()
		{
			return await _userManager.Users.ToListAsync();
		}

		public async Task<bool> CreateUser(RegisterUsers user)
		{
			try
			{
				var users = new RegisterUsers
				{
					Name = user.Name,
					Age = user.Age,
					Address = user.Address,
					EnrollNo = user.EnrollNo,
					PhoneNumber = user.PhoneNumber,
					Email= user.Email,
					Password = user.Password,
					ConfirmPassword = user.ConfirmPassword
				};
				var result = await _userManager.CreateAsync(users, user.Password);


				if (result.Succeeded)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			catch
			{
				return false;
			}
		}



	}
}
