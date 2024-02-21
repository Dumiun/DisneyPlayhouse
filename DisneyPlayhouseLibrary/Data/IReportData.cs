using DisneyPlayhouseLibrary.Models;

namespace DisneyPlayhouseLibrary.Data
{
    public interface IReportData
    {
        Task<List<Lib_DateRangeModel>> GetDateRangeForCurrentUserPageReport(string reportForId, DateTime fromDate, DateTime toDate);
        Task<List<List<Lib_InvoiceLevel1DataModel>>> GetNumberVariationsOfSelectedNumberInInvoice(string reportForId, DateTime fromDate, DateTime toDate);
        Task<List<Lib_InvoiceLevel1point5DataModel>> GetPageRecordsForUserOnDrawDate(string reportForId, DateTime drawDate);
    }
}