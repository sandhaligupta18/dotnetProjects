using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAccessLayer
{
	public class Department
	{
		public int Id { get; set; }
		public string? DepartmentName { get; set; }
		public bool IsActive { get; set; }
		public string? CreatedBy { get; set; }
		public DateTime CreatedDate { get; set; }

	}
}
