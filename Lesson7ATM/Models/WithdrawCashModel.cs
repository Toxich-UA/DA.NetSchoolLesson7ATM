using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lesson7ATM.Models
{
    public class WithdrawCashModel
    {
        [Required]
        public decimal CashCount { get; set; }
    }
}