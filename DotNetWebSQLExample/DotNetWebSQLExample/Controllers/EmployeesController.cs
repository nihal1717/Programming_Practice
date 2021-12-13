using DotNetWebSQLExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DotNetWebSQLExample.Controllers
{
    public class EmployeesController : ApiController
    {
        readonly EmployeeDBContext context = null;
        Employee emp = new Employee();

        private EmployeesController()
        {
            EmployeeDBContext context = new EmployeeDBContext();
            this.context = context;
        }
        public IEnumerable<Employee> Get()
        {
            using (EmployeeDBContext dbContext = new EmployeeDBContext())
            {
                return dbContext.Employees.ToList();
            }
        }
        public Employee Get(int id)
        {
            using (EmployeeDBContext dbContext = new EmployeeDBContext())
            {
                return dbContext.Employees.FirstOrDefault(e => e.ID == id);
            }
        }

        public void Post([FromBody] Employee emp)
        { 
            try
            {
                this.emp.ID = emp.ID;
                
                context.Employees.Add(emp);
                context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                string varr = string.Empty;
            }
        }
    }
}
