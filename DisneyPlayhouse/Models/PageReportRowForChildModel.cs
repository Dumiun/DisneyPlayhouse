namespace DisneyPlayhouse.Models
{
    public class PageReportRowForChildModel
    {
        public string MemberId { get; set; }
        public double TotalBig { get; set; }
        public int TotalSmall { get; set; }
        public double TotalAmount { get; set; }

        public double CommsPercentage { get; set; }
        public double StrikeAmount { get; set; }
    }
}