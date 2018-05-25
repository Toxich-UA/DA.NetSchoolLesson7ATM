using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATMBusinessLogic;
using EFDbContext.Models.DbEntity;
using Lesson7ATM.Models;

namespace Lesson7ATM.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            CardsService cardsService = new CardsService();
            Card currentUser = cardsService.GetAllCardInfo(cardsService.CurrentCardNumber);


            List<Operations> operations = cardsService.GetAllCardOperations(cardsService.CurrentCardNumber);

            return View(new CardOperationViewModel(){Card = currentUser, Operations = operations});
        }

    }
}