using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using EFDbContext.Models.DbEntity;
using EFDbContext.Models.DbEntity.Context;

namespace ATMBusinessLogic
{
    public class CardsService
    {
        private readonly BankDbContext _context = new BankDbContext();


        public string CurrentCardNumber => HttpContext.Current.User.Identity.Name;

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
        public Card GetAllCardInfo(string cardNumber)
        {
           return _context.Cards.First(x => x.CardId == HttpContext.Current.User.Identity.Name);
        }
        public List<Operations> GetAllCardOperations(string cardNumber)
        {
            Card currentUser = GetAllCardInfo(cardNumber);
            List<Operations> operations = new List<Operations>();

            currentUser.OutOperations.ForEach(x => x.Amount *= -1);
            currentUser.InOperations.ForEach(x => x.OperationDetailses = new List<OperationDetails> { x.OperationDetailses[0] });
            currentUser.OutOperations.ForEach(x => x.OperationDetailses = new List<OperationDetails> { x.OperationDetailses[1] });
            operations.AddRange(currentUser.InOperations);
            operations.AddRange(currentUser.OutOperations);

            return operations.OrderBy(x=>x.OperationTime).ToList();
        }
    }
}
