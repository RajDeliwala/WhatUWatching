﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Show.Core.Contracts;
using Show.Core.Models;
using Show.Core.ViewModels;
using Show.DataAccess.InMemory;

namespace Show.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ShowManagerController : Controller
    {
        // Getting context
        IRepo<ShowModel> context;
        IRepo<ShowSeason> showseasonContext;

        // Default constructor
        public ShowManagerController(IRepo<ShowModel> showContext, IRepo<ShowSeason> showSeasonContext)
        {
            context = showContext;
            showseasonContext = showSeasonContext;
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
            ShowManagerViewModel viewModel = new ShowManagerViewModel();

            viewModel.show = new ShowModel();
            viewModel.showSeason = showseasonContext.Collection();
            return View(viewModel);
        }

        // Create show function with a show parameter
        [HttpPost]
        public ActionResult Create(ShowModel show, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return View(show);
            }
            else
            {
                if(file != null)
                {
                    show.Image = show.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//ShowImages//") + show.Image);
                }
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
                ShowManagerViewModel viewModel = new ShowManagerViewModel();
                viewModel.show = show;
                viewModel.showSeason = showseasonContext.Collection();
                return View(viewModel);
            }
        }

        // Edit show function with a show parameter
        [HttpPost]
        public ActionResult Edit(ShowModel show, string Id, HttpPostedFileBase file)
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
                if (file != null)
                {
                    showToEdit.Image = show.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//ShowImages//") + showToEdit.Image);
                }

                showToEdit.Name = show.Name;
                showToEdit.Description = show.Description;
                showToEdit.Genere1 = show.Genere1;
                showToEdit.Genere2 = show.Genere2;
                showToEdit.Genere3 = show.Genere3;
                showToEdit.Genere4 = show.Genere4;
                showToEdit.Genere5 = show.Genere5;
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