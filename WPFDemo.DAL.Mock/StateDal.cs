using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDemo.DAL.DTOs;
using WPFDemo.DAL.Interfaces;

namespace WPFDemo.DAL.Mock
{
    public class StateDal : IStateDal
    {
        public List<StateDto> Fetch()
        {
            var result = from s in MockDb.States
                         select new StateDto
                         {
                             Abbreviation = s
                         };

            return result.ToList();
        }
    }
}
