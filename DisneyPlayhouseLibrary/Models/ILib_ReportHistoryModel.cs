
namespace DisneyPlayhouseLibrary.Models
{
    public interface ILib_ReportHistoryModel
    {
        DateTime FromDate { get; set; }
        string ReportForId { get; set; }
        DateTime ToDate { get; set; }
    }
}