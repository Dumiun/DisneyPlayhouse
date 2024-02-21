using DisneyPlayhouse.Models;
using Microsoft.AspNetCore.Components;

namespace DisneyPlayhouse.Components.Pages.Member.BettingForm4D
{
    public partial class BettingForm4D
    {
        [Parameter] public string InvoiceBelongsTo { get; set; } = "";
        [Parameter] public string InvoicePageName { get; set; } = "";
        [Parameter] public string PurchasedById { get; set; } = "";
        public bool AddRowClicked { get; set; } = false;
        public bool AddRowClicked2 { get; set; } = false;
        public bool AddRowClicked3 { get; set; } = false;
        public bool AddRowClicked4 { get; set; } = false;

        public DateTime TimeNow;
        private DateTime specifiedTime1 = DateTime.Today.Add(new TimeSpan(16, 30, 0)); // 4:30 PM
        private DateTime specifiedTime2 = DateTime.Today.Add(new TimeSpan(19, 00, 0)); // 7:00 PM
        [Parameter] public string InvoiceId { get; set; } = "";
        private BigSmallModel BigSmallCost = new BigSmallModel();
        private double TotalBigForDisplay;
        private int TotalSmallForDisplay;
        private double TotalCostForDisplay;
        private bool DoubleCheckInvoice = false;
        [Parameter] public bool SubmitIsDisabled { get; set; }
        public List<BettingForm4DEachEntryModel> Entries = Enumerable.Range(0, 150).Select(_ => new BettingForm4DEachEntryModel()).ToList();

        protected override async Task OnInitializedAsync()
        {
            if (InvoicePageName.Length < 1 || InvoiceBelongsTo.Length < 1 || Entries[0].Number.Length < 4)
            {
                SubmitIsDisabled = true;
            }
            TimeNow = DateTime.Now;
        }

        private void UpdateAll((dynamic Value, int Index, string Action) updatedValue)
        {
            if (updatedValue.Action == "UpdateNumber")
            {
                Entries[updatedValue.Index].Number = updatedValue.Value;
                if (updatedValue.Value.Length == 4) //update the numberVariations when changes in Number
                {
                    List<int> variations = CalculateVariations(updatedValue.Value, Entries[updatedValue.Index].Roll);
                    List<string> variationsString = variations.Select(x => x.ToString()).ToList();
                    Entries[updatedValue.Index].NumberVariations = variationsString;
                }
            }
            if (updatedValue.Action == "UpdateBig")
            {
                Entries[updatedValue.Index].Big = updatedValue.Value;
            }
            if (updatedValue.Action == "UpdateSmall")
            {
                Entries[updatedValue.Index].Small = updatedValue.Value;
            }
            if (updatedValue.Action == "UpdateDay")
            {
                Entries[updatedValue.Index].Day = updatedValue.Value;
                Entries[updatedValue.Index].DrawDates = GetDrawDatesForEntry(updatedValue.Value);
            }
            if (updatedValue.Action == "UpdateRoll")
            {
                Entries[updatedValue.Index].Roll = updatedValue.Value;
                if (Entries[updatedValue.Index].Number != null)
                {
                    if (Entries[updatedValue.Index].Number.Length == 4) //update the numberVariations when changes in Roll
                    {
                        List<int> variations = CalculateVariations(Entries[updatedValue.Index].Number, updatedValue.Value);
                        List<string> variationsString = variations.Select(x => x.ToString()).ToList();
                        Entries[updatedValue.Index].NumberVariations = variationsString;
                    }
                }
            }
            if (Entries[updatedValue.Index].Number != null)
            {
                if (Entries[updatedValue.Index].Number.Length == 4 && Entries[updatedValue.Index].Day != 0)
                {
                    Entries[updatedValue.Index].ActualBig = (Entries[updatedValue.Index].Big * Entries[updatedValue.Index].NumberVariations.Count) * Entries[updatedValue.Index].DrawDates.Count;
                    Entries[updatedValue.Index].ActualBigPerDrawDate = (Entries[updatedValue.Index].Big * Entries[updatedValue.Index].NumberVariations.Count);
                    Entries[updatedValue.Index].ActualSmall = (Entries[updatedValue.Index].Small * Entries[updatedValue.Index].NumberVariations.Count) * Entries[updatedValue.Index].DrawDates.Count;
                    Entries[updatedValue.Index].ActualSmallPerDrawDate = (Entries[updatedValue.Index].Small * Entries[updatedValue.Index].NumberVariations.Count);
                    if (Entries[updatedValue.Index].Roll != "I")
                    {
                        Entries[updatedValue.Index].BigCostForEntry = BigSmallCost.BigCost * Entries[updatedValue.Index].ActualBig;
                        Entries[updatedValue.Index].SmallCostForEntry = BigSmallCost.SmallCost * Entries[updatedValue.Index].ActualSmall;
                        Entries[updatedValue.Index].TotalCostForEntry = Entries[updatedValue.Index].BigCostForEntry + Entries[updatedValue.Index].SmallCostForEntry;
                        Entries[updatedValue.Index].TotalCostForEntryPerDrawDate = BigSmallCost.BigCost * Entries[updatedValue.Index].ActualBigPerDrawDate + BigSmallCost.SmallCost * Entries[updatedValue.Index].ActualSmallPerDrawDate;
                    }
                    else
                    {
                        Entries[updatedValue.Index].BigCostForEntry = 0;
                        Entries[updatedValue.Index].SmallCostForEntry = 0;
                        Entries[updatedValue.Index].TotalCostForEntry = 0;
                    }
                }
            }

            TotalBigForDisplay = Entries.Sum(x => x.ActualBig);
            TotalSmallForDisplay = Entries.Sum(x => x.ActualSmall);
            TotalCostForDisplay = Entries.Sum(x => x.TotalCostForEntry);

            SubmitAllowed();
        }

