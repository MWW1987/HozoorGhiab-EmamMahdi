using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HozoorGhiabEmamMahdi.Models
{
    public class Dars_Users
    {
        public int DarsId { get; set; }
        public int Code { get; set; }
        public string Ostad { get; set; }
        public string Dars { get; set; }
        public int UserId { get; set; }
        public List<User> Users { get; set; }
    }
}
