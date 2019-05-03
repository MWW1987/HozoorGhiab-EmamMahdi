using HozoorGhiabEmamMahdi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HozoorGhiabEmamMahdi.Services
{
    public class CountOfUsers
    {
        private readonly HozoorContext context;

        public CountOfUsers(HozoorContext context)
        {
            this.context = context;
        }

        public string GetCountOfUser(int darsId)
        {
            return  context.Doroos_Users.Where(c => c.DoroosId == darsId).Count().ToString();
        }
    }
}
