using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace EFDbContext.Models.DbEntity
{
    public partial class Operations
    {

        public long OperationId { get; set; }
        public string InId { get; set; }
        public string OutId { get; set; }
    
        public decimal Amount { get; set; }
        public DateTime OperationTime { get; set; }

        public Card InCard { get; set; }
        public Card OutCard { get; set; }

        public virtual List<OperationsDetails> OperationDetailses { get; set; }
    }
}
