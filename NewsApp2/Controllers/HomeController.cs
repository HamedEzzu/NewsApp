
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsApp2.Classes;
using NewsApp2.Models.Entities;
using NewsApp2.Models.Interfaces;
using NewsApp2.ViewModels;

namespace NewsApp2.Controllers
{
    [ViewLayout("_Layout")]
    public class HomeController : BaseController
    {
        private readonly IUnitOfWork<SiteInfo> _siteInfo;
        private readonly IUnitOfWork<Contact> _contact;
        private readonly IUnitOfWork<News> _news;
        private readonly IUnitOfWork<SiteState> _siteState;
        //private readonly IWebHostEnvironment _host;
        private readonly IEmailSender _emailSender;
        private readonly IUnitOfWork<Section> _section;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public HomeController(IUnitOfWork<SiteInfo> siteInfo,
                               IUnitOfWork<Contact> contact,
                               IUnitOfWork<News> news,
                               IUnitOfWork<SiteState> siteState,
                               IWebHostEnvironment host,
                               IEmailSender emailSender,
                               IUnitOfWork<Section> section,
                               SignInManager<ApplicationUser> signInManager) : base(host)
        {
            _siteInfo = siteInfo;
            _contact = contact;
            _news = news;
            _siteState = siteState;
            //_host = host;
            _emailSender = emailSender;
            _section = section;
            _signInManager = signInManager;
        }

        [ViewLayout("_LayoutTemplate")]
        public async Task<IActionResult> Index()
        {

            var sections = await _section.Entity.Include(n => n.News)
                                                //.Where(s => s.News.Count != 0)
                                                .OrderByDescending(o => o.News.Count)
                                                .ToListAsync();
            return View(sections);
        }

        public IActionResult About()
        {

            var contact = _contact.Entity.GetAll().FirstOrDefault();

            var siteInfo = _siteInfo.Entity.GetAll().FirstOrDefault();

            SiteVM siteVM = new SiteVM
            {
                Contact = contact,
                SiteInfo = siteInfo
            };


            return View(siteVM);
        }


        [HttpPost]
        public async Task<IActionResult> Contact(string contactName, string contactEmail, string contactMessage)
        {
            string content = ReadHtmlTemplate("Contact.html");

            content = content.Replace("{SubjectName}", contactName);
            content = content.Replace("{SubjectEmail}", contactEmail);
            content = content.Replace("{Content}", contactMessage);
            string? email = await _contact.Entity.GetAll()
                                                 .Select(n => n.Email)
                                                 .FirstOrDefaultAsync();

            var message = new Message(new string[] { email }, contactEmail + " - " + contactName, content, null);

            try
            {
                await _emailSender.SendEmailAsync(message);
                TempData["SuccessMessage"] = "The email has been sent successfully";
            }
            catch
            {
                TempData["ErrorMessage"] = "Failed to send email";

                ViewBag.ErrorTitle = "Email Send Error";
                return View("Error");
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Section(Guid? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var section1 = await _section.Entity.GetAll()
                                                .Include(n => n.News)
                                                .Where(s => s.Id == id)
                                                .FirstOrDefaultAsync();

            var section2 = await _section.Entity.GetAll()
                                                .Where(s => s.Id == id)
                                                .Include(n => n.News)
                                                .FirstOrDefaultAsync();

            //GetWhere قبل Include لا يمكن وضع
            var section = await _section.Entity.GetWhere(s => s.Id == id)
                                               .Include(n => n.News)
                                               .FirstOrDefaultAsync();


            if (section == null)
            {
                return View("NotFound");
            }

            return View(section);
        }

        public async Task<IActionResult> News(Guid? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            //var news1 = await _news.Entity.GetWhere(n => n.Id == id)
            //                              .Include(n=>n.Sections)
            //                              .FirstOrDefaultAsync();

            var news = await _news.Entity.Include(n => n.Sections)
                                         .Where(n => n.Id == id)
                                         .FirstOrDefaultAsync();



            var newsList = await _news.Entity.GetWhere(n => n.SectionId == news.SectionId & n.Id != id)
                                             .OrderByDescending(n => n.Created)  
                                             .ToListAsync();

            if (news == null)
            {
                return View("NotFound");
            }

            var newsVM = new NewsVM
            {
                News = news,
                NewsList = newsList,
            };


            return View(newsVM);
        }

        [AllowAnonymous]
        [Route("Closing")]
        public async Task<IActionResult> Closing()
        {

            var siteState = await _siteState.Entity.GetAll().FirstOrDefaultAsync();
            var contact = await _contact.Entity.GetAll().FirstOrDefaultAsync();
            var siteInfo = await _siteInfo.Entity.GetAll().FirstOrDefaultAsync();

            if (siteState == null | contact == null | siteInfo == null)
            {
                return View("NotFound");
            }

            if (siteState.State == false)
            {
                var closingVM = new ClosingVM
                {
                    SiteState = siteState,
                    Contact = contact,
                    SiteInfo = siteInfo
                };

                await _signInManager.SignOutAsync();
                // _userSessionTracker.Decrement();

                return View(closingVM);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }


    }
}

//-----طرق استدعاء الصفحات---------------------------------------
//return View(); // استدعاء نفس الصفحة بدون ارسال باراميتر
//return View(model);// استدعاء نفس الصفحة مع ارسال باراميتر مودل
//return View("Contact");//  استدعاء صفحة مختلفة بدون ارسال باراميتر
//return View("About", Id); // استدعاء صفحة مختلفة مع ارسال باراميتر عادي 
//return View("About", model); // استدعاء صفحة مختلفة مع ارسال باراميتر مودل 
//return RedirectToAction("About"); // استدعاء وظيفة
//return RedirectToAction("About" new { successMessage = successMessage}); // استدعاء وظيفة مع ارسال باراميتر