using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using EFDbContext.Models.DbEntity;

namespace Lesson7ATM.Models
{
    public class CardOperationViewModel
    {
        public Card Card { get; set; }
        public List<EFDbContext.Models.DbEntity.Operations> Operations { get; set; }
    }
}