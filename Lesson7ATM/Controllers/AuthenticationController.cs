
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using ATMBusinessLogic;
using EFDbContext.Models.DbEntity.Context;
using Lesson7ATM.Models;

namespace Lesson7ATM.Controllers
{

    public class AuthenticationController : Controller
    {
        // GET: Authentication
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            var cardService = new CardsService();

            using (var context = new BankDbContext())
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                if (cardService.IsAuthenticate(model.CardNumber, model.PinCode))
                {
                    FormsAuthentication.SetAuthCookie(model.CardNumber, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect card number or pincode!");
                }
            }


            return View();
        }
    }
}