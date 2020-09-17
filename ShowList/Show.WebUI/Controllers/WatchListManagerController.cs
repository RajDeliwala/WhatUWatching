using Microsoft.Ajax.Utilities;
using Show.Core.Contracts;
using Show.Core.Models;
using Show.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Show.WebUI.Controllers
{
    public class WatchListManagerController : Controller
    {
        IOrderWatchList orderWatchListService;

        public WatchListManagerController(IOrderWatchList OrderWatchListService)
        {
            this.orderWatchListService = OrderWatchListService;
        }


        // GET: WatchListManager
        public ActionResult Index()
        {
            List<OrderWatchList> watchLists = orderWatchListService.GetOrderWatchLists();

            return View(watchLists);
        }

        //Get single watchlist
        public ActionResult GetUpdateWatchList(string Id)
        {
            OrderWatchList watchList = orderWatchListService.GetWatchList(Id);
            return View(watchList);
        }
        [HttpPost]
        public ActionResult GetUpdateWatchList(OrderWatchList updatedWatchList, string Id)
        {
            OrderWatchList watchList = orderWatchListService.GetWatchList(Id);

            watchList.ListStatus = updatedWatchList.ListStatus;
            orderWatchListService.UpdateWatchList(watchList);

            return RedirectToAction("Index");
        }

    }
}