        private async Task SubmitAllowed()
        {
            if (InvoicePageName.Length >= 1 && InvoiceBelongsTo.Length > 1 && Entries[0].Number.Length == 4)
            {
                SubmitIsDisabled = false;
            }
        }

        //Calculation for Number Variations
        private List<int> CalculateVariations(string number, string roll)
        {
            List<int> variations = new List<int>();

            switch (roll)
            {
                case "":
                case null:
                    variations.Add(int.TryParse(number, out int parsedNumber) ? parsedNumber : 0);

                    break;

                case "F":
                    string numStrF = number;
                    int lastDigitF = int.Parse(number.Substring(3, 1));
                    numStrF = numStrF.Substring(0, 3);
                    PermuteWithNoDuplicates(variations, numStrF.ToCharArray(), 0, 2);
                    variations = variations.Select(v => int.Parse(v.ToString() + lastDigitF)).ToList();
                    break;

                case "B":
                    string numStrB = number;
                    int firstDigitB = int.Parse(numStrB.Substring(0, 1));
                    numStrB = numStrB.Substring(1, 3);
                    PermuteWithNoDuplicates(variations, numStrB.ToCharArray(), 0, 2);
                    variations = variations.Select(v => int.Parse(firstDigitB.ToString() + v.ToString())).ToList();
                    break;

                case "R":
                case "I":
                    PermuteWithNoDuplicates(variations, number.ToCharArray(), 0, 3);
                    break;
            }
            return variations;
        }

        private void PermuteWithNoDuplicates(List<int> variations, char[] arr, int left, int right)
        {
            if (left == right)
            {
                int permutation = int.Parse(new string(arr));
                if (!variations.Contains(permutation))
                {
                    variations.Add(permutation);
                }
            }
            else
            {
                for (int i = left; i <= right; i++)
                {
                    Swap(ref arr[left], ref arr[i]);
                    PermuteWithNoDuplicates(variations, arr, left + 1, right);
                    Swap(ref arr[left], ref arr[i]); // backtrack
                }
            }
        }

        private void Swap(ref char a, ref char b)
        {
            char temp = a;
            a = b;
            b = temp;
        }

