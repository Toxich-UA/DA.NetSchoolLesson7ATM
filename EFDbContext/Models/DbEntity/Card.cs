using System.Collections.Generic;

namespace EFDbContext.Models.DbEntity
{
    public partial class Card
    {

        public string CardId { get; set; }
        public string PinCode { get; set; }
        public decimal Ballance { get; set; }
        
        public int ClientId { get; set; }
        public virtual List<Operations> InOperations { get; set; }
        public virtual List<Operations> OutOperations { get; set; }

        public virtual Clients Client { get; set; }

        public virtual OperationDetails OperationDetails { get; set; }
    }
}
