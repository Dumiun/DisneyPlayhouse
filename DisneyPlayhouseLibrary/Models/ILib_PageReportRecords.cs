namespace DisneyPlayhouseLibrary.Models
{
    public interface ILib_PageReportRecords
    {
        DateTime DrawDate { get; set; }
        List<Lib_InvoiceLevel1point5DataModel> Invoices { get; set; }
        string MemberId { get; set; }
        double TotalAmount { get; set; }
        double TotalBig { get; set; }
        int TotalSmall { get; set; }
        double TotalStrikeAmount { get; set; }
    }
}