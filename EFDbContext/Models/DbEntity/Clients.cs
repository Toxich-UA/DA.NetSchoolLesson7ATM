using System;
using System.Collections.Generic;

namespace EFDbContext.Models.DbEntity
{
    public partial class Clients
    {
        public Clients()
        {
            Cards = new List<Cards>();
        }

        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string PhoneNamber { get; set; }

        public ICollection<Cards> Cards { get; set; }

        public Addresses Address { get; set; }
    }
}