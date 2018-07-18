using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDemo.DAL.Mock.MockDbTypes;

namespace WPFDemo.DAL.Mock
{
    public class MockDb
    {
        public static List<EmployeeData> Employees { get; private set; }
        public static List<string> States { get; private set; }

        static MockDb()
        {
            Employees = new List<EmployeeData>
            {
              new EmployeeData
              {
                  Id = 1,
                  FirstName = "Bob",
                  LastName = "Shark",
                  Title = "Software Developer",
                  Address = "123 Test Ln.",
                  City = "Test City",
                  State = "NY",
                  Zip = "10108",
                  ProfilePicture = ""
              },
              new EmployeeData
              {
                  Id = 2,
                  FirstName = "Susan",
                  LastName = "Smith",
                  Title = "QA",
                  Address = "555 Another Rd.",
                  City = "Test Town",
                  State = "CA",
                  Zip = "90210",
                  ProfilePicture = ""
              },
              new EmployeeData
              {
                  Id = 3,
                  FirstName = "George",
                  LastName = "Costanza",
                  Title = "Yankees",
                  Address = "333 This Rd.",
                  City = "New York",
                  State = "NY",
                  Zip = "10108",
                  ProfilePicture = ""
              },
              new EmployeeData
              {
                  Id = 4,
                  FirstName = "Another",
                  LastName = "Employee",
                  Title = "New Guy",
                  Address = "222 That St.",
                  City = "St. Louis",
                  State = "MO",
                  Zip = "63109",
                  ProfilePicture = ""
              },
              new EmployeeData
              {
                  Id = 5,
                  FirstName = "Jason",
                  LastName = "Bourne",
                  Title = "Yankees",
                  Address = "123 Some Ln.",
                  City = "New York",
                  State = "NY",
                  Zip = "10108",
                  ProfilePicture = ""
              }
            };

            States = new List<string>
            {
                "AL","AK","AZ","AR","CA","CO", "CT","DE","DC","FL","GA","HI", "ID","IL", "IN","IA","KS","KY","LA","ME",
                "MD","MA","MI","MN","MS","MO","MT","NE","NV","NH","NJ","NM","NY","NC","ND","OH", "OK","OR","PA",
                "RI","SC","SD", "TN","TX","UT","VT","VA","WA","WV","WI","WY"
             };
        }
    }
}
