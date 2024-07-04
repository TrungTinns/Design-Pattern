using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PiStore.Class
{
    public class EmployeeList
    {
        private readonly DataGridView _dataGridView;

        public EmployeeList(DataGridView dataGridView)
        {
            _dataGridView = dataGridView;
        }

        public void Update(Entity.Employee emp)
        {
            // Check if an item with the same name already exists in the DataGridView
            int rowIndex = FindEmployeeRowIndex(emp.EmployeeName);

            if (rowIndex >= 0)
            {
                // Update the data of the existing item
                _dataGridView.Rows[rowIndex].Cells[2].Value = emp.EmployeeEmail;
                _dataGridView.Rows[rowIndex].Cells[3].Value = emp.EmployeePhone;
                _dataGridView.Rows[rowIndex].Cells[4].Value = emp.EmployeeAddress;
                _dataGridView.Rows[rowIndex].Cells[5].Value = emp.EmployeeSalary;
            }
            else
            {
                // Add a new row for the item
                _dataGridView.Rows.Add(emp.EmployeeName, emp.EmployeeEmail, emp.EmployeePhone, emp.EmployeeAddress, emp.EmployeeSalary);
            }
        }

        private int FindEmployeeRowIndex(string EmpName)
        {
            foreach (DataGridViewRow row in _dataGridView.Rows)
            {
                // Case insensitive
                // data grid view has one null row
                if (row.Cells[1].Value != null && string.Equals(row.Cells[1].Value.ToString(), EmpName,
                        StringComparison.OrdinalIgnoreCase))
                {
                    return row.Index;
                }
            }

            return -1;
        }

        public void ClearEmployeeList()
        {
            _dataGridView.Rows.Clear();
            _dataGridView.Refresh();
        }

        public Entity.Employee GetEmployee(DataGridViewCellEventArgs eventArgs)
        {
            if (eventArgs.RowIndex < 0)
            {
                throw new IndexOutOfRangeException("Can't get item from this cell");
            }

            var row = _dataGridView.Rows[eventArgs.RowIndex];

            if (row.Cells[0].Value == null || row.Cells[1].Value == null || row.Cells[2].Value == null || row.Cells[3].Value == null || row.Cells[4].Value == null || row.Cells[5].Value == null)
            {
                throw new NullReferenceException("Can't get item from an empty cell.");
            }

            var name = row.Cells[1].Value.ToString();
            var email = row.Cells[2].Value.ToString();
            var phone = row.Cells[3].Value.ToString();
            var address = row.Cells[4].Value.ToString();
            var salary = int.Parse(row.Cells[5].Value.ToString());

            return new Entity.Employee() { EmployeeName = name, EmployeeEmail = email, EmployeePhone = phone, EmployeeAddress = address, EmployeeSalary = salary };
        }

        public List<Entity.Employee> GetEmployeeAsList()
        {
            var emps = new List<Entity.Employee>();

            foreach (DataGridViewRow row in _dataGridView.Rows)
            {
                if (row.Cells[0].Value == null || row.Cells[1].Value == null || row.Cells[2].Value == null || row.Cells[3].Value == null || row.Cells[4].Value == null || row.Cells[5].Value == null) continue;

                var emp = new Entity.Employee
                {
                    EmployeeName = row.Cells[1].Value.ToString(),
                    EmployeeEmail = row.Cells[2].Value.ToString(),
                    EmployeePhone = row.Cells[3].Value.ToString(),
                    EmployeeAddress = row.Cells[4].Value.ToString(),
                    EmployeeSalary = int.Parse(row.Cells[5].Value.ToString())
                };

                emps.Add(emp);
            }

            return emps;
        }

        public void ShowEmployeesInDataGridView(List<Entity.Employee> emps)
        {
            // Clear any existing data from the DataGridView
            _dataGridView.Rows.Clear();

            // Add each item to the DataGridView
            foreach (var emp in emps)
            {
                _dataGridView.Rows.Add(emp.EmployeeName, emp.EmployeeEmail, emp.EmployeePhone, emp.EmployeeAddress, emp.EmployeeSalary);
            }
        }
    }
}
