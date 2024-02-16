namespace DisneyPlayhouse.Models
{
    public class BettingForm4DEachEntryModel
    {
        public string Number { get; set; }
        public double Big { get; set; }
        public int Small { get; set; }
        public int Day { get; set; }
        public string Roll { get; set; }
        public List<string> NumberVariations { get; set; }
        public List<DateTime> DrawDates { get; set; }
        public double ActualBig { get; set; }
        public int ActualSmall { get; set; }
        public double BigCostForEntry { get; set; }
        public double SmallCostForEntry { get; set; }
        public double TotalCostForEntry { get; set; }
    }
}