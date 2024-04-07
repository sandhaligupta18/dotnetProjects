using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CodeFirstApproachCrud.Models
{
    public class EmpDataContext: DbContext
    {
        public EmpDataContext()
           : base("name=MySqlConnection")
        {
        }
        public DbSet<Employee> employees { get; set; }
    }
}