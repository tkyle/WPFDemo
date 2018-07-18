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
    public class StateList : ReadOnlyListBase<StateList, State>
    {
        public static StateList GetStateList()
        {
            return DataPortal.Fetch<StateList>();
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
                var dal = ctx.GetProvider<DAL.Interfaces.IStateDal>();

                var list = dal.Fetch();

                foreach (var item in list)
                    Add(DataPortal.FetchChild<State>(item));
            }

            IsReadOnly = true;
            RaiseListChangedEvents = rlce;
        }
    }
}