        //Calculation for Number Draw Dates
        private List<DateTime> GetDrawDatesForEntry(int input)
        {
            // My Code - Fiverr Start

            List<DateTime> dates = new List<DateTime>();

            DayOfWeek currentDay = DateTime.Now.DayOfWeek;
            TimeSpan currentTime = DateTime.Now.TimeOfDay;

            switch (input)
            {
                case 1:
                    if (currentDay == DayOfWeek.Monday || currentDay == DayOfWeek.Tuesday)
                    {
                        dates.Add(GetNextWeekday(DayOfWeek.Wednesday));
                        dates.Add(GetNextWeekday(DayOfWeek.Saturday));
                        dates.Add(GetNextWeekday(DayOfWeek.Sunday));
                    }
                    else if (currentDay == DayOfWeek.Wednesday && currentTime < new TimeSpan(16, 30, 0))
                    {
                        dates.Add(GetNextWeekday(DayOfWeek.Wednesday));
                        dates.Add(GetNextWeekday(DayOfWeek.Saturday));
                        dates.Add(GetNextWeekday(DayOfWeek.Sunday));
                    }
                    else if (currentDay == DayOfWeek.Wednesday && currentTime >= new TimeSpan(16, 30, 0))
                    {
                        dates.Add(GetNextWeekday(DayOfWeek.Wednesday, 7));
                        dates.Add(GetNextWeekday(DayOfWeek.Saturday));
                        dates.Add(GetNextWeekday(DayOfWeek.Sunday));
                    }
                    else if (currentDay == DayOfWeek.Thursday || currentDay == DayOfWeek.Friday)
                    {
                        dates.Add(GetNextWeekday(DayOfWeek.Wednesday));
                        dates.Add(GetNextWeekday(DayOfWeek.Saturday));
                        dates.Add(GetNextWeekday(DayOfWeek.Sunday));
                    }
                    else if (currentDay == DayOfWeek.Saturday && currentTime < new TimeSpan(16, 30, 0))
                    {
                        dates.Add(GetNextWeekday(DayOfWeek.Saturday));
                        dates.Add(GetNextWeekday(DayOfWeek.Wednesday));
                        dates.Add(GetNextWeekday(DayOfWeek.Sunday));
                    }
                    else if (currentDay == DayOfWeek.Sunday && currentTime < new TimeSpan(16, 30, 0))
                    {
                        dates.Add(GetNextWeekday(DayOfWeek.Sunday));
                    }
                    else if (currentDay == DayOfWeek.Sunday && currentTime >= new TimeSpan(16, 30, 0))
                    {
                        dates.Add(GetNextWeekday(DayOfWeek.Wednesday));
                        dates.Add(GetNextWeekday(DayOfWeek.Saturday));
                        dates.Add(GetNextWeekday(DayOfWeek.Sunday, 7));
                    }
                    break;

                case 2:
                    dates.Add(GetNextWeekday(DayOfWeek.Saturday));
                    dates.Add(GetNextWeekday(DayOfWeek.Sunday));
                    break;

                case 3:
                    dates.Add(GetNextWeekday(DayOfWeek.Wednesday));
                    break;

                case 6:
                    dates.Add(GetNextWeekday(DayOfWeek.Saturday));
                    break;

                case 7:
                    dates.Add(GetNextWeekday(DayOfWeek.Sunday));
                    break;

                default:
                    break;
            }

            return dates;
            //My Code -Fiverr End
        }

        private static DateTime GetDayInCurrentWeek(DateTime currentDate, DayOfWeek targetDay)
        {
            int daysUntilTargetDay = ((int)targetDay - (int)currentDate.DayOfWeek + 7) % 7;
            return currentDate.AddDays(daysUntilTargetDay);
        }

        private static DateTime GetNextWeekDay(DateTime currentDate, DayOfWeek targetDay)
        {
            int daysUntilTargetDay = ((int)targetDay - (int)currentDate.DayOfWeek + 7) % 7;
            return currentDate.AddDays(daysUntilTargetDay + 7);
        }

        //My Code - Fiverr Start
        private static DateTime GetNextWeekday(DayOfWeek day, int offset = 0)
        {
            int daysUntil = ((int)day - (int)DateTime.Now.DayOfWeek + 7) % 7 + offset;
            return DateTime.Now.Date.AddDays(daysUntil);
        }

        // My Code - Fiverr End
        private void SetInvoiceBelongsTo(string value)
        {
            InvoiceBelongsTo = value;
            SubmitAllowed();
        }

        private void SetInvoicePurchasedBy(string value)
        {
            PurchasedById = value;
        }

        private void SetInvoicePageName(string value)
        {
            InvoicePageName = value;
            SubmitAllowed();
        }

        private void ResetForm()
        {
            NavigationManager.NavigateTo("/BettingForm4D", true);
        }

        private void SubmitInvoice()
        {
            string dayAbbreviation = DateTime.Now.ToString("ddd").ToUpper();
            string dateFormatted = DateTime.Now.ToString("yyyyMMdd");
            Random generator = new Random();
            String r = generator.Next(0, 1000000).ToString("D6");
            InvoiceId = $"{dayAbbreviation}-{dateFormatted}-{r}-{InvoicePageName}";
            DoubleCheckInvoice = true;
        }

        private void DisplayInvoice()
        {
            DoubleCheckInvoice = false;
        }

        private void AddRow()
        {
            AddRowClicked = true;
        }

        private void AddRow2()
        {
            AddRowClicked2 = true;
        }

        private void AddRow3()
        {
            AddRowClicked3 = true;
        }

        private void AddRow4()
        {
            AddRowClicked4 = true;
        }
    }
}