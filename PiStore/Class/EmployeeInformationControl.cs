using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PiStore.Class
{
    public class EmployeeInformationControl
    {
        private readonly TextBox _nameBox;
        private readonly TextBox _emailBox;
        private readonly TextBox _phoneBox;
        private readonly TextBox _addressBox;
        private readonly TextBox _salaryBox;


        public EmployeeInformationControl(TextBox nameBox, TextBox emailBox, TextBox phoneBox, TextBox addressBox, TextBox salaryBox)
        {
            _nameBox = nameBox;
            _emailBox = emailBox;
            _phoneBox = phoneBox;
            _addressBox = addressBox;
            _salaryBox = salaryBox;
        }

        public void ResetInformation()
        {
            _nameBox.Text = "";
            _emailBox.Text = "";
            _phoneBox.Text = "";
            _addressBox.Text = "";
            _salaryBox.Text = "";
            _nameBox.Focus();
        }

        public void ShowInformation(Entity.Employee emp)
        {
            _nameBox.Text = emp.EmployeeName;
            _emailBox.Text = emp.EmployeeEmail;
            _phoneBox.Text = emp.EmployeePhone;
            _addressBox.Text = emp.EmployeeAddress;
            _salaryBox.Text = emp.EmployeeSalary.ToString();
        }
    }
}
