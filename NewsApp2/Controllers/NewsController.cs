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
    //[Authorize(Roles = "Admin,Prog,Employee")] 
    [Authorize(Policy = "ProgOrAdminOrEmployeePolicy")]
    public class NewsController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork<News> _news;
        private readonly IUnitOfWork<Section> _section;
        //private readonly IWebHostEnvironment _host;

        public NewsController(
                              ApplicationDbContext context,
                              IUnitOfWork<News> news,
                              IUnitOfWork<Section> section,
                              IWebHostEnvironment host) : base(host)
        {
            _context = context;
            _news = news;
            _section = section;
            //_host = host; // نفعله فقط لو احتجناه في هذا الكونترولر
        }

        //[Route("Danger")]
        //[Route("News")] // أي اسم وليس بالضرورة اسم الكونترولر
        public async Task<IActionResult> Index()
        {
            var news2 = _news.Entity.GetAll().ToList(); //Section=null 
            var news3 = _news.Entity.Include(n => n.Sections).ToList();
            var news4 = await _news.Entity.Include(n => n.Sections).ToListAsync();
            var news5 = _news.Entity.Include(n => n.Sections);
            //return View(await news5.ToListAsync());

            var news = await _news.Entity.Include(n => n.Sections)
                            .OrderByDescending(n => n.Created)
                            .ToListAsync();
            ViewBag.Section = "All News";  //ViewComponent في Default يستطيع تمرير قيمة الى صفحة Controller 
            return View(news);

        }

        public async Task<IActionResult> DisplaySectionNews(Guid? sectionId)
        {
            if (sectionId == null)
            {
                return View("NotFound");
            }

            var news = await _news.Entity.Include(n => n.Sections)
                                         .Where(n => n.SectionId == sectionId)
                                         .OrderByDescending(n => n.Created)
                                         .ToListAsync();

            var sectionName = "";
            if (news.Count != 0)
            {
                sectionName = news.Select(n => n.Sections.Name).FirstOrDefault();
            }
            else
            {
                sectionName = _section.Entity
                            .GetWhere(n => n.Id == sectionId)
                            .Select(n => n.Name)
                            .FirstOrDefault();
            }

            ViewBag.Section = sectionName;




            //var section = await _section.Entity
            //                    .GetWhere(n => n.Id == sectionId)
            //                    .Include(n => n.News)
            //                    .FirstOrDefaultAsync();

            //var news1 = section.News;
            //ViewBag.Section = section.Name;

            return View("Index", news);
        }
        [Authorize(Policy = "CreatePolicy")]
        public async Task<IActionResult> Create()
        {
            ViewData["Sections"] =
                new SelectList(await _section.Entity.GetAll().ToListAsync(), "Id", "Name");
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Details,State,SectionId,Image")] News news, string? isImg1)
        {
            //هذه لا تستعمل ابدا مع المفتاح الأجنبي لكن لو احتجنا لها في حقول اخرى
            //ModelState.Remove("Sections");// طريقة أخرى لمنع التحقق داخل وظيفة معينة وليس في الكلاس سيمنع التحقق بالمطلق لكل الوظائف

            if (ModelState.IsValid)
            {
                try
                {
                    if (!FunctionsHelper.CheckImgExtension(news.Image))
                    {
                        ViewBag.Message = "The attached file is not an image file";
                        return View();
                    }

                    string? fileName = UploadFile("news", news.Image, news.ImageUrl, isImg1);

                    news.ImageUrl = fileName;
                    news.Created = DateTime.Now;
                    _news.Entity.Insert(news);
                    await _news.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return View();
        }
        
        
        [Authorize(Policy = "EditPolicy")]

        public async Task<IActionResult> Edit(Guid? id)
        {

            if (id == null)
            {
                return View("NotFound");
            }

            //var news1= _news.Entity.Include(s => s.Sections).GetByIdAsync(id);

            var news = await _news.Entity.Include(s => s.Sections)
                                         .Where(n => n.Id == id)
                                         .FirstOrDefaultAsync();
            if (news == null)
            {
                return View("NotFound");
            }

            ViewData["Sections"] = new SelectList(await _section.Entity.GetAll().ToListAsync(), "Id", "Name", news.SectionId);

            return View(news);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Title,Details,State,SectionId,Id,Created,Image,ImageUrl")] News news, string? isImg1)
        {

            // (Cross-Site Request Forgery)

            if (id != news.Id)
            {
                return View("NotFound");
            }

            if (ModelState.IsValid)
            {
                string? fileName = UploadFile("news", news.Image, news.ImageUrl, isImg1);

                try
                {
                    news.ImageUrl = fileName;
                    news.Modified = DateTime.Now;
                    _news.Entity.Update(news);
                    await _news.SaveAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!NewsExists(news.Id)) //في حال محذوف
                    {
                        return View("NotFound");
                    }
                    else
                    {
                        ViewBag.ErrorTitle = "The basic data not found in the database ";
                        //ViewBag.ErrorMessage = "Missing data row- " + ex;  // ارسالها للإيميل وعدم عرضها
                        return View("Error");
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(news);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "DeletePolicy")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            try
            {
                var news = await _news.Entity.GetByIdAsync(id);
                if (news == null)
                {
                    return View("NotFound");
                }

                _news.Entity.Delete(news);
                await _news.SaveAsync();

                DeleteOldFile(news.ImageUrl);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorTitle = "The basic data not found in the database ";
                // ViewBag.ErrorMessage = "Missing data row- " + ex;  // ارسالها للإيميل وعدم عرضها
                return View("Error");

            }
            return RedirectToAction(nameof(Index));
        }

        private bool NewsExists(Guid id)
        {
            return (_news.Entity.GetAll()?.Any(e => e.Id == id)).GetValueOrDefault();
        }







    }
}
