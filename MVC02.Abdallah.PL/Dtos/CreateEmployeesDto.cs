using System;
using System.ComponentModel.DataAnnotations;
using MVC02.Abdallah.DAL.Models;

namespace MVC02.Abdallah.PL.Dtos
{
    public class CreateEmployeesDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Hire Date is required")]
        public DateTime HireDate { get; set; }

        public DateTime CreateAt { get; set; } = DateTime.Now;

        public bool isActive { get; set; } = true;

        public bool isDeleted { get; set; } = false;

        [Required(ErrorMessage = "Address is required")]
        [RegularExpression(
          @"^[0-9]{1,4}\s[A-Za-z\s]{3,50}\s-\s[A-Za-z\s]{2,50}$",
          ErrorMessage = "Address must be in the format: '123 Street Name - City'"
      )]
        public string Address { get; set; }
        [Phone(ErrorMessage = "Invalid phone number")]
        [StringLength(20, ErrorMessage = "Phone can't exceed 20 characters")]
        public string Phone { get; set; }

        [Range(0, 1000000, ErrorMessage = "Salary must be between 0 and 1,000,000")]
        public decimal Salary { get; set; }
        public int? DepartmentId { get; set; }

        public Department? Department { get; set; }

    }
}
