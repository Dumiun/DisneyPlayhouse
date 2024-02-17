
namespace DisneyPlayhouseLibrary.Models
{
    public interface ILib_BetHistoryDetailsModel
    {
        DateTime FromDate { get; set; }
        DateTime ToDate { get; set; }
        string UserIdForRecords { get; set; }
    }
}