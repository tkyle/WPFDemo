using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDemo.DAL.DTOs;

namespace WPFDemo.DAL.Interfaces
{
    public interface IEmployeeInformationDal
    {
        List<EmployeeInformationDto> Fetch();
        List<EmployeeInformationDto> Fetch(string nameFilter);
        EmployeeInformationDto Fetch(int id);
        bool Exists(int id);
        void Insert(EmployeeInformationDto item);
        void Update(EmployeeInformationDto item);
        void Delete(int id);
    }
}
