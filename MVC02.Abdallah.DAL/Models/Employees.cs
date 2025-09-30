using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC02.Abdallah.DAL.Models
{
    public class Employees: BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime CreateAt { get; set; }
        public bool isActive { get; set; }
        public bool isDeleted { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public decimal Salary { get; set; }

        public int? DepartmentId { get; set; }

        public Department? Department { get; set; }

            public string? ImageName { get; set; }

    }
}
