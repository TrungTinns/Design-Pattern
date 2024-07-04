using PiStore.Class.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using PiStore.Class.Repository;

namespace PiStore.Class.Command
{
    public class DeleteEmployeeCommand : ICommand
    {
        private readonly Employee _employee;
        private readonly IEmployeeRepository _employeeRepository;

        public DeleteEmployeeCommand(Employee employee, IEmployeeRepository employeeRepository)
        {
            _employee = employee;
            _employeeRepository = employeeRepository;
        }

        public void Execute()
        {
            _employeeRepository.DeleteEmployee(_employee);
        }
    }
}
