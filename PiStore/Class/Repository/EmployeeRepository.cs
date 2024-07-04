using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using Employee = PiStore.Class.Entity.Employee;
using System.Windows.Forms;

namespace PiStore.Class.Repository
{
	public class EmployeeRepository : IEmployeeRepository
	{
		private readonly PiStoreDBEntities _dbContext;

        public EmployeeRepository(PiStoreDBEntities dbContext)
		{
			_dbContext = dbContext;
		}

		public void AddEmployee(DAL.Employee employee)
		{
			_dbContext.Employees.Add(employee);
			_dbContext.SaveChanges();
		}
        public void DeleteEmployee(DAL.Employee employee)
        {
            _dbContext.Employees.Remove(employee);
            _dbContext.SaveChanges();
        }

        public List<Entity.Employee> GetEmployees()
		{
			return _dbContext.Employees.Select(e => new Employee {
				EmployeeID = e.EmployeeID,
				EmployeeName = e.EmployeeName,
				EmployeeEmail = e.EmployeeEmail,
				EmployeePhone = e.EmployeePhone,
				EmployeeAddress = e.EmployeeAddress,
				EmployeeSalary = (int)(e.EmployeeSalary != null ? e.EmployeeSalary : 0),
				HireDate = e.HireDate,
			}).ToList();
		}
	}
}
