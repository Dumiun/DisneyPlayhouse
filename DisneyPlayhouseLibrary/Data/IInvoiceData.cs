using DisneyPlayhouseLibrary.Models;

namespace DisneyPlayhouseLibrary.Data
{
    public interface IInvoiceData
    {
        Task CreateInvoiceLevel1Entry(ILib_InvoiceLevel1DataModel data);

        Task CreateInvoiceLevel1_5Entry(Lib_InvoiceLevel1_5DataModel data);

        Task CreateInvoiceLevel2Entry(ILib_InvoiceLevel2DataModel data);

        Task CreateInvoiceLevel3Entry(ILib_InvoiceLevel3DataModel data);

        Task CreateInvoiceLevel4Entry(ILib_InvoiceLevel4DataModel data);

        Task<List<ILib_InvoiceLevel1DataModel>> GetBetHistoryForUserWithinDateRange(string forId, DateTime from, DateTime to);

        Task<List<ILib_InvoiceLevel2DataModel>> GetDetailsOfSelectedInvoice(string invoiceId);

        Task<List<ILib_InvoiceLevel4DataModel>> GetNumberVariationsOfSelectedNumberInInvoice(string invoiceId, string number);
    }
}