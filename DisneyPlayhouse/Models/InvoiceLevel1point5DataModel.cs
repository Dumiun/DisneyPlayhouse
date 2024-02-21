using DisneyPlayhouseLibrary.Models;

namespace DisneyPlayhouse.Models
{
    public class InvoiceLevel1point5DataModel : ILib_InvoiceLevel1point5DataModel
    {
        public string InvoiceId { get; set; }
        public string PageName { get; set; }
        public DateTime DrawDate { get; set; }
        public double TotalBig { get; set; }
        public int TotalSmall { get; set; }
        public double TotalAmount { get; set; }
        public double StrikeAmount { get; set; }
        public string PurchasedById { get; set; }
        public string PurchasedForId { get; set; }
        public DateTime PurchasedDate { get; set; }
        public DateTime LastUpdatedOn { get; set; }
    }
}