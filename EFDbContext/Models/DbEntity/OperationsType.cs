﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDbContext.Models.DbEntity
{
    public class OperationsType
    {
        public int ID { get; set; }
        public string Type { get; set; }

        public virtual List<OperationsDetails> OperationDetails { get; set; }
    }
}
