using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDemo.DAL.DTOs;
using WPFDemo.DAL.Exceptions;
using WPFDemo.DAL.Interfaces;
using WPFDemo.DAL.Mock.MockDbTypes;

namespace WPFDemo.DAL.Mock
{
    public class EmployeeInformationDal : IEmployeeInformationDal
    {
        public List<EmployeeInformationDto> Fetch()
        {
            var result = from r in MockDb.Employees
                         select new EmployeeInformationDto
                         {
                             Id = r.Id,
                             FirstName = r.FirstName,
                             LastName = r.LastName,
                             Title = r.Title,
                             Address = r.Address,
                             City = r.City,
                             State = r.State,
                             Zip = r.Zip
                         };
            return result.ToList();
        }

        public List<EmployeeInformationDto> Fetch(string lastNameFilter)
        {
            var result = from r in MockDb.Employees
                         where r.LastName.Contains(lastNameFilter)
                         select new EmployeeInformationDto
                         {
                             Id = r.Id,
                             FirstName = r.FirstName,
                             LastName = r.LastName,
                             Title = r.Title,
                             Address = r.Address,
                             City = r.City,
                             State = r.State,
                             Zip = r.Zip
                         };
            return result.ToList();
        }

        public EmployeeInformationDto Fetch(int id)
        {
            var result = (from r in MockDb.Employees
                          where r.Id == id
                          select new EmployeeInformationDto
                          {
                              Id = r.Id,
                              FirstName = r.FirstName,
                              LastName = r.LastName,
                              Title = r.Title,
                              Address = r.Address,
                              City = r.City,
                              State = r.State,
                              Zip = r.Zip

                          }).FirstOrDefault();

            if (result == null)
                throw new DataNotFoundException("Project");

            return result;
        }

        public bool Exists(int id)
        {
            var result = (from r in MockDb.Employees
                          where r.Id == id
                          select r.Id).Count() > 0;
            return result;
        }

        public void Insert(EmployeeInformationDto item)
        {
            item.Id = MockDb.Employees.Max(c => c.Id) + 1;

            //item.LastChanged = MockDb.GetTimeStamp();

            var newItem = new EmployeeData
            {
                Id = item.Id,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Title = item.Title,
                Address = item.Address,
                City = item.City,
                State = item.State,
                Zip = item.Zip,
                ProfilePicture = item.ProfilePicture
            };

            MockDb.Employees.Add(newItem);
        }

        public void Update(EmployeeInformationDto item)
        {
            var data = (from r in MockDb.Employees
                        where r.Id == item.Id
                        select r).FirstOrDefault();
            if (data == null)
                throw new DataNotFoundException("Project"); ;

            data.FirstName = item.FirstName;
            data.LastName = item.LastName;
            data.Title = item.Title;
            data.Address = item.Address;
            data.City = item.City;
            data.State = item.State;
            data.Zip = item.Zip;
            data.ProfilePicture = item.ProfilePicture;
        }

        public void Delete(int id)
        {
            var data = (from r in MockDb.Employees
                        where r.Id == id
                        select r).FirstOrDefault();
            if (data != null)

                MockDb.Employees.Remove(data);
        }
    }
}
