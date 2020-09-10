using Show.Core.Contracts;
using Show.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Show.WebUI.Controllers
{
    public class WatchListController : Controller
    {

        IWatchListService watchListService;
        

        //Default Constructor
        public WatchListController(IWatchListService WatchListService)
        {
            this.watchListService = WatchListService;
        }
        // GET: WatchList
        public ActionResult Index()
        {
            var model = watchListService.GetWatchListItems(this.HttpContext);
            return View(model);
        }

        // Add to watchlist
        public ActionResult AddToWatchList(string Id)
        {
            watchListService.AddToWatchList(this.HttpContext, Id);
            return RedirectToAction("Index");
        }
        // Remove from watchlist
        public ActionResult RemoveFromWatchList(string Id)
        {
            watchListService.RemoveFromWatchList(this.HttpContext, Id);
            return RedirectToAction("Index");
        }

 

    }
}