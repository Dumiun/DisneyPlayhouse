using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyPlayhouseLibrary.Models
{
    public class Lib_InvoiceLevel4DataModel : ILib_InvoiceLevel4DataModel
    {
        public string InvoiceId { get; set; }
        public string NumberVariation { get; set; }
        public string PurchasedNumber { get; set; }
        public string PurchasedRoll { get; set; }
        public double Big { get; set; }
        public int Small { get; set; }
        public double StrikeAmount { get; set; }
        public DateTime DrawDate { get; set; }
    }
}