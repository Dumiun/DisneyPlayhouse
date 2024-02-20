using DisneyPlayhouseLibrary.Models;

namespace DisneyPlayhouse.Models
{
    public class ReportHistoryModel : ILib_ReportHistoryModel
    {
        public string ReportForId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}