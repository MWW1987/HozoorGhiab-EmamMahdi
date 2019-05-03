using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HozoorGhiabEmamMahdi.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage ="وارد کردن {0} الزامی میباشد")]
        [Display(Name ="نام و نام خانوادگی")]
        public string FullName { get; set; }

        [Required(ErrorMessage ="وارد کردن {0} الزامی میباشد")]
        [MinLength(4,ErrorMessage ="حداقل تعداد {0} باید ۴ عدد باشد")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "{0} باید به صورت عدد وارد شود")]
        [Display(Name = "کد طلبه")]
        public string Code { get; set; }

        [RegularExpression("^09[0-9]*$", ErrorMessage = "{0} باید به صورت عددی و با ۰۹ شروع شود")]
        [Required(ErrorMessage ="وارد کردن {0} ضروری میباشد")]
        [StringLength(11, MinimumLength =11, ErrorMessage ="{0} باید 11 رقمی باشد")]
        [Display(Name = "شماره تلفن")]
        public string Tell { get; set; }


        [Display(Name = "آدرس")]
        public string Address { get; set; }
        public ICollection<Doroos_User> Doroos_Users { get; set; }
        public ICollection<Hozoor> Hozoors { get; set; }



    }
}
