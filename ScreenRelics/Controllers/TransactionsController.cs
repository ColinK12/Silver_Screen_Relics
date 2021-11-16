using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScreenRelics.Controllers
{
    public class TransactionsController : Controller
    {
        [Authorize]
        // GET: Transactions
        public ActionResult Index()
        {
            return View();
        }
    }
}