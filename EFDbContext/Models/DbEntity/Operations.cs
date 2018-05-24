using System;
using System.Collections.Generic;

namespace EFDbContext.Models.DbEntity
{
    public partial class Operations
    {

        public long OperationId { get; set; }
        public string InId { get; set; }
        public string OutId { get; set; }
    
        public decimal Amount { get; set; }
        
        public DateTime OperationTime { get; set; }

        public Cards InCard { get; set; }
        public Cards OutCard { get; set; }

        public List<OperationDetails> OperationDetailses { get; set; }
    }
}
