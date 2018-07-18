using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDemo.Business.BusinessObjects;

namespace WPFDemo.UI.Interfaces
{
    public interface IEmployeeInfoView
    {
        EmployeeInformationEdit Employee { get; set; }
    }
}
