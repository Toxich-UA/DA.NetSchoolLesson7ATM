using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using EFDbContext.Models.DbEntity;
using EFDbContext.Models.DbEntity.Context;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Runtime.CompilerServices;

namespace ATMBusinessLogic
{
    public class OperationService
    {

        private readonly BankDbContext _context = new BankDbContext();
        private readonly CardsService _cardsService = new CardsService();

        /// <summary>
        /// Transfer cash between two card and update their balance.
        /// Default transfer it is withdraw cash.
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="secondCard"></param>
        /// <returns></returns>
        public bool TrunsferCash(decimal amount, string secondCard = Constants.ATM)
        {
            Card inCard = _context.Cards.FirstOrDefault(x => x.CardId == secondCard);
            Card outCard = _context.Cards.FirstOrDefault(x => x.CardId == _cardsService.CurrentCardNumber);

            OperationsDetails inOperationDetails = new OperationsDetails();
            OperationsDetails outOperationDetails = new OperationsDetails();

            Operations operation = new Operations()
            {
                Amount = amount,
                InCard = inCard,
                InId = secondCard,
                OutCard = outCard,
                OutId = _cardsService.CurrentCardNumber,
                OperationDetailses = new List<OperationsDetails>()
                {
                    inOperationDetails,
                    outOperationDetails
                }
               
            };

            //Have some issues with this table to add it to the database.

            inOperationDetails.Operations = operation;
            inOperationDetails.Amount = amount;
            inOperationDetails.Card = inCard;
            inOperationDetails.Balance = inCard.Ballance + amount;
            inOperationDetails.OperationsType = _context.OperationsType.First(x => x.ID == 1);
            

            outOperationDetails.Operations = operation;
            outOperationDetails.Amount = amount;
            outOperationDetails.Card = outCard;
            outOperationDetails.Balance = outCard.Ballance - amount;
            outOperationDetails.OperationsType = _context.OperationsType.First(x => x.ID == 2);


            inCard.Ballance += amount;
            outCard.Ballance -= amount;

            _context.Cards.Attach(inCard);
            _context.Cards.Attach(outCard);
            _context.Entry(inCard).Property(x => x.Ballance).IsModified = true;
            _context.Entry(outCard).Property(x => x.Ballance).IsModified = true;
            

            try
            {
                _context.Operations.Add(operation);
                _context.OperationDetails.Add(inOperationDetails);
                _context.OperationDetails.Add(outOperationDetails);
                //_context.Configuration.ValidateOnSaveEnabled = false;
                _context.SaveChanges();
                //_context.Configuration.ValidateOnSaveEnabled = true;
            }
            catch (DbEntityValidationException e)
            {
                foreach (var validationErrors in e.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }

                return false;
            }

            return true;
        }

    }
}
