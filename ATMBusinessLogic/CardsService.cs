using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using EFDbContext.Models.DbEntity;
using EFDbContext.Models.DbEntity.Context;

namespace ATMBusinessLogic
{
    public class CardsService
    {
        private readonly BankDbContext _context = new BankDbContext();

        public bool IsAuthenticate(string cardNumber, string pinCode)
        {
            var user = _context.Cards.FirstOrDefault(x => x.CardId == cardNumber && x.PinCode == pinCode);

            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(cardNumber, false);
                return true;
            }

            return false;
        }
    }
}
