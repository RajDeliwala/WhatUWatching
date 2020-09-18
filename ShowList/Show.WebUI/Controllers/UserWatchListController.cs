using Show.Core.Contracts;
using Show.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Show.WebUI.Controllers
{
    [Authorize]
    public class UserWatchListController : Controller
    {
        //Implement Interface
        IOrderWatchList orderWatchListService;

        //Default Constructor
        public UserWatchListController(IOrderWatchList OrderWatchListService)
        {
            this.orderWatchListService = OrderWatchListService;
        }
        
        //Prints the current users orders
        public ActionResult Index()
        {
            //Getting all watch lists
            List<OrderWatchList> watchLists = orderWatchListService.GetOrderWatchLists();

            //Get the current users username
            string Id = System.Web.HttpContext.Current.User.Identity.Name;

            //Make a new list to present only the current user's watch list
            List<OrderWatchList> userBasedWatchList = new List<OrderWatchList>();

            //Iterate through the old list and pick out the ones that match the current username
            foreach (OrderWatchList watchList in watchLists)
            {
                if (watchList.Email == Id)
                {
                    userBasedWatchList.Add(watchList);
                }
            }
            return View(userBasedWatchList);
        }


        public ActionResult UpdateOrder(string Id)
        {
            OrderWatchList order = orderWatchListService.GetWatchList(Id);
            return View(order);
        }

        [HttpPost]
        public ActionResult UpdateOrder(OrderWatchList updatedOrder, string Id)
        {
            OrderWatchList order = orderWatchListService.GetWatchList(Id);
            order.ListStatus = updatedOrder.ListStatus;
            orderWatchListService.UpdateWatchList(order);

            return RedirectToAction("Index");
        }


    }
}