using BlockBuster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlockBuster.Controllers
{
    public class HomeController : Controller
    {
        dbBBusterDataContext data = new dbBBusterDataContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Newfilm() { return PartialView(data.films.OrderByDescending(a => a.created).Take(8).ToList()); }
        public ActionResult Category_film(int id) { return PartialView(data.film_categories.Where(or => or.film_id == id).OrderByDescending(a => a.id).ToList()); }
        public ActionResult Category_film_2(int id) { return PartialView(data.film_categories.Where(or => or.film_id == id).OrderByDescending(a => a.id).Take(2).ToList()); }
        public ActionResult Popular_movie() { return PartialView(data.films.Where(or => or.form_id == 1).OrderByDescending(a => a.view_count).Take(7).ToList()); }
        public ActionResult Toprate_movie() { return PartialView(data.films.Where(or => or.form_id == 1).OrderByDescending(a => a.rate).Take(7).ToList()); }
        public ActionResult Popular_drama() { return PartialView(data.films.Where(or => or.form_id == 2).OrderByDescending(a => a.view_count).Take(7).ToList()); }
        public ActionResult Toprate_drama() { return PartialView(data.films.Where(or => or.form_id == 2).OrderByDescending(a => a.rate).Take(7).ToList()); }
        public ActionResult Celebrities() { return PartialView(data.celebrities.OrderByDescending(a => a.id).Take(5).ToList()); }
        public ActionResult Celeb_job(int id) { return PartialView(data.celeb_jobs.Where(or => or.celeb_id == id).OrderByDescending(a => a.id).ToList()); }
        public ActionResult Newtrailer() { return PartialView(data.trailers.OrderByDescending(a => a.id).Take(3).ToList()); }
        public ActionResult Menu_film() { return PartialView(data.forms.OrderBy(a => a.id).ToList()); }
        public ActionResult Menu_category(int id)
        {
            ViewBag.form_id = id;
            return PartialView(data.categories.OrderBy(a => a.name).ToList());
        }
        public ActionResult Menu_country(int id)
        {
            ViewBag.form_id = id;
            return PartialView(data.countries.OrderBy(a => a.name).ToList());
        }
        public ActionResult Menu_celebrity_county() { return PartialView(data.countries.OrderBy(a => a.id).ToList()); }

    }
}