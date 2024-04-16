using ModelAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessAccessLayer.Abstract
{
	public interface IAccountServices
	{
		public Task<bool> AddDepartment(Department department);
		public Task<bool> UpdateDepartment(Department department);
		public Task<bool> DeleteUser(int Id);
		public Task<Department> GetUserById(int id);
		public Task<IEnumerable<Department>> GetDepartments();


	}
}
