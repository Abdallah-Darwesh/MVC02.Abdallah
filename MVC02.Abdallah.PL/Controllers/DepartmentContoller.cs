using System;
using Microsoft.AspNetCore.Mvc;
using MVC02.Abdallah.BLL.Interfaces;
using MVC02.Abdallah.BLL.Reposatiries;
using MVC02.Abdallah.DAL.Models;
using MVC02.Abdallah.PL.Dtos;

namespace MVC02.Abdallah.PL.Controllers
{
    public class DepartmentContoller : Controller
    {
        private readonly IDepartmentRepository _departmentReposatory;
        public DepartmentContoller(IDepartmentRepository departmentReposatory)
        {
            _departmentReposatory = departmentReposatory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var departments = _departmentReposatory.GetAll();
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
            if(ModelState.IsValid)
            {
                var department = new Department()
                {
                    Code=model.Code,
                    Name=model.Name,
                    CreateAt = model.CreateAt
                };
              var count=  _departmentReposatory.Add(department);

                if (count > 0) 
                {
                    return RedirectToAction(nameof(Index));
                }

            }
            return View();
        }
    }
}
