using Csla.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDemo.Business.BusinessObjects;

namespace WPFDemo.Business.Rules
{
    public class NYRule : BusinessRule
    {
        protected override void Execute(RuleContext context)
        {
            var target = (EmployeeInformationEdit)context.Target;

            if (target.State == "NY" && target.Zip != "10108")
                context.AddErrorResult("If your state is NY you must have 10108 for the zip. It's the only zip we allow for this demo.");
        }
    }
}
