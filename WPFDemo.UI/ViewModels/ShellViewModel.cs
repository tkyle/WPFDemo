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
    public class ShellViewModel : Conductor<object>.Collection.AllActive, IShellView
    {
        public ShellViewModel()
        {
            EmployeeListViewModel = IoC.Get<IEmployeeListView>();
            Items.Add(EmployeeListViewModel);
        }

        private IEmployeeListView _employeeListViewModel;
        public IEmployeeListView EmployeeListViewModel
        {
            get { return _employeeListViewModel; }
            set
            {
                _employeeListViewModel = value;
                NotifyOfPropertyChange(() => EmployeeListViewModel);
            }
        }

        private IEmployeeInfoView _employeeInfoViewModel;
        public IEmployeeInfoView EmployeeInfoViewModel
        {
            get { return _employeeInfoViewModel; }
            set
            {
                _employeeInfoViewModel = value;
                NotifyOfPropertyChange(() => EmployeeInfoViewModel);
            }
        }

        public void ShowEmployeeInfo(int id)
        {
            EmployeeInfoViewModel = IoC.Get<IEmployeeInfoView>();

            EmployeeInfoViewModel.Employee = EmployeeInformationEdit.GetEmployee(id);

            Items.Add(EmployeeInfoViewModel);
        }
    }
}
