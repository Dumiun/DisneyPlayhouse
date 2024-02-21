using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyPlayhouseLibrary.Models
{
    public class Lib_PageReportRecords : ILib_PageReportRecords
    {
        public string MemberId { get; set; }
        public DateTime DrawDate { get; set; }
        public List<Lib_InvoiceLevel1point5DataModel> Invoices { get; set; }
        public double TotalBig { get; set; }
        public int TotalSmall { get; set; }
        public double TotalAmount { get; set; }
        public double TotalStrikeAmount { get; set; }
    }
}