using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDemo.Business.BusinessObjects;
using WPFDemo.UI.Interfaces;

namespace WPFDemo.UI.ViewModels
{
    public class EmployeeListViewModel : PropertyChangedBase, IEmployeeListView
    {
        public EmployeeListViewModel(ShellViewModel parent)
        {
            Employees = EmployeeList.GetEmployeeList();
        }

        EmployeeList employees;
        public EmployeeList Employees
        {
            get { return employees; }
            set
            {
                employees = value;
                NotifyOfPropertyChange(() => Employees);
            }
        }

        private EmployeeInformation selectedEmployee;
        public EmployeeInformation SelectedEmployee
        {
            get { return selectedEmployee; }
            set
            {
                if (selectedEmployee != value)
                {
                    selectedEmployee = value;
                    NotifyOfPropertyChange();

                    // TODO: Refactor IoC container to be something that will allow me to avoid using this
                    // service locator pattern to get an instance of the ShellView (I keep getting ciruclar dependencies / stackoverflows).
                    // I think SimpleContainer is a little too limited to help with this situation.
                    IoC.Get<IShellView>().ShowEmployeeInfo(selectedEmployee.Id);
                }
            }
        }
    }
}
