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
    public class EmployeeInfoViewModel : PropertyChangedBase, IEmployeeInfoView
    {
        public EmployeeInfoViewModel(EmployeeInformationEdit employeeInfo)
        {
            Employee = employeeInfo;
            IsEditing = false;

            States = StateList.GetStateList();
        }

        private EmployeeInformationEdit employee;
        public EmployeeInformationEdit Employee
        {
            get { return employee; }
            set
            {
                employee = value;
                NotifyOfPropertyChange();
            }
        }

        private StateList states;
        public StateList States
        {
            get { return states; }
            set
            {
                states = value;
                NotifyOfPropertyChange();
            }
        }

        private bool isEditing;
        public bool IsEditing
        {
            get { return isEditing; }
            set
            {
                isEditing = value;
                NotifyOfPropertyChange();
            }
        }

        public void EnableEditing()
        {
            IsEditing = true;
            Employee.BeginEdit();
        }

        public void CancelEditing()
        {
            IsEditing = false;
            Employee.CancelEdit();
        }

        public void SaveChanges()
        {
            if (Employee.IsValid && Employee.IsDirty)
            {
                try
                {
                    Employee.ApplyEdit();
                    Employee = Employee.Save();
                }
                catch (Exception e)
                {
                    // Log error

                }

                IsEditing = false;
            }
        }
    }
}
