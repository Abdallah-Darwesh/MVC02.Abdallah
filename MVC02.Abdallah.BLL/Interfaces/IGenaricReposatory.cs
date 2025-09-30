using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC02.Abdallah.DAL.Models;

namespace MVC02.Abdallah.BLL.Interfaces
{
    public interface IGenaricReposatory<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Add(T model);
        void Update(T model);
        void Delete(T model);
    }
}
