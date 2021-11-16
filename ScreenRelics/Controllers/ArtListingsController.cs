using ScreenRelics.Data;
using ScreenRelics.Models;
using SilverScreenRelics.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScreenRelics.Controllers
{
    public class ArtListingsController : Controller
    {
        // GET: ArtListings
        public ActionResult Index()
        {
            return View();
        }
        private ApplicationDbContext _dbContext = new ApplicationDbContext();

        //Get ArtListings/{id}
        public ActionResult Details(int id)
        {
            ArtListings artListings = _dbContext.Art_Listings.Find(id);
            if (artListings == null)
            {
                return HttpNotFound();
            }


            return View(artListings);
        }
        //Get ArtListings/Create
        // ViewData / ViewBags
        public ActionResult Create()
        {
            var viewModel = new CreateArtListingsViewModel();
            viewModel.ArtListing = (ICollection<ArtListings>)_dbContext.Art_Listings.Select(artListing => new SelectListItem
            {
                Text = artListing.ArtItemDescription + " " + artListing.RelicId,
                Value = artListing.RelicId.ToString()
            });
            return View(viewModel);
        }
        //Post: ArtListings/CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateArtListingsViewModel viewModel)
        {
            return View(viewModel);
        }
        //Get: ArtListings/Delete/{id}
        public ActionResult Delete(int id)

        {
            ArtListings artListings = _dbContext.Art_Listings.Find(id);
            if (artListings == null)
            {
                return HttpNotFound();
            }


            return View(artListings);
        }
        //Post: ArtListings/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ArtListings artListings)
        {
            if (1 != 1)

            {
                ViewData["ErrorMessage"] = "Could Not Delete Your Movie List Item";
                return View(artListings);
            }
            return RedirectToAction("Index");
        }
        //Get: ArtItem/Edit/{id}
        public ActionResult Edit(int id)
        {
            ArtListings artListings = _dbContext.Art_Listings.Find(id);

            if (artListings == null)
            {
                return HttpNotFound();
            }

            ViewData["ArtListings"] = _dbContext.Art_Listings.Select(artListing => new SelectListItem
            {
                Text = artListings.ArtItemDescription + " " + artListings.RelicId,
                Value = artListings.RelicId.ToString()
            });

            return View(artListings);
        }
        //Post: ArtItem/Edit/{id}
        [HttpPost]
        public ActionResult Edit(ArtListings artListings)
        {
            ViewData["ArtListings"] = _dbContext.Art_Listings.Select(artListing => new SelectListItem
            {
                Text = artListing.ArtItemDescription + " " + artListing.ArtItemTitle,
                Value = artListing.ArtItemTitle.ToString()
            });

            return View(artListings);
        }
    }
}