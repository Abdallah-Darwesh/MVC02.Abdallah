using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC02.Abdallah.BLL.Interfaces;
using MVC02.Abdallah.DAL.Data.Contexsts;
using MVC02.Abdallah.DAL.Models;

namespace MVC02.Abdallah.BLL.Reposatiries
{
    public class EmployeeReopsatory :GenericRepository<Employees> , IEmployeeReposatory


    {
        public EmployeeReopsatory(CompantDbContext context) : base(context)
        {
        }
    }




}
