using Csla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDemo.DAL;

namespace WPFDemo.Business.BusinessObjects
{
    [Serializable()]
    public class EmployeeList : ReadOnlyListBase<EmployeeList, EmployeeInformation>
    {
        public void RemoveChild(int projectId)
        {
            var iro = IsReadOnly;
            IsReadOnly = false;
            try
            {
                var item = this.Where(r => r.Id == projectId).FirstOrDefault();
                if (item != null)
                {
                    var index = this.IndexOf(item);
                    Remove(item);
                }
            }
            finally
            {
                IsReadOnly = iro;
            }
        }

        public static EmployeeList GetEmployeeList()
        {
            return DataPortal.Fetch<EmployeeList>();
        }

        private void DataPortal_Fetch()
        {
            DataPortal_Fetch(null);
        }

        private void DataPortal_Fetch(string name)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            IsReadOnly = false;

            using (var ctx = DalFactory.GetManager())
            {
                var dal = ctx.GetProvider<DAL.Interfaces.IEmployeeInformationDal>();

                var list = dal.Fetch();

                foreach (var item in list)
                    Add(DataPortal.FetchChild<EmployeeInformation>(item));
            }

            IsReadOnly = true;
            RaiseListChangedEvents = rlce;
        }
    }
}
