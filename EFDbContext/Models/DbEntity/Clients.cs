using System;
using System.Collections.Generic;

namespace EFDbContext.Models.DbEntity
{
    public partial class Clients
    {
        public Clients()
        {
            Cards = new List<Card>();
        }

        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string PhoneNamber { get; set; }

        public ICollection<Card> Cards { get; set; }

        public virtual Addresses Address { get; set; }
    }
}