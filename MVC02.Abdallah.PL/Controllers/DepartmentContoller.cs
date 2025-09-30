using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MVC02.Abdallah.BLL.Interfaces;
using MVC02.Abdallah.DAL.Models;
using MVC02.Abdallah.PL.Dtos;

namespace MVC02.Abdallah.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IUnitOFWork _unitofwork;
        private readonly IMapper _mapper;
        //private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IUnitOFWork unitofwork,IMapper mapper)
        {
            _unitofwork = unitofwork;
           _mapper = mapper;
            //_departmentRepository = departmentRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var departments = _unitofwork.DepartmentRepository.GetAll();
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
                _unitofwork.DepartmentRepository.Add(department);
                var count = _unitofwork.Complete();

                if (count > 0)
                    return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        
        [HttpGet]
        public IActionResult Details(int? id,string viewName="Details")
        {
            var department = _unitofwork.DepartmentRepository.Get(id.Value );
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
                 _unitofwork.DepartmentRepository.Update(department);
                var count = _unitofwork.Complete();

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
                
                _unitofwork.DepartmentRepository.Delete(department);
                var count = _unitofwork.Complete();

                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }

            }
            return View(department);

        }

    }
}
