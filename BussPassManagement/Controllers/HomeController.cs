using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BussPassManagement.Models;

namespace BussPassManagement.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            busspassdbEntities5 db = new busspassdbEntities5();
            
            List<city> CityList = db.city.ToList();
            
            citydb cityvar = new citydb();

            List<citydb> cityvarList = CityList.Select(x => new citydb { CityName = x.CityName, CityID = x.CityID }).ToList();

            return View(cityvarList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult BussCat()
        {
            busspassdbEntities5 busscatdb = new busspassdbEntities5();
            List<buscatg> BusList = busscatdb.buscatg.ToList();
            buscatdb buscatvar = new buscatdb();
            List<buscatdb> busvarList = BusList.Select(x => new buscatdb { CategName = x.CategName, BusID = x.BusID }).ToList();
            return View(busvarList);
        }
        public ActionResult AdminPanel()
        {

            return View();
        }
    }
}