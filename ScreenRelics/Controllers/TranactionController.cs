using ScreenRelics.Data;
using SilverScreenRelics.Data.Entities;
using SilverScreenRelics.Models.TransactionsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScreenRelics.Controllers
{
    public class TranactionController : Controller
    {
        private ApplicationDbContext _dbContext = new ApplicationDbContext();
        // GET: Transaction
        public ActionResult Index()
        {
            return View(_dbContext.Transactions.ToList());
        }
        //Get Transaction/{id}
        public ActionResult Details(int id)
        {
            Transactions transaction = _dbContext.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }


            return View(transaction);
        }
        //Get Transaction/Create
        // ViewData / ViewBags
        public ActionResult Create()
        {
            var viewModel = new TransactionsCreate();
            viewModel. = _dbContext.ArtItemsSell.Select(artItem => new SelectListItem
            {
                Text = artItem.ArtItemDescription + " " + artItem.ArtItemPrice,
                Value = artItem.ArtItemId.ToString()
            });
            return View(viewModel);
        }
        //Post: Transaction/CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateTranactionViewModel viewModel)
        {
            return View(viewModel);
        }
        //Get: Transaction/Delete/{id}
        public ActionResult Delete(int id)

        {
            Transactions transaction = _dbContext.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }


            return View(transaction);
        }
        //Post: Transaction/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Transactions transaction)
        {
            if (1 != 1)
            {
                ViewData["ErrorMessage"] = "Could Not Delete Your Transaction";
                return View(transaction);
            }
            return RedirectToAction("Index");
        }
        //Get: Transaction/Edit/{id}
        public ActionResult Edit(int id)
        {
            Transactions transaction = _dbContext.Transactions.Find(id);

            if (transaction == null)
            {
                return HttpNotFound();
            }

            ViewData["ArtItem"] = _dbContext.ArtItemsSell.Select(artItem => new SelectListItem
            {
                Text = artItem.ArtItemDescription + " " + artItem.ArtItemPrice,
                Value = artItem.ArtItemId.ToString()
            });

            return View(transaction);
        }
        //Post: Transaction/Edit/{id}
        [HttpPost]
        public ActionResult Edit(Transactions transaction)
        {
            ViewData["ArtItem"] = _dbContext.ArtItemsSell.Select(artItem => new SelectListItem
            {
                Text = artItem.ArtItemDescription + " " + artItem.ArtItemPrice,
                Value = artItem.ArtItemId.ToString()
            });

            return View(transaction);
        }
    }
}