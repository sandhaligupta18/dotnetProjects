using BussinessAccessLayer.Abstract;
using DataAccessLayer.ApplicationDB_Context;
using Microsoft.EntityFrameworkCore;
using ModelAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessAccessLayer.Implementation
{
	public class AccountServices:IAccountServices
	{
		private readonly AppDB_Context _appDBContext;
		public AccountServices(AppDB_Context appDBContext)
		{
			_appDBContext = appDBContext;
		}
		public async Task<bool> AddDepartment(Department department)
		{
			try
			{
				var ifExist = _appDBContext.Departments.Where(x => x.DepartmentName == department.DepartmentName);
				if (ifExist.Any())
				{
					return false;
				}
				else
				{
					Department departments = new()
					{
						DepartmentName = department.DepartmentName,
						IsActive = department.IsActive,
						CreatedBy = department.CreatedBy,
						CreatedDate = DateTime.Now
					};
					_appDBContext.Departments.Add(departments);
					var result = await _appDBContext.SaveChangesAsync();

					if (result > 0)
					{
						return true;
					}
					else
					{
						return false;
					}
				}
			}
			catch
			{
				return false;
			}
		}

			public  async Task<IEnumerable<Department>> GetDepartments()
		{
			try
			{
				var result = await _appDBContext.Departments.ToListAsync();

				return result;
			}
			catch (Exception)
			{
				throw;
			}
		}

	
		public async Task<bool> UpdateDepartment(Department department)
		{
			try
			{
				_appDBContext.Departments.Update(department);
				var result = await _appDBContext.SaveChangesAsync();
				if (result > 0)
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
		public async Task<Department> GetUserById(int id)
		{
                return  await _appDBContext.Departments.FindAsync(id);           	
		}
        public async Task<bool> DeleteUser( int id )
		{
			try
			{
				if (_appDBContext.Departments == null)
				{
					return false;
				}
                var data = await _appDBContext.Departments.FindAsync(id);
				if(data == null)
				{
					return false;
				}
                 _appDBContext.Departments.Remove(data);
                var remove = await _appDBContext.SaveChangesAsync();

				return true;

            }
			catch(Exception)
			{
				throw;
			}

		} 




	}
}
