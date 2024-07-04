using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;
using System.Windows.Forms;
using PiStore.Class.Repository;

namespace PiStore.Class.Command
{
    public class CellClickCommand : ICommand
    {
        private readonly EmployeeList _employeeList;
        private readonly EmployeeInformationControl _employeeInformationControl;
        private readonly DataGridViewCellEventArgs _cellEventArgs;

        public CellClickCommand(EmployeeList employeeList, EmployeeInformationControl employeeInformationControl, DataGridViewCellEventArgs eventArgs)
        {
            _employeeList = employeeList;
            _cellEventArgs = eventArgs;
            _employeeInformationControl = employeeInformationControl;
        }

        public void Execute()
        {
            try
            {
                var item = _employeeList.GetEmployee(_cellEventArgs);

                _employeeInformationControl.ShowInformation(item);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
