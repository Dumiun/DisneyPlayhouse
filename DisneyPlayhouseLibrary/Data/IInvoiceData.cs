using DisneyPlayhouseLibrary.Models;

namespace DisneyPlayhouseLibrary.Data
{
    public interface IInvoiceData
    {
        Task CreateInvoiceLevel1Entry(ILib_InvoiceLevel1DataModel data);
        Task CreateInvoiceLevel2Entry(ILib_InvoiceLevel2DataModel data);
        Task CreateInvoiceLevel3Entry(ILib_InvoiceLevel3DataModel data);
        Task CreateInvoiceLevel4Entry(ILib_InvoiceLevel4DataModel data);
    }
}