using AutoMapper;
using MVC02.Abdallah.DAL.Models;
using MVC02.Abdallah.PL.Dtos;

namespace MVC02.Abdallah.PL.Mapping
{
    public class EmployeeProfile: Profile
    {
        public EmployeeProfile()
        {
            CreateMap< CreateEmployeesDto, Employees>().ReverseMap();
        }
    }
}
