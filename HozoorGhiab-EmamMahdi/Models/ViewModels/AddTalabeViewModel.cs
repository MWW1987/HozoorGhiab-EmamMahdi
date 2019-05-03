using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HozoorGhiabEmamMahdi.Models
{
    public class AddTalabeViewModel
    {
        public Doroos Dars { get; set; }
        public User User { get; set; }
        public List<User> Users { get; set; }
        public List<Dars_Users> Dars_Users { get; set; }
    }
}
