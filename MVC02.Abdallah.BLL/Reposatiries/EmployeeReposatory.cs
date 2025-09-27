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
    public class EmployeeReposatory :GenericRepository<Employees> , IEmployeeReposatory


    {
        private readonly CompantDbContext _context;

        public EmployeeReposatory(CompantDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Employees> GetEmployeeByName(string Name)
        {
           return _context.Employees.Where(e => e.Name.ToLower().Contains(Name.ToLower())).ToList();
        }

    }




}
