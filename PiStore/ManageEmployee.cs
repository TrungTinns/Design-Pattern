using System;
using PiStore.Class.Command;
using System.Windows.Forms;
using DAL;
using PiStore.Class.Repository;
using PiStore.Class.ValidationStrategy;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics.Tracing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;
using PiStore.Class;
using Employee = PiStore.Class.Entity.Employee;
using System.Security.Principal;


namespace PiStore
{
	public partial class ManageEmployee : Form
	{
        private ICommand _command;
		private Invoker _invoker;
        private readonly EmployeeList _employeeList;
        private IEmployeeRepository _employeeRepository;
        private readonly ValidationContext _validationContext;
        private readonly EmployeeInformationControl _employeeInformationControl;

        public ManageEmployee()
		{
			InitializeComponent();
			_invoker = new Invoker();
			_employeeRepository = new EmployeeRepository(PiStoreDbContext.Instance);
			_validationContext = new ValidationContext();
            _employeeList = new EmployeeList(dataGridView);
            _employeeInformationControl = new EmployeeInformationControl(NameBox, EmailBox, PhoneBox, AddressBox, SalaryBox);
        }

        public void clear()
        {
            NameBox.Text = "";
            EmailBox.Text = "";
            PhoneBox.Text = "";
            AddressBox.Text = "";
            SalaryBox.Text = "";
        }

        private void ManageEmployee_Load(object sender, EventArgs e)
		{
			dataGridView.DataSource = _employeeRepository.GetEmployees();
		}

		private void btn_show_Click(object sender, EventArgs e)
		{
			ManageEmployee_Load(null, null);
		}

        private void btn_delete_Click(object sender, EventArgs e)
		{
           
        }

		private void BtnAdd_Click(object sender, EventArgs e)
		{
			if(!CheckValidation()) return;

			DAL.Employee employee = new DAL.Employee() 
			{
				EmployeeName = NameBox.Text,
				EmployeeEmail = EmailBox.Text,
				EmployeePhone = PhoneBox.Text,
				EmployeeAddress = AddressBox.Text,
				EmployeeSalary = int.Parse(SalaryBox.Text),
				HireDate = DateTime.Parse(HireDateBox.Text),
			};

			_command = new AddEmployeeCommand(employee, _employeeRepository);
			_invoker.SetCommand(_command);
			_invoker.Execute();
			clear();
			ManageEmployee_Load(null, null);
		}

        private bool CheckValidation()
        {
            _validationContext.SetStrategy(new EmptyValidationStrategy());

            if (!_validationContext.Validate(NameBox.Text) || !_validationContext.Validate(EmailBox.Text) || !_validationContext.Validate(PhoneBox.Text) || !_validationContext.Validate(AddressBox.Text) || !_validationContext.Validate(SalaryBox.Text))
            {
                MessageBox.Show("Please fill in the blank");
                return false;
            }

            _validationContext.SetStrategy(new IntegerValidationStrategy());

            if (!_validationContext.Validate(SalaryBox.Text))
            {
                MessageBox.Show("Salary must be number");
                return false;
            }

            _validationContext.SetStrategy(new EmailValidationStrategy());

            if (!_validationContext.Validate(EmailBox.Text))
            {
                MessageBox.Show("Invalid email");
                return false;
            }

            _validationContext.SetStrategy(new PhoneValidationStrategy());

            if (!_validationContext.Validate(PhoneBox.Text))
            {
                MessageBox.Show("Invalid phone number");
                return false;
            }

            return true;
        }

		private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
            _command = new CellClickCommand(_employeeList, _employeeInformationControl, e);
            _invoker.SetCommand(_command);
            _invoker.Execute();
        }
	}
}