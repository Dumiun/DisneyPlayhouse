namespace DisneyPlayhouseLibrary.Models
{
    public interface ILib_InvoiceLevel4DataModel
    {
        double Big { get; set; }
        DateTime DrawDate { get; set; }
        string InvoiceId { get; set; }
        string NumberVariation { get; set; }
        string PurchasedNumber { get; set; }
        string PurchasedRoll { get; set; }
        int Small { get; set; }
        double StrikeAmount { get; set; }
    }
}