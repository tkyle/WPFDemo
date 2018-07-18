using Csla.Core;
using Csla.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDemo.Business.Rules
{
    public class RequiredWhenAnyHasValue : Csla.Rules.CommonRules.Required
    {
        public RequiredWhenAnyHasValue(IPropertyInfo primaryProperty, params IPropertyInfo[] additionalRequired) : base(primaryProperty)
        {
            if (InputProperties == null) InputProperties = new List<IPropertyInfo>();
            InputProperties.AddRange(additionalRequired);
        }

        protected override void Execute(RuleContext context)
        {
            var anyHasValue = context.InputPropertyValues.Any(p => !string.IsNullOrEmpty(p.Value.ToString()));

            if (anyHasValue)
            {
                base.Execute(context);
            }
        }
    }
}
