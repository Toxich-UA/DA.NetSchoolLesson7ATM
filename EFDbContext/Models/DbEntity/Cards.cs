using System.Collections.Generic;

namespace EFDbContext.Models.DbEntity
{
    public partial class Cards
    {
        public Cards()
        {
            InOperations = new List<Operations>();
            OutOperations = new List<Operations>();
        }

        public string CardId { get; set; }
        public string PinCode { get; set; }
        public decimal Ballance { get; set; }
        
        public int ClientId { get; set; }
        public List<Operations> InOperations { get; set; }
        public List<Operations> OutOperations { get; set; }

        public virtual Clients Client { get; set; }

        public OperationDetails OperationDetails { get; set; }
    }
}
