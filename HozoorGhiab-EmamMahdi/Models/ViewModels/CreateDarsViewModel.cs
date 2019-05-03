using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HozoorGhiabEmamMahdi.Models
{
    public class CreateDarsViewModel
    {
        
        [Required(ErrorMessage = "وارد کردن {0} الزامی میباشد")]
        [Display(Name = "نام درس")]
        public string Name { get; set; }

        [Required(ErrorMessage = "وارد کردن {0} الزامی میباشد")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "{0} باید به صورت عدد وارد شود")]
        [Display(Name = "کد درس")]
        public string Code { get; set; }

        [Required(ErrorMessage = "مشخص کردن {0} الزامی میباشد")]
        [Display(Name = "نام استاد")]
        public string Ostad { get; set; }

        [Required(ErrorMessage = "مشخص کردن {0} الزامی میباشد")]
        [Display(Name = "وضعیت درس")]
        public bool Status { get; set; }

        [Required(ErrorMessage = "مشخص کردن {0} الزامی میباشد")]
        [Display(Name = "زمان درس")]
        public TimeDars DarsTime { get; set; }


        
    }
}
