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
    public class GenericRepository<T> : IGenaricReposatory<T> where T : BaseEntity
    {
        private readonly CompantDbContext _context;
        public GenericRepository(CompantDbContext context)
        {
            this._context = context;
        }
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();

        }

        public T? Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Add(T model)
        {
            _context.Set<T>().Add(model);
        }

        public void Update(T model)
        {
            _context.Set<T>().Update(model);
             
        }
        public void Delete(T model)
        {
            _context.Set<T>().Remove(model);
        }

    }
}
