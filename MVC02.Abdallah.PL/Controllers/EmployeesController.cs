using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MVC02.Abdallah.BLL.Interfaces;
using MVC02.Abdallah.BLL.Reposatiries;
using MVC02.Abdallah.DAL.Models;
using MVC02.Abdallah.PL.Dtos;
using MVC02.Abdallah.PL.Helpers;

namespace MVC02.Abdallah.PL.Controllers
{
    public class EmployeesController : Controller
    {


        //private readonly IEmployeeReposatory _EmployeeRepository;
        //private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOFWork _unitofwork;
        public EmployeesController(IUnitOFWork unitofwork, IMapper mapper)
        {
            //_EmployeeRepository = EmployeeRepository;
            //_departmentRepository = departmentRepository;
            _mapper = mapper;
            _unitofwork = unitofwork;
        }

        [HttpGet]
        public IActionResult Index(string? SearchInput)
        {
            IEnumerable<Employees> Employees;

            if (string.IsNullOrEmpty(SearchInput))
            {
                Employees = _unitofwork.EmployeeRepository.GetAll();
            }
            else
            {
                Employees = _unitofwork.EmployeeRepository.GetEmployeeByName(SearchInput);
            }

            ViewBag.Messege = "Hello From ViewBag";
            return View(Employees);
        }


        [HttpGet]
        public IActionResult Create()
        {
           
                var departments = _unitofwork.DepartmentRepository.GetAll();
                ViewData["departments"] = departments;
            
            return View(new CreateEmployeesDto());
        }


        [HttpPost]
        public IActionResult Create(CreateEmployeesDto model)
        {
            if (ModelState.IsValid)
            {
                //var employee = new Employees()
                //{
                //    Email = model.Email,
                //    Name = model.Name,
                //    CreateAt = model.CreateAt,
                //    HireDate = model.HireDate,
                //    isActive = model.isActive,
                //    isDeleted = model.isDeleted,
                //    Address = model.Address,
                //    Phone = model.Phone,
                //    Salary = model.Salary,
                //    DepartmentId = model.DepartmentId 
                //};

                if(model.image is not null)
                {
                    model.imageName = DocumentSettings.UploadFile(model.image, "Images");
                }

                var employee =_mapper.Map<Employees>(model);

                 _unitofwork.EmployeeRepository.Add(employee);
                var count = _unitofwork.Complete();

                if (count > 0)
                {
                    TempData["Messege"] = "Employee Created Successfully";
                    return RedirectToAction(nameof(Index));
                }
            }

            ViewData["departments"] = _unitofwork.DepartmentRepository.GetAll();
            return View(model);
        }


        [HttpGet]
        public IActionResult Details(int? id, string viewName = "Details")
        {
            var department = _unitofwork.EmployeeRepository.Get(id.Value);
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
        public IActionResult Edit([FromRoute] int id, Employees Employee,CreateEmployeesDto model)
        {
            if (ModelState.IsValid)
            {
                if(model.imageName is not null)
                {
                    DocumentSettings.DeleteFile(model.imageName, "Images");
                }
                else
                {
                    DocumentSettings.UploadFile(model.image, "Images");

                }

                if (id != Employee.Id) return BadRequest();
               _unitofwork.EmployeeRepository.Update(Employee);
                var count = _unitofwork.Complete();

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
                   _unitofwork.EmployeeRepository.Delete(Employee);
                var count = _unitofwork.Complete();

                if (count > 0)
                {
                    if(Employee.ImageName is not null)
                    {
                    DocumentSettings.DeleteFile(Employee.ImageName, "Images");

                    }
                    return RedirectToAction(nameof(Index));
                }

            }
            return View(Employee);

        }
    }
}
