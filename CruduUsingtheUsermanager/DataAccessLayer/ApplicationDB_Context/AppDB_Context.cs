using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ModelAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ApplicationDB_Context
{
	public class AppDB_Context:IdentityDbContext<RegisterUsers, IdentityRole, string>
	{
		public AppDB_Context(DbContextOptions options) : base(options) { }
	}
}
