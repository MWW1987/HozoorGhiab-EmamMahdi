using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HozoorGhiabEmamMahdi.Models.ViewModels
{
    public class HozoorViewModel
    {
        public int DarsId { get; set; }
        public Doroos Dars { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Hozoor> Hozoors { get; set; }
    }
}
