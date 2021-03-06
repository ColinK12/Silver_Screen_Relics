using SilverScreenRelics.Models.ArtItemModels;
using SilverScreenRelics.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScreenRelics.Controllers
{
    public class ArtItemController : Controller
    {
        private ArtItemService artItemService = new ArtItemService();

        [Authorize]
        // GET: Movie
        public ActionResult Index()
        {
            var model = artItemService.GetAllArtItems();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArtItemCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (artItemService.CreateArtItem(model))
            {
                TempData["SaveResult"] = "Your art Item was created.";
                return RedirectToAction("Index");

            };
            ModelState.AddModelError("", "Art item could not be created.");

            return View(model);
        }
        public ActionResult Details(int id)
        {
            var model = artItemService.GetArtItemById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var detail = artItemService.GetArtItemById(id);
            var model =
                new ArtItemUpdate
                {
                    ArtItemTitle = detail.ArtItemTitle,
                    ArtItemDescription = detail.ArtItemDescription,
                    ArtItemPrice = detail.ArtItemPrice,

                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ArtItemUpdate model)
        {
            if (ModelState.IsValid) return View(model);

            if (model.ArtItemId != id)
            {
                ModelState.AddModelError("", "Id mismatch");
                return View(model);
            }

            if (artItemService.UpdateArtItem(model))
            {
                TempData["SaveResult"] = "Your art item Was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your art item could not be updated.");
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            artItemService.DeleteArtItem(id);

            TempData["Save Result"] = "Your art item was Deleted";
            
                return RedirectToAction("Index");
        }
    }
}