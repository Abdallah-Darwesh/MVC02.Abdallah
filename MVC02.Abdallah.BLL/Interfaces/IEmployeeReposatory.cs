using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC02.Abdallah.DAL.Models;

namespace MVC02.Abdallah.BLL.Interfaces
{
    public interface IEmployeeReposatory: IGenaricReposatory<Employees>
    {
        //IEnumerable<Employees> GetAll();

        //Employees Get(int id);
        //int Add(Employees model);
        //int Update(Employees model);
        //int Delete(Employees model);
        List<Employees> GetEmployeeByName(string Name);
    }
}
