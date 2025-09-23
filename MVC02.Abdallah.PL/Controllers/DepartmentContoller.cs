using Microsoft.AspNetCore.Mvc;
using MVC02.Abdallah.BLL.Interfaces;
using MVC02.Abdallah.DAL.Models;
using MVC02.Abdallah.PL.Dtos;

namespace MVC02.Abdallah.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var departments = _departmentRepository.GetAll();
            return View(departments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateDepartmentDto model)
        {
            if (ModelState.IsValid)
            {
                var department = new Department()
                {
                    Code = model.Code,
                    Name = model.Name,
                    CreateAt = model.CreateAt
                };
                var count = _departmentRepository.Add(department);

                if (count > 0)
                    return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        
        [HttpGet]
        public IActionResult Details(int? id,string viewName="Details")
        {
            var department = _departmentRepository.GetById(id.Value );
            if (department == null) return NotFound();
            return View(viewName,department);
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
        public IActionResult Edit([FromRoute] int id, Department department)
        {
            if (ModelState.IsValid)
            {
                if(id != department.Id) return BadRequest();
                var count = _departmentRepository.Update(department);
                if (count > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }

            }
            return View(department);

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
        public IActionResult Delete([FromRoute] int id, Department department)
        {
            if (ModelState.IsValid)
            {
                if (id != department.Id) return BadRequest();
                var count = _departmentRepository.Delete(department);
                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }

            }
            return View(department);

        }

    }
}
