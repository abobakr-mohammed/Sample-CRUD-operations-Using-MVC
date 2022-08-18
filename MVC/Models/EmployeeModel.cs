using System;
using System.Data.Entity;
using System.Linq;

namespace D4.Models
{
    public class EmployeeModel : DbContext
    {
       
        public EmployeeModel()
            : base("name=EmployeeModel")
        {
        }


         public virtual DbSet<Employee> Employees { get; set; }
         public virtual DbSet<Department> Departments { get; set; }
    }

}