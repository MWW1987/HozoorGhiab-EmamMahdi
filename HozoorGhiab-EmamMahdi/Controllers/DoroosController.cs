using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HozoorGhiabEmamMahdi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HozoorGhiab_EmamMahdi.Controllers
{
    public class DoroosController : Controller
    {
        private readonly HozoorContext context;

        public DoroosController(HozoorContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {

            return View(context.Dorooses.Include(c => c.Ostad));
        }

        [HttpGet]
        public IActionResult Create ()
        {
            ViewBag.Ostads = new SelectList(context.Ostads, "OstadId", "Name");
            
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name", "Code", "Ostad", "Status", "DarsTime")] CreateDarsViewModel dars)
        {
            if (ModelState.IsValid)
            {
                var ostad = await context.Ostads.Where(c => c.OstadId == Int32.Parse(dars.Ostad)).FirstOrDefaultAsync();
                Doroos newDars = new Doroos
                {
                    Name = dars.Name,
                    Code = dars.Code,
                    DarsTime = dars.DarsTime,
                    Status = dars.Status,
                    Ostad = ostad
                };

                context.Dorooses.Add(newDars);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            //var dars = await context.Dorooses.FindAsync(id);
            var dars = await context.Dorooses.Include(c=> c.Ostad).FirstOrDefaultAsync(c => c.DoroosId == id);
            if (dars != null)
            { 
                ViewBag.Ostads = new SelectList(context.Ostads, "OstadId", "Name");
                EditDarsViewModel editDars = new EditDarsViewModel
                {
                    Code = dars.Code,
                    DarsTime = dars.DarsTime,
                    Id = dars.DoroosId,
                    Name = dars.Name,
                    Status = dars.Status,
                    Ostad = dars.Ostad.Name
                };
                return View(editDars);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, EditDarsViewModel dars)
        {
            if (id != dars.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var ostad = await context.Ostads.Where(c => c.OstadId == Convert.ToInt32(dars.Ostad)).FirstOrDefaultAsync();
                var findDars = await context.Dorooses.FindAsync(id);
                if(ostad != null)
                {
                    findDars.Code = dars.Code;
                    findDars.Name = dars.Name;
                    findDars.Status = dars.Status;
                    findDars.Ostad = ostad;
                    findDars.DarsTime = dars.DarsTime;
                   
                        context.Dorooses.Update(findDars
);
                        await context.SaveChangesAsync();
                        return RedirectToAction("Index");
                    
                }
                

            }
            return View(dars);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var dars = await context.Dorooses.Include(c=> c.Ostad).FirstOrDefaultAsync(c => c.DoroosId == id);
            if (dars == null)
                return NotFound();
            return View(dars);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dars = await context.Dorooses.FindAsync(id);

            context.Dorooses.Remove(dars);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> AddTalabe(int? id)
        {
            if (id == null)
                return NotFound();
            var dars = await context.Dorooses.Include(c=> c.Ostad).FirstOrDefaultAsync(c => c.DoroosId == id);
            var ostad = dars.Ostad;
            var userToPartial = await context.Users.Where(c => c.Doroos_Users.Any(p => p.DoroosId == id)).ToListAsync();

            AddTalabeViewModel userViewModel = new AddTalabeViewModel()
            {
                Dars = dars,
                Users = userToPartial
            };

            
            return View(userViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddTalabePartial(int id, int userId)
        {
            var dars = await context.Dorooses.FindAsync(id);
            var user = await context.Users.FindAsync(userId);

            if (dars != null && user != null)
            {
                try
                {
                    context.Doroos_Users.Add(new Doroos_User
                    {
                        DoroosId = dars.DoroosId,
                        UserId = user.UserId
                    });

                    await context.SaveChangesAsync();
                    var userToPartial = await context.Users.Where(c => c.Doroos_Users.Any(p => p.DoroosId == id)).ToListAsync();

                    AddTalabeViewModel userViewModel = new AddTalabeViewModel()
                    {
                        Users = userToPartial
                    };

                    return PartialView("AddTalabePartial", userViewModel);
                }
                catch (Exception )
                {

                    return PartialView("AddTalabePartial");
                }
                
            }
            return PartialView("AddTalabePartial");


        }

        public async Task<IActionResult> SearchTalabe(string name)
        {

            if (name != null)
            {
                var userFind = await context.Users.Where(c => c.FullName.Contains(name)).FirstOrDefaultAsync();
                AddTalabeViewModel findTalabe = new AddTalabeViewModel()
                {
                    User = userFind
                };
                return PartialView("SearchTalabe", findTalabe);
            }

            return PartialView("SearchTalabe");



        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();
            var dars = await context.Dorooses.Include(c => c.Ostad).FirstOrDefaultAsync(c => c.DoroosId == id);
            var ostad = dars.Ostad;
            var userToPartial = await context.Users.Where(c => c.Doroos_Users.Any(p => p.DoroosId == id)).ToListAsync();

            AddTalabeViewModel userViewModel = new AddTalabeViewModel()
            {
                Dars = dars,
                Users = userToPartial
            };
            return View(userViewModel);
        }

        public async Task<IActionResult> ShowTalabePartial (int? id)
        {
            if (id == null)
                return NotFound();
            var dars = await context.Dorooses.FindAsync(id);            
            var userToPartial = await context.Users.Where(c => c.Doroos_Users.Any(p => p.DoroosId == id)).ToListAsync();

            AddTalabeViewModel userViewModel = new AddTalabeViewModel()
            {
               Dars = dars,
               Users = userToPartial
            };
            return PartialView();
        }

        [HttpGet]
        public async Task<IActionResult> DeleteTalabeFromDars (int id, int userId)
        {
            var  dars = await context.Dorooses.FindAsync(id);
            var userDelete = await context.Doroos_Users.Where(c => c.UserId == userId && c.DoroosId == id).FirstOrDefaultAsync();
            if (userDelete != null)
            {
                context.Doroos_Users.Remove(userDelete);
                await context.SaveChangesAsync();

                //var userToPartial = await context.Users.Where(c => c.Doroos_Users.Any(p => p.DoroosId == id)).ToListAsync();

                //AddTalabeViewModel userViewModel = new AddTalabeViewModel()
                //{
                //    Dars = dars,
                //    Users = userToPartial
                //};
            }

            return RedirectToAction("Details", new { id = id });
        }
             
    }
}