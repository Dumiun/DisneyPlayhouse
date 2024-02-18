using DisneyPlayhouseLibrary.Models;

namespace DisneyPlayhouse.Models
{
    public class BetHistoryDetailsModel : ILib_BetHistoryDetailsModel
    {
        public string UserIdForRecords { get; set; } = "";
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}