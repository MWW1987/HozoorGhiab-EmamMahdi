using System;
using System.ComponentModel.DataAnnotations;

namespace HozoorGhiabEmamMahdi.Models
{
    public class Hozoor
    {
        public int HozoorId { get; set; }

        [Required(ErrorMessage = "وارد کردن {0} الزامی میباشد")]
        [Display(Name = "تاریخ")]
        public DateTime Tarikh { get; set; }

        [Required(ErrorMessage = "وارد کردن {0} الزامی میباشد")]
        [Display(Name = "طلبه")]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required(ErrorMessage = "وارد کردن {0} الزامی میباشد")]
        [Display(Name = "درس")]
        public int DarsId { get; set; }
        public Doroos Dars { get; set; }

        [Required(ErrorMessage = "وارد کردن {0} الزامی میباشد")]
        [Display(Name = "حضور")]
        public bool Hazer { get; set; }
    }
}
