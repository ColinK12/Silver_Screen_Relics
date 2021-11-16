using SilverScreenRelics.Models.TransactionsModels;
using SilverScreenRelics.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScreenRelics.Controllers
{
    public class TransactionsController : Controller
    {
        private TransactionService transactionService = new TransactionService();

        [Authorize]
        // GET: Movie
        public ActionResult Index()
        {
            var model = transactionService.GetAllTransactions();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransactionsCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (transactionService.TransactionsCreate(model))
            {
                TempData["SaveResult"] = "Your transaction was created.";
                return RedirectToAction("Index");

            };
            ModelState.AddModelError("", "Transaction could not be created.");

            return View(model);
        }
        public ActionResult Details(int id)
        {
            var model = transactionService.GetAllTransactions(id);

            return View(model);
        }
        //public ActionResult Edit(int id)
        //{
        //    var detail = transactionService.GetTransactionsById(id);
        //    var model =new TransactionsUpdate
        //        
        //        {
        //            TransactionId = detail.TransactionId,
        //            ArtItemId = detail.ArtItemId,
        //            ArtItemPrice = detail.ArtItemPrice,
        //
        //        };
        //    return View(model);
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TransactionsUpdate model)
        {
            if (ModelState.IsValid) return View(model);

            if (model.ArtItemId != id)
            {
                ModelState.AddModelError("", "Id mismatch");
                return View(model);
            }

            if (transactionService.UpdateTransaction(model))
            {
                TempData["SaveResult"] = "Your transaction was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your transaction could not be updated.");
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            transactionService.DeleteTransaction(id);

            TempData["Save Result"] = "Your art item was Deleted";

            return RedirectToAction("Index");
        }
    }