namespace DisneyPlayhouse.Models
{
    public class PageReportTotalViewModel
    {
        public string ReportFor { get; set; }
        public DateTime DrawDate { get; set; }
        public double TotalBig { get; set; }
        public int TotalSmall { get; set; }
        public double Comms { get; set; }
        public double TotalAmount { get; set; }
        public double TotalStrike { get; set; }
        public double Balance { get; set; }
    }
}