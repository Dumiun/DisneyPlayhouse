using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyPlayhouseLibrary.Models
{
    public class Lib_InvoiceLevel3DataModel : ILib_InvoiceLevel3DataModel
    {
        public string InvoiceId { get; set; }
        public string Number { get; set; }
        public double Big { get; set; }
        public int Small { get; set; }
        public string Roll { get; set; }
        public DateTime DrawDate { get; set; }
    }
}
