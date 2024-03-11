namespace DisneyPlayhouseLibrary.Models
{
    public interface ILib_InvoiceLevel1DataModel
    {
        string InvoiceId { get; set; }
        DateTime LastUpdatedOn { get; set; }
        string MediaType { get; set; }
        string PageName { get; set; }
        double CommsPercentage { get; set; }
        string PurchasedById { get; set; }
        DateTime PurchasedDate { get; set; }
        string PurchasedForId { get; set; }
        double StrikeAmount { get; set; }
        double TotalAmount { get; set; }
        double TotalBig { get; set; }
        int TotalSmall { get; set; }
    }
}