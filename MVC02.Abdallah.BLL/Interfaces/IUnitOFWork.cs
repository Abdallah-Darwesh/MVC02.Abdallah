using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC02.Abdallah.BLL.Interfaces;

namespace MVC02.Abdallah.BLL.Interfaces
{
    public interface IUnitOFWork:IDisposable
    {
        IDepartmentRepository DepartmentRepository { get; }
        IEmployeeReposatory EmployeeRepository { get; }
        int Complete();
    }
}

