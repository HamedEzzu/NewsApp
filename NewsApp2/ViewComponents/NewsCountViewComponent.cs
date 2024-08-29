using Microsoft.AspNetCore.Mvc;
using NewsApp2.Models.Entities;
using NewsApp2.Models.Interfaces;

namespace NewsApp2.ViewComponents
{
    public class NewsCountViewComponent : ViewComponent
    {
        private readonly IUnitOfWork<News> _news;
        private readonly IUnitOfWork<Section> _section;

        public NewsCountViewComponent(IUnitOfWork<News> news,
                                      IUnitOfWork<Section> section)
        {
            _news = news;
            _section = section;
        }

        public IViewComponentResult Invoke()
        {
            var sections = _section.Entity.GetAll().ToList();

            int count = 0;
            foreach (var section in sections)
            {
                section.SectionNewsCount = _news.Entity.Include(n => n.Sections).Where(n => n.SectionId == section.Id).Count();
                count += section.SectionNewsCount;
            }

            ViewBag.AllNewsCount = count;    //ViewBag.AllNewsCount = _news.Entity.GetAll().Count();
            return View(sections);
        }


    }
}
