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

        [Parameter] public string InvoiceId { get; set; } = "";
        private BigSmallModel BigSmallCost = new BigSmallModel();
        private double TotalBigForDisplay;
        private int TotalSmallForDisplay;
        private double TotalCostForDisplay;
        private bool DoubleCheckInvoice = false;
        [Parameter] public bool SubmitIsDisabled { get; set; }
        public List<BettingForm4DEachEntryModel> Entries = Enumerable.Range(0, 60).Select(_ => new BettingForm4DEachEntryModel()).ToList();

        protected override async Task OnInitializedAsync()
        {
            if (InvoicePageName.Length < 1 || InvoiceBelongsTo.Length < 1 || Entries[0].Number.Length < 4)
            {
                SubmitIsDisabled = true;
            }
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
                    Entries[updatedValue.Index].ActualSmall = (Entries[updatedValue.Index].Small * Entries[updatedValue.Index].NumberVariations.Count) * Entries[updatedValue.Index].DrawDates.Count;
                    Entries[updatedValue.Index].BigCostForEntry = BigSmallCost.BigCost * Entries[updatedValue.Index].ActualBig;
                    Entries[updatedValue.Index].SmallCostForEntry = BigSmallCost.SmallCost * Entries[updatedValue.Index].ActualSmall;
                    Entries[updatedValue.Index].TotalCostForEntry = Entries[updatedValue.Index].BigCostForEntry + Entries[updatedValue.Index].SmallCostForEntry;
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
            DateTime currentDate = DateTime.Now;
            // Find the current week's Wednesday, Saturday, and Sunday
            DateTime currentWeekWed = GetDayInCurrentWeek(currentDate, DayOfWeek.Wednesday);
            DateTime currentWeekSat = GetDayInCurrentWeek(currentDate, DayOfWeek.Saturday);
            DateTime currentWeekSun = GetDayInCurrentWeek(currentDate, DayOfWeek.Sunday);

            // Find the next week's Wednesday, Saturday, and Sunday
            DateTime nextWeekWed = GetNextWeekDay(currentDate, DayOfWeek.Wednesday);
            DateTime nextWeekSat = GetNextWeekDay(currentDate, DayOfWeek.Saturday);
            DateTime nextWeekSun = GetNextWeekDay(currentDate, DayOfWeek.Sunday);

            if (((currentDate.DayOfWeek == DayOfWeek.Sunday && currentDate.Hour >= 16) || currentDate.DayOfWeek == DayOfWeek.Monday || currentDate.DayOfWeek == DayOfWeek.Tuesday || (currentDate.DayOfWeek == DayOfWeek.Wednesday && currentDate.Hour < 16)) && input == 1)
            {
                return new List<DateTime>
                    { currentWeekWed, currentWeekSat, currentWeekSun };
            }
            if (((currentDate.DayOfWeek == DayOfWeek.Wednesday && currentDate.Hour >= 16) || currentDate.DayOfWeek == DayOfWeek.Thursday || currentDate.DayOfWeek == DayOfWeek.Friday || (currentDate.DayOfWeek == DayOfWeek.Saturday && currentDate.Hour < 16)) && input == 1)
            {
                return new List<DateTime>
                    { currentWeekSat, currentWeekSun, nextWeekWed };
            }
            if (currentDate.DayOfWeek == DayOfWeek.Sunday && currentDate.Hour > 16 && input == 1)
            {
                return new List<DateTime>
                    { nextWeekWed, nextWeekSat, nextWeekSun };
            }
            if ((currentDate.DayOfWeek == DayOfWeek.Monday || currentDate.DayOfWeek == DayOfWeek.Tuesday || currentDate.DayOfWeek == DayOfWeek.Wednesday
            || currentDate.DayOfWeek == DayOfWeek.Thursday || currentDate.DayOfWeek == DayOfWeek.Friday || (currentDate.DayOfWeek == DayOfWeek.Saturday && currentDate.Hour < 16)) && input == 2)
            {
                return new List<DateTime>
                    { currentWeekSat, currentWeekSun };
            }
            if (currentDate.DayOfWeek == DayOfWeek.Sunday && currentDate.Hour > 16 && input == 2)
            {
                return new List<DateTime>
                    { nextWeekSat, nextWeekSun };
            }
            if ((currentDate.DayOfWeek == DayOfWeek.Monday || currentDate.DayOfWeek == DayOfWeek.Tuesday || (currentDate.DayOfWeek == DayOfWeek.Wednesday && currentDate.Hour < 16)) && input == 3)
            {
                return new List<DateTime>
                    { currentWeekWed };
            }
            if (currentDate.DayOfWeek == DayOfWeek.Sunday && currentDate.Hour > 16 && input == 3)
            {
                return new List<DateTime>
                    { nextWeekWed };
            }
            if ((currentDate.DayOfWeek == DayOfWeek.Monday || currentDate.DayOfWeek == DayOfWeek.Tuesday || currentDate.DayOfWeek == DayOfWeek.Wednesday
            || currentDate.DayOfWeek == DayOfWeek.Thursday || currentDate.DayOfWeek == DayOfWeek.Friday || (currentDate.DayOfWeek == DayOfWeek.Saturday && currentDate.Hour < 16)) && input == 6)
            {
                return new List<DateTime>
                    { currentWeekSat };
            }
            if (currentDate.DayOfWeek == DayOfWeek.Sunday && currentDate.Hour > 16 && input == 6)
            {
                return new List<DateTime>
                    { nextWeekSat };
            }
            if ((currentDate.DayOfWeek == DayOfWeek.Monday || currentDate.DayOfWeek == DayOfWeek.Tuesday || currentDate.DayOfWeek == DayOfWeek.Wednesday
            || currentDate.DayOfWeek == DayOfWeek.Thursday || currentDate.DayOfWeek == DayOfWeek.Friday || currentDate.DayOfWeek == DayOfWeek.Saturday || (currentDate.DayOfWeek == DayOfWeek.Sunday && currentDate.Hour < 16)) && input == 7)
            {
                return new List<DateTime>
                    { currentWeekSun };
            }
            if (currentDate.DayOfWeek == DayOfWeek.Sunday && currentDate.Hour > 16 && input == 7)
            {
                return new List<DateTime>
                    { nextWeekSun };
            }
            return new List<DateTime>
            { };
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