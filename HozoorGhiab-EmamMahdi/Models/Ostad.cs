using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HozoorGhiabEmamMahdi.Models
{
    public class Ostad
    {

      
        public int OstadId { get; set; }

        [Required(ErrorMessage = "وارد کردن {0} الزامی میباشد")]
        [Display(Name = "نام استاد")]
        public string Name { get; set; }

        [Required(ErrorMessage = "وارد کردن {0} الزامی میباشد")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "{0} باید به صورت عدد وارد شود")]
        [Display(Name = "کد استاد")]
        public string Code { get; set; }

        [RegularExpression("^09[0-9]*$", ErrorMessage = "{0} باید به صورت عددی و با ۰۹ شروع شود")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "{0} باید 11 رقمی باشد")]
        [Display(Name = "تلفن استاد")]
        public string Tell { get; set; }

        [Display(Name = "آدرس استاد")]
        public string Address { get; set; }

        [Display(Name = "شماره حساب استاد")]
        public string Account { get; set; }

        [Display(Name = "لیست دروس استاد")]
        public ICollection<Doroos> Dorooses { get; set; }


    }
}
