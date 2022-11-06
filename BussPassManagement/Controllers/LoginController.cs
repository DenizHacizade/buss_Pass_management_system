using System;
using BussPassManagement.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace login.Controllers
{
    public class loginController : Controller
    {
        // GET: login
        public ActionResult Index()
        {
            return View();
        }

        // GET: login/Details/5

        [HttpPost]
        public ActionResult Autherize(BussPassManagement.Models.UserInfo userModel)
        {
            using (busspassdbEntities6 db = new busspassdbEntities6())
            {
                var userDetails = db.UserInfo.Where(x => x.FullName == userModel.FullName && x.Password == userModel.Password).FirstOrDefault();
              if (userDetails == null)
              {
                    userModel.LoginErrorMessage = "Wrong input";
                    return View("Index", userModel);
               }
               else
               {
                    if (userDetails.RoleID == 1)
                    {
                        UserInfo model = new UserInfo();
                        Session["userId"] = userDetails.UserID;
                        return RedirectToAction("Index","UserInfoes");

                    }
                    else
                    {
                        Session["userId"] = userDetails.UserID;
                        return RedirectToAction("Index", "Home");
                    }
               }
                
                
            }

        }

        // GET: login/Create

        public ActionResult Create()
        {
            return View();
        }

    }
}