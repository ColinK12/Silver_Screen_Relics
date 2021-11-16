using ScreenRelics.Data;
using SilverScreenRelics.Data.Entities;
using SilverScreenRelics.Models.ArtItemModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScreenRelics.Controllers
{
    public class ArtItemController : Controller
    {
        // GET: ArtItem
        public ActionResult Index()
        {
            return View();
        }
        private ApplicationDbContext _dbContext = new ApplicationDbContext();

        //Get ArtItem/{id}
        public ActionResult Details(int id)
        {
            ArtItem artItem = _dbContext.ArtItemsSell.Find(id);
            if (artItem == null)
            {
                return HttpNotFound();
            }


            return View(artItem);
        }
        //Get ArtItem/Create
        // ViewData / ViewBags
        public ActionResult Create()
        {
            var viewModel = new ArtItemCreate();
            viewModel.ArtItem = _dbContext.ArtItemsSell.Select(artItem => new SelectListItem
            {
                Text = artItem.ArtItemDescription + " " + artItem.ArtItemPrice,
                Value = artItem.ArtItemId.ToString()
            });
            return View(viewModel);
        }
        //Post: ArtItem/CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArtItem viewModel)
        {
            return View(viewModel);
        }
        //Get: ArtItem/Delete/{id}
        public ActionResult Delete(int id)

        {
            ArtItem artItem = _dbContext.ArtItemsSell.Find(id);
            if (artItem == null)
            {
                return HttpNotFound();
            }


            return View(artItem);
        }
        //Post: ArtItem/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ArtItem artItem)
        {
            if (1 != 1)

            {
                ViewData["ErrorMessage"] = "Could Not Delete Your Movie Item";
                return View(artItem);
            }
            return RedirectToAction("Index");
        }
        //Get: ArtItem/Edit/{id}
        public ActionResult Edit(int id)
        {
            ArtItem artItem = _dbContext.ArtItemsSell.Find(id);

            if (artItem == null)
            {
                return HttpNotFound();
            }

            ViewData["ArtItem"] = _dbContext.ArtItemsSell.Select(artItems => new SelectListItem
            {
                Text = artItem.ArtItemDescription + " " + artItem.ArtItemPrice,
                Value = artItem.ArtItemId.ToString()
            });

            return View(artItem);
        }
        //Post: ArtItem/Edit/{id}
        [HttpPost]
        public ActionResult Edit(ArtItem artItem)
        {
            ViewData["ArtItem"] = _dbContext.ArtItemsSell.Select(artItems => new SelectListItem
            {
                Text = artItem.ArtItemDescription + " " + artItem.ArtItemPrice,
                Value = artItem.ArtItemId.ToString()
            });

            return View(artItem);
        }
    }
}