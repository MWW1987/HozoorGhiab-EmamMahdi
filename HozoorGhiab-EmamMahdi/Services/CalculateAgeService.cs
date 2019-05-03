using System;

namespace HozoorGhiabEmamMahdi.Services
{
    public class CalculateAgeService
    {
        public int CalculateAge(DateTime birthdate)
        {
            var age = DateTime.Today.Year - birthdate.Year;
            if (birthdate.AddYears(age) > DateTime.Today)
                age--;

            return age;
        }
    }
}
