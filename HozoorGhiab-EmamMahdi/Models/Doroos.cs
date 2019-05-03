using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HozoorGhiabEmamMahdi.Models
{
    public enum TimeDars
    {
        ساعت۷,
        ساعت۸,
        ساعت۹,
        ساعت۱۰,
        ساعت۱۱,

    }

    public class Doroos
    {
        public int DoroosId { get; set; }

        [Required(ErrorMessage = "وارد کردن {0} الزامی میباشد")]
        [Display(Name = "نام درس")]
        public string Name { get; set; }

        [Required(ErrorMessage = "وارد کردن {0} الزامی میباشد")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "{0} باید به صورت عدد وارد شود")]
        [Display(Name = "کد درس")]
        public string Code { get; set; }

        [Required(ErrorMessage = "مشخص کردن {0} الزامی میباشد")]
        [Display(Name = "نام استاد")]
        public Ostad Ostad { get; set; }

        [Required(ErrorMessage = "مشخص کردن {0} الزامی میباشد")]
        [Display(Name = "وضعیت درس")]
        public bool Status { get; set; }

        [Required(ErrorMessage = "مشخص کردن {0} الزامی میباشد")]
        [Display(Name = "زمان درس")]
        public TimeDars DarsTime { get; set; }


        public ICollection<Doroos_User> Doroos_Users { get; set; }
        public ICollection<Hozoor> Hozoors { get; set; }


    }

   
}
