using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDemo.DAL.Interfaces;

namespace WPFDemo.DAL
{
    public class DalFactory
    {
        private static Type _dalType;

        public static IDalManager GetManager()
        {
            // TODO: This can probably be done via dependency injection
            if (_dalType == null)
            {
                var dalTypeName = ConfigurationManager.AppSettings["DalManagerType"];
                if (!string.IsNullOrEmpty(dalTypeName))
                    _dalType = Type.GetType(dalTypeName);
                else
                    throw new NullReferenceException("DalManagerType");
                if (_dalType == null)
                    throw new ArgumentException(string.Format("Type {0} could not be found", dalTypeName));
            }

            return (IDalManager)Activator.CreateInstance(_dalType);
        }
    }
}
