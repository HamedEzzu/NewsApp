using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NewsApp2.Classes;
using NewsApp2.Models;
using NewsApp2.Models.Entities;
using NewsApp2.Models.Interfaces;

namespace NewsApp2.Controllers
{
    [ViewLayout("_LayoutDashboard")]
    [Authorize(Roles = "Admin,Prog")]
    public class SectionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork<Section> _section;

        public SectionsController(ApplicationDbContext context,
                                  IUnitOfWork<Section> section)
        {
            _context = context;
            _section = section;
        }

        // GET: Sections
        [Route("Sections")]
        public async Task<IActionResult> Index()
        {
           
            //var sections1 = _section.Entity.GetAll(); // News = null
            //var sections2 = await _section.Entity.GetAll().ToListAsync(); // News = null
            //var sections3 = await _section.Entity.GetAll().Include(n => n.News).ToListAsync();
            //var sections4 = await _section.Entity.Include(n => n.News).ToListAsync();

            var sections = await _section.Entity.Include(n => n.News).OrderBy(s => s.Name).ToListAsync();
            
            ViewData["SectionsCount"]= sections.Count(); 
            //ViewBag.SectionsCount = sections5.Count(); 
            
            return View(sections);

        }

        [ViewLayout("_Layout")]
        public async Task<IActionResult> Details(Guid? id)
        {
            //if (id == null) // عند مسح خانة من المعرف
            //{
            //    //return NotFound();  // 404
            //    return View("NotFound");
            //}

            var section = await _section.Entity.GetByIdAsync(id);
            //if (section == null)
            //{
            //    ViewBag.Message = "Section details is not found";
            //    return View("NotFound");
            //}

            return View(section);
        }

       
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Created")] Section section)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var exists = await _section.Entity
                                      .GetWhere(a => a.Name == section.Name) // لا يهم التحويل الى حروف كبيرة لأنه غير حساس لحالة الأحرف
                                      .FirstOrDefaultAsync();

                    if (exists != null)
                    {
                        ViewBag.Message = $"Section '{exists.Name}' has already been added";
                        //ViewBag.Message = "Section '" + exists.Name + "' has already been added";
                        return View();
                    }
                    section.Name = section.Name.Trim();
                    _section.Entity.Insert(section);
                    await _section.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    throw;
                }
            }
            return View(section);
        }

        [AcceptVerbs("Get", "Post")]
        public async Task<JsonResult> NameExists(string name)
        {
            var exists = await _section.Entity.GetAll()
                                  .FirstOrDefaultAsync(n => n.Name == name.Trim()); // لا يهم التحويل الى حروف كبيرة لأنه غير حساس لحالة الأحرف

            if (exists == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"The Section '{exists.Name}' is already in use");
            }
        }


        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var section = await _section.Entity.GetByIdAsync(id);

            if (section == null)
            {
                ViewBag.Message = "The Section Is Not Found";
                return View("NotFound");
            }
            return View(section);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Id,Created,Modified")] Section section)
        {
            //لمنع حدوث هجمات CSRF (Cross-Site Request Forgery):
            if (id != section.Id)
            {
                return View("NotFound");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var sectionNameExists = await _section.Entity
                                            .GetWhere(a => a.Name == section.Name.Trim() & a.Id != section.Id)
                                            .FirstOrDefaultAsync();

                    if (sectionNameExists != null)
                    {
                        ViewBag.Message = $"Section '{section.Name}' has already been added";
                        return View(section);
                    }

                    _section.Entity.Update(section);
                    await _section.SaveAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!SectionExists(section.Id))
                    {
                        return View("NotFound"); // في حال غير موجود
                    }
                    else
                    {
                        //throw; //  صفحة الخطأ الإفتراضية للمتصفح
                        ViewBag.ErrorTitle = "The basic data not found in the database ";
                        ViewBag.ErrorMessage = "Missing data row- " + ex;
                        return View("Error");
                    }

                }
                return RedirectToAction(nameof(Index));
            }
            return View(section);
        }

        private bool SectionExists(Guid id)
        {
            return (_section.Entity.GetAll()?.Any(e => e.Id == id)).GetValueOrDefault(); 

        }


        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var section = await _section.Entity.GetByIdAsync(id);
            if (section == null)
            {
                return View("NotFound");
            }

            return View(section);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(Guid id,string name , string test)
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var section = await _section.Entity.GetByIdAsync(id);
            if (section == null)
            {
                return View("NotFound");
            }

            try
            {
                _section.Entity.Delete(section);
                await _section.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                throw;
            }
        }


    }
}
