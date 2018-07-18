using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDemo.DAL.DTOs;

namespace WPFDemo.DAL.Interfaces
{
    public interface IStateDal
    {
        List<StateDto> Fetch();
    }
}
