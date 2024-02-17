
namespace DisneyPlayhouseLibrary.Models
{
    public interface ILib_InvoiceLevel2DataModel
    {
        double ActualBig { get; set; }
        int ActualSmall { get; set; }
        double Big { get; set; }
        int Day { get; set; }
        List<DateTime> DrawDates { get; set; }
        string InvoiceId { get; set; }
        string Number { get; set; }
        string Roll { get; set; }
        int Small { get; set; }
        double TotalCostForEntry { get; set; }
    }
}