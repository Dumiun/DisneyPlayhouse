using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyPlayhouseLibrary.Models
{
    public class Lib_AccountCreditModel
    {
        public double CreditAllowed { get; set; }
        public double UsedCredit { get; set; }
        public double RemainingCredit { get; set; }
    }
}