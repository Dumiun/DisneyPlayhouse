namespace DisneyPlayhouse.Models
{
    public class PageReportChildTotalViewModel
    {
        public string MemberId { get; set; }
        public string Role { get; set; } = "Member";
        public double TotalBig { get; set; }
        public double TotalSmall { get; set; }
        public double Commsion { get; set; }
        public double TotalAmount { get; set; }
        public double StrikeAmount { get; set; }
        public double Balance { get; set; }
    }
}