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
        IOrderWatchList orderWatchListService;
        

        //Default Constructor
        public WatchListController(IWatchListService WatchListService, IOrderWatchList OrderWatchList)
        {
            this.watchListService = WatchListService;
            this.orderWatchListService = OrderWatchList;
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

        //Return Checkout
        public ActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Checkout(OrderWatchList OrderWatchList)
        {
            var wishListItems = watchListService.GetWatchListItems(this.HttpContext);
            OrderWatchList.ListStatus = "List Created";

            orderWatchListService.CreateOrderWatchList(OrderWatchList, wishListItems);
            watchListService.ClearWatchList(this.HttpContext);

            return RedirectToAction("ThankYou", new {OrderId = OrderWatchList.Id});
        }

        public ActionResult ThankYou(string OrderId)
        {
            ViewBag.OrderId = OrderId;
            return View();
        }

 

    }
}