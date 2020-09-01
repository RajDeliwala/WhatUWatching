using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Show.Core.Models;
using Show.DataAccess.InMemory;

namespace Show.WebUI.Controllers
{
    public class ShowManagerController : Controller
    {
        // Getting context
        ShowRepo context;

        // Default constructor
        public ShowManagerController()
        {
            context = new ShowRepo();
        }

        // GET: ShowManager
        public ActionResult Index()
        {
            List<ShowModel> shows = context.Collection().ToList();
            return View(shows);
        }

        // Create shows function
        public ActionResult Create()
        {
            ShowModel show = new ShowModel();
            return View(show);
        }

        // Create show function with a show parameter
        [HttpPost]
        public ActionResult Create(ShowModel show)
        {
            if (!ModelState.IsValid)
            {
                return View(show);
            }
            else
            {
                context.Insert(show);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        // Edit show function
        public ActionResult Edit(string Id)
        {
            ShowModel show = context.Find(Id);
            if (show == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(show);
            }
        }

        // Edit show function with a show parameter
        [HttpPost]
        public ActionResult Edit(ShowModel show, string Id)
        {
            ShowModel showToEdit = context.Find(Id);
            if (showToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(show);
                }

                showToEdit.Id = show.Id;
                showToEdit.Name = show.Name;
                showToEdit.Description = show.Description;
                showToEdit.Genere1 = show.Genere1;
                showToEdit.Genere2 = show.Genere2;
                showToEdit.Genere3 = show.Genere3;
                showToEdit.Genere4 = show.Genere4;
                showToEdit.Genere5 = show.Genere5;
                showToEdit.Image = show.Image;
                showToEdit.EpisodeCount = show.EpisodeCount;
                showToEdit.PremieredSeason = show.PremieredSeason;
                showToEdit.Studio = show.Studio;

                context.Commit();

                return RedirectToAction("Index");
            }
        }

        // Delete function
        public ActionResult Delete(string Id)
        {
            ShowModel showToDelete = context.Find(Id);

            if (showToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(showToDelete);
            }
        }

        // Confirm Delete function
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            ShowModel showToDelete = context.Find(Id);

            if (showToDelete == null)
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