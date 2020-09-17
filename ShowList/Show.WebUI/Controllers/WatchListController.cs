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
        IRepo<Customer> customers;
        

        //Default Constructor
        public WatchListController(IWatchListService WatchListService, IOrderWatchList OrderWatchList, IRepo<Customer> Customers)
        {
            this.watchListService = WatchListService;
            this.orderWatchListService = OrderWatchList;
            this.customers = Customers;
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
        [Authorize]
        public ActionResult Checkout()
        {
            Customer customer = customers.Collection().FirstOrDefault(c => c.Email == User.Identity.Name);
            if(customer != null)
            {
                OrderWatchList Order = new OrderWatchList()
                {
                    Email = customer.Email,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName
                };

                return View(Order);
            }
            else
            {
                return RedirectToAction("Error");
            }
            
        }

        [Authorize]
        [HttpPost]
        public ActionResult Checkout(OrderWatchList OrderWatchList)
        {
            var wishListItems = watchListService.GetWatchListItems(this.HttpContext);
            OrderWatchList.ListStatus = "List Created";
            OrderWatchList.Email = User.Identity.Name;

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