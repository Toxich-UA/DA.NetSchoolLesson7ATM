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
        private readonly CardsService _cardsService = new CardsService();
        public ActionResult Index()
        {

            Card currentUser = _cardsService.GetAllCardInfo(_cardsService.CurrentCardNumber);


            List<Operations> operations = _cardsService.GetAllCardOperations(_cardsService.CurrentCardNumber);

            return View(new CardOperationViewModel() { Card = currentUser, Operations = operations });
        }

        public ActionResult WithdrawCash()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WithdrawCash(WithdrawCashModel model)
        {
            OperationService operationService = new OperationService();
            if (!ModelState.IsValid)
            {
                return View();
            }

            Card currentCard = _cardsService.GetAllCardInfo(_cardsService.CurrentCardNumber);
            if (model.CashCount != 0)
            {
                if (currentCard.Ballance > model.CashCount)
                {
//                    if (operationService.TrunsferCash(model.CashCount))
//                    {
//                        return RedirectToAction("Index", "Home");
//                    }
//                    else
//                    {
//                        ModelState.AddModelError("", "Something gone wrong, operation was rejected!");
//                        return View();
//                    }
                }

                ModelState.AddModelError("", "Not enough money on balance!");
                return View();
            }
            ModelState.AddModelError("", "Cash count can not be zero!");
            return View();
        }


    }
}