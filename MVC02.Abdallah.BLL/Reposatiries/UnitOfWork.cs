using MVC02.Abdallah.BLL.Interfaces;
using MVC02.Abdallah.DAL.Data.Contexsts;

namespace MVC02.Abdallah.BLL.Reposatiries
{
    public class UnitOfWork : IUnitOFWork
    {
        private readonly CompantDbContext _context;

        public IDepartmentRepository DepartmentRepository { get; }
        public IEmployeeReposatory EmployeeRepository { get; }

        public UnitOfWork(
            CompantDbContext context,
            IDepartmentRepository departmentRepository,
            IEmployeeReposatory employeeRepository)
        {
            _context = context;
            DepartmentRepository = departmentRepository;
            EmployeeRepository = employeeRepository;
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
        _context.Dispose();
        }
    }
}
