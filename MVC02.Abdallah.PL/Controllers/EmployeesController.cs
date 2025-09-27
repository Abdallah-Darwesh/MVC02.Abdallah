using Microsoft.AspNetCore.Mvc;
using MVC02.Abdallah.BLL.Interfaces;
using MVC02.Abdallah.BLL.Reposatiries;
using MVC02.Abdallah.DAL.Models;
using MVC02.Abdallah.PL.Dtos;

namespace MVC02.Abdallah.PL.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeReposatory _EmployeeRepository;

        public EmployeesController(IEmployeeReposatory EmployeeRepository)
        {
            _EmployeeRepository = EmployeeRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var Employees = _EmployeeRepository.GetAll();
            return View(Employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateEmployeesDto model)
        {
            if (ModelState.IsValid)
            {
                var department = new Employees()
                {
                    Email = model.Email,
                    Name = model.Name,
                    CreateAt = model.CreateAt,
                    HireDate =model.HireDate,
                    isActive = model.isActive,
                    isDeleted = model.isDeleted,
                    Address = model.Address,
                    Phone = model.Phone,
                    Salary = model.Salary,

                };
                var count = _EmployeeRepository.Add(department);

                if (count > 0)
                    return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int? id, string viewName = "Details")
        {
            var department = _EmployeeRepository.Get(id.Value);
            if (department == null) return NotFound();
            return View(viewName, department);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            //if (id == 0) return BadRequest();
            //var department = _departmentRepository.GetById(id);
            //if (department is null) return NotFound();

            return Details(id, "Edit");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, Employees Employee)
        {
            if (ModelState.IsValid)
            {
                if (id != Employee.Id) return BadRequest();
                var count = _EmployeeRepository.Update(Employee);
                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }

            }
            return View(Employee);

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            //if (id == 0) return BadRequest();
            //var department = _departmentRepository.GetById(id);
            //if (department is null) return NotFound();

            return Details(id, "Delete");


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute] int id, Employees Employee)
        {
            if (ModelState.IsValid)
            {
                if (id != Employee.Id) return BadRequest();
                var count = _EmployeeRepository.Delete(Employee);
                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }

            }
            return View(Employee);

        }
    }
}
