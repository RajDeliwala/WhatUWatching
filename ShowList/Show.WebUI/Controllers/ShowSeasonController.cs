using Show.Core.Contracts;
using Show.Core.Models;
using Show.DataAccess.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Show.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ShowSeasonController : Controller
    {
        // Getting context
        IRepo<ShowSeason> context;

        // Default constructor
        public ShowSeasonController(IRepo<ShowSeason> seasonContext)
        {
            this.context = seasonContext;
        }

        // GET: ShowManager
        public ActionResult Index()
        {
            List<ShowSeason> showseason = context.Collection().ToList();
            return View(showseason);
        }

        // Create shows season function
        public ActionResult Create()
        {
            ShowSeason showSeason = new ShowSeason();
            return View(showSeason);
        }

        // Create show season function with a show parameter
        [HttpPost]
        public ActionResult Create(ShowSeason showseason)
        {
            if (!ModelState.IsValid)
            {
                return View(showseason);
            }
            else
            {
                context.Insert(showseason);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        // Edit show season function
        public ActionResult Edit(string Id)
        {
            ShowSeason showseason = context.Find(Id);
            if (showseason == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(showseason);
            }
        }

        // Edit show season function with a show parameter
        [HttpPost]
        public ActionResult Edit(ShowSeason showseason, string Id)
        {
            ShowSeason showSeasonToEdit = context.Find(Id);
            if (showSeasonToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(showseason);
                }

                showSeasonToEdit.ShowSeasonAired = showseason.ShowSeasonAired;
              

                context.Commit();

                return RedirectToAction("Index");
            }
        }

        // Delete show season function
        public ActionResult Delete(string Id)
        {
            ShowSeason showSeasonToDelete = context.Find(Id);

            if (showSeasonToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(showSeasonToDelete);
            }
        }

        // Confirm Delete show season function
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            ShowSeason showSeasonToDelete = context.Find(Id);

            if (showSeasonToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}