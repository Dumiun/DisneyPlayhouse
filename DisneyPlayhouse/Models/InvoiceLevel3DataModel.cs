using DisneyPlayhouseLibrary.Models;

namespace DisneyPlayhouse.Models
{
    public class InvoiceLevel3DataModel : ILib_InvoiceLevel3DataModel
    {
        public string InvoiceId { get; set; }
        public string Number { get; set; }
        public double Big { get; set; }
        public int Small { get; set; }
        public string Roll { get; set; }
        public DateTime DrawDate { get; set; }
    }
}