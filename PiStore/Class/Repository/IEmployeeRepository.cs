using DAL;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Employee = PiStore.Class.Entity.Employee;

namespace PiStore.Class.Repository
{
	public interface IEmployeeRepository
	{
		void AddEmployee(DAL.Employee employee);

        List<Entity.Employee> GetEmployees();
	
		void DeleteEmployee(DAL.Employee employee);
	}
}
