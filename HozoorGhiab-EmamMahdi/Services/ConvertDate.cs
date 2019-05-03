using MD.PersianDateTime.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HozoorGhiabEmamMahdi.Services
{
    public class ConvertDate
    {
        public DateTime ShamsiToMilade(string date)
        {
            PersianDateTime persianDateTime = PersianDateTime.Parse(date);
            return persianDateTime.ToDateTime();
        }

        public string MiladiToShamsi(DateTime date)
        {
            PersianDateTime persianDateTime = new PersianDateTime(date);
            return persianDateTime.ToString("dd/MMMM/yyyy");
        }

        
    }
}
