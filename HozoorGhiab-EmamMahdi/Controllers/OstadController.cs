using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HozoorGhiabEmamMahdi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HozoorGhiab_EmamMahdi.Controllers
{
    public class OstadController : Controller
    {
        private readonly HozoorContext context;

        public OstadController(HozoorContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await context.Ostads.ToListAsync());
        }


        [HttpGet]
       public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Ostad ostad)
        {
            var ostadExist = await context.Ostads.Where(c => c.Name == ostad.Name).FirstOrDefaultAsync();

            if (ostadExist != null)
                return NotFound("این استاد قبلا ثبت شده است");

            if (ModelState.IsValid)
            {
                context.Ostads.Add(ostad);
                await context.SaveChangesAsync();
                //return RedirectToAction("Index");
                return RedirectToAction(nameof(Index));
            }

            return View(ostad);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var ostad = await context.Ostads.FirstOrDefaultAsync(c => c.OstadId == id);
            if (ostad == null)
                return NotFound();

            return View(ostad);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var ostad = await context.Ostads.FindAsync(id);
            if (ostad != null)
                return View(ostad);

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
       public async Task<IActionResult> Edit(int id, Ostad ostad)
        {
            if (id != ostad.OstadId)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    context.Ostads.Update(ostad);
                    await context.SaveChangesAsync();
                }
                catch (Exception)
                {

                    var foundOstad = await context.Ostads.FindAsync(ostad.OstadId);
                    if (foundOstad == null)
                        return NotFound();
                    return BadRequest();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ostad);
        }

        public async Task<IActionResult> Delete (int? id)
        {
            if (id == null)
                return NotFound();

            var ostad = await context.Ostads.FindAsync(id);
            if (ostad == null)
                return NotFound();

            return View(ostad);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ostad = await context.Ostads.FindAsync(id);

            context.Ostads.Remove(ostad);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> AdvancedSearch(string name)
        {
            var ostadFind = await context.Ostads.Where(c => c.Name.Contains(name)).ToListAsync();
            return PartialView("AdvancedSearch", ostadFind);

        }
    }
}