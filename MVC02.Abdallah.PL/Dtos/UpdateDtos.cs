using System.ComponentModel.DataAnnotations;

namespace MVC02.Abdallah.PL.Dtos
{
    public class UpdateDtos
    {
        [Required(ErrorMessage = "Code is Required!")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Name is Required!")]

        public string Name { get; set; }
        [Required(ErrorMessage = "Creation Date is Required!")]
        public DateTime CreateAt { get; set; }
    }
}
