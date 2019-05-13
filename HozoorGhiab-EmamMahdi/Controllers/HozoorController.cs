using HozoorGhiabEmamMahdi.Models;
using HozoorGhiabEmamMahdi.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HozoorGhiabEmamMahdi.Controllers
{
    public class HozoorController : Controller
    {
        private readonly HozoorContext context;

        public HozoorController(HozoorContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult>NewHozoor(int darsId, string dateTime)
        {
            DateTime tarikh = Convert.ToDateTime(dateTime);
            
            var oldHozoor = await context.Hozoors.Where(c => c.Tarikh == tarikh).FirstOrDefaultAsync();
            if (oldHozoor != null)
                return NotFound();
            var users = context.Doroos_Users.Where(c => c.DoroosId == darsId).ToList();
            var dars = await context.Dorooses.Include(c => c.Ostad).Where(c => c.DoroosId == darsId).FirstOrDefaultAsync();
            //List<User> UsersFind = new List<User>();
            //foreach (var item in users)
            //{
            //    var userTofind = context.Users.Find(item.UserId);
            //    UsersFind.Add(userTofind);
            //}
            List<Hozoor> hozoorSent = new List<Hozoor>();

            foreach (var item in users)
            {
                var hozoor = new Hozoor
                {
                    Dars = dars,
                    User = context.Users.Find(item.UserId),
                    Hazer = false
                };
                hozoorSent.Add(hozoor);
            }
            //HozoorViewModel hozoorSent = new HozoorViewModel
            //{
            //    Dars = dars,
            //    Users = UsersFind

            //};

            ViewBag.DarsName = dars.Name.ToString();
            ViewBag.OstadName = dars.Ostad.Name;
            return View(hozoorSent);
        }
    }
}
