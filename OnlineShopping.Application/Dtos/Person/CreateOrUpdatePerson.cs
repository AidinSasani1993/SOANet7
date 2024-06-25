using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.Application.Dtos.Person
{
    public class CreateOrUpdatePerson
    {
        [Display(Name = "کد ملی")]
        [Required(ErrorMessage ="وارد کردن کد ملی الزامیست")]
        [MaxLength(10,ErrorMessage ="کد ملی باید 10 رقم باشد")]
        [MinLength(10,ErrorMessage ="کد ملی باید 10 رقم باشد")]
        public string IdentityCode { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
    }
}
