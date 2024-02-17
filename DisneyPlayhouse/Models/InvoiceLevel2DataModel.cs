using DisneyPlayhouseLibrary.Models;

namespace DisneyPlayhouse.Models
{
    public class InvoiceLevel2DataModel : ILib_InvoiceLevel2DataModel
    {
        public string InvoiceId { get; set; }
        public string Number { get; set; }
        public double Big { get; set; }
        public int Small { get; set; }
        public int Day { get; set; }
        public string Roll { get; set; }
        public double ActualBig { get; set; }
        public int ActualSmall { get; set; }
        public double TotalCostForEntry { get; set; }
        public List<DateTime> DrawDates { get; set; }
    }
}