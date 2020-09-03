using Show.Core.Contracts;
using Show.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Show.WebUI.Controllers
{
    public class HomeController : Controller
    {
        // Getting context
        IRepo<ShowModel> context;
        IRepo<ShowSeason> showseasonContext;

        // Default constructor
        public HomeController(IRepo<ShowModel> showContext, IRepo<ShowSeason> showSeasonContext)
        {
            context = showContext;
            showseasonContext = showSeasonContext;
        }

        //View product function
        public ActionResult Details(string Id)
        {
            ShowModel shows = context.Find(Id);
            if(shows == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(shows);
            }
        }


        public ActionResult Index()
        {
            List<ShowModel> shows = context.Collection().ToList();
            return View(shows);
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
    }
}