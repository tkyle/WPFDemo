using Csla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDemo.DAL.DTOs;

namespace WPFDemo.Business.BusinessObjects
{
    [Serializable]
    public class State : ReadOnlyBase<State>
    {
        public static readonly PropertyInfo<string> AbbreviationProperty = RegisterProperty<string>(c => c.Abbreviation);
        public string Abbreviation
        {
            get { return GetProperty(AbbreviationProperty); }
            set { LoadProperty(AbbreviationProperty, value); }
        }

        private void Child_Fetch(StateDto item)
        {
            Abbreviation = item.Abbreviation;
        }
    }
}
