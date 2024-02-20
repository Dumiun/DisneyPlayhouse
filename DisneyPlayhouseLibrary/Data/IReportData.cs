using DisneyPlayhouseLibrary.Models;

namespace DisneyPlayhouseLibrary.Data
{
    public interface IReportData
    {
        Task<List<List<Lib_InvoiceLevel1DataModel>>> GetNumberVariationsOfSelectedNumberInInvoice(ILib_ReportHistoryModel searchDetails);
    }
}