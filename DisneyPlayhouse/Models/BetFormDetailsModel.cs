namespace DisneyPlayhouse.Models
{
    public class BetFormDetailsModel
    {
        public string BelongsToId { get; set; } = "";
        public string PurchasedById { get; set; } = "";
        public string PageName { get; set; } = "";
        public double TotalBig { get; set; } = 0.0;
        public int TotalSmall { get; set; } = 0;
        public double TotalAmount { get; set; } = 0.00;
    }
}