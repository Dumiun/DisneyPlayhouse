namespace DisneyPlayhouseLibrary.Models
{
    public interface ILib_InvoiceLevel1_5DataModel
    {
        DateTime DrawDate { get; set; }
        string InvoiceId { get; set; }
        DateTime LastUpdatedOn { get; set; }
        string PageName { get; set; }
        string PurchasedById { get; set; }
        double CommsPercentage { get; set; }
        DateTime PurchasedDate { get; set; }
        string PurchasedForId { get; set; }
        double StrikeAmount { get; set; }
        double TotalAmount { get; set; }
        double TotalBig { get; set; }
        int TotalSmall { get; set; }
    }
}