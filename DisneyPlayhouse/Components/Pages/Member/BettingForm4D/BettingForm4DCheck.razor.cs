using DisneyPlayhouse.Models;
using DisneyPlayhouseLibrary.Models;
using Microsoft.AspNetCore.Components;

namespace DisneyPlayhouse.Components.Pages.Member.BettingForm4D
{
    public partial class BettingForm4DCheck
    {
        [Parameter] public double TotalBigForCheck { get; set; }
        [Parameter] public int TotalSmallForCheck { get; set; }
        [Parameter] public double TotalCostForCheck { get; set; }
        [Parameter] public string InvoiceId { get; set; }
        [Parameter] public string InvoicePageNameForCheck { get; set; }
        [Parameter] public string InvoiceForWhoForCheck { get; set; }
        [Parameter] public string InvoiceSubmittedByWhoForCheck { get; set; }
        [Parameter] public List<BettingForm4DEachEntryModel> EntriesForCheck { get; set; }
        private int ListIndex = 1;
        [Parameter] public EventCallback ReturnToFormSet { get; set; }

        private async Task ReturnToForm()
        {
            await ReturnToFormSet.InvokeAsync();
        }

        private async Task SaveInvoiceToDB()
        {
            try
            {
                for (int i = 0; i < EntriesForCheck.Count; i++)
                {
                    if (EntriesForCheck[i].DrawDates != null)
                    {
                        foreach (var drawdate in EntriesForCheck[i].DrawDates)
                        {
                            //Level 4 data entry
                            for (int x = 0; x < EntriesForCheck[i].NumberVariations.Count; x++)
                            {
                                // Check if any of the required values are empty or zero
                                if (!string.IsNullOrEmpty(EntriesForCheck[i].NumberVariations[x].ToString()))
                                {
                                    ILib_InvoiceLevel4DataModel level4entry = new InvoiceLevel4DataModel();
                                    level4entry.InvoiceId = InvoiceId;
                                    level4entry.NumberVariation = EntriesForCheck[i].NumberVariations[x];
                                    level4entry.PurchasedNumber = EntriesForCheck[i].Number;
                                    level4entry.PurchasedRoll = EntriesForCheck[i].Roll;
                                    level4entry.Big = EntriesForCheck[i].Big;
                                    level4entry.Small = EntriesForCheck[i].Small;
                                    level4entry.StrikeAmount = 0.00;
                                    level4entry.DrawDate = drawdate;
                                    // Output the data
                                    //Console.WriteLine($"Level 4 Data ---- InvoiceId: {level4entry.InvoiceId}, Number: {level4entry.NumberVariation}, Big: {level4entry.Big}, Small: {level4entry.Small}, BigAmount: {level4entry.Big}, SmallAmount: {level4entry.Small}, DrawDate: {level4entry.DrawDate}");
                                    invoiceData.CreateInvoiceLevel4Entry(level4entry);
                                }
                            }
                            // Check if any of the required values are empty or zero
                            if (!string.IsNullOrEmpty(EntriesForCheck[i].Number))
                            {
                                //level 3 data entry
                                ILib_InvoiceLevel3DataModel level3entry = new InvoiceLevel3DataModel();
                                level3entry.InvoiceId = InvoiceId;
                                level3entry.Number = EntriesForCheck[i].Number;
                                level3entry.Big = EntriesForCheck[i].Big;
                                level3entry.Small = EntriesForCheck[i].Small;
                                level3entry.Roll = EntriesForCheck[i].Roll;
                                level3entry.DrawDate = drawdate;
                                // Output the data for Level 3 entry
                                //Console.WriteLine($"Level 3 Entry - InvoiceId: {level3entry.InvoiceId}, Number: {level3entry.Number}, Big: {level3entry.Big}, Small: {level3entry.Small}, Roll: {level3entry.Roll}, DrawDate: {level3entry.DrawDate}");
                                invoiceData.CreateInvoiceLevel3Entry(level3entry);
                            }
                        }
                        if (!string.IsNullOrEmpty(EntriesForCheck[i].Number))
                        {
                            //level 2 data entry
                            ILib_InvoiceLevel2DataModel level2entry = new InvoiceLevel2DataModel();
                            level2entry.DrawDates = EntriesForCheck[i].DrawDates;
                            level2entry.InvoiceId = InvoiceId;
                            level2entry.Number = EntriesForCheck[i].Number;
                            level2entry.NoOfVariations = EntriesForCheck[i].NumberVariations.Count;
                            level2entry.Big = EntriesForCheck[i].Big;
                            level2entry.Small = EntriesForCheck[i].Small;
                            level2entry.Roll = EntriesForCheck[i].Roll;
                            level2entry.Day = EntriesForCheck[i].Day;
                            level2entry.ActualBig = EntriesForCheck[i].ActualBig;
                            level2entry.ActualSmall = EntriesForCheck[i].ActualSmall;
                            level2entry.TotalCostForEntry = EntriesForCheck[i].TotalCostForEntry;
                            // Output the data for Level 2 entry
                            //Console.WriteLine($"Level 2 Entry - InvoiceId: {level2entry.InvoiceId}, Number: {level2entry.Number}, Big: {level2entry.Big}, Small: {level2entry.Small}, Roll: {level2entry.Roll}, BigAmount: {level2entry.ActualBig}, SmallAmount: {level2entry.ActualSmall}, TotalAmount: {level2entry.TotalCostForEntry}, DrawDates: {string.Join(", ", level2entry.DrawDates)}");
                            invoiceData.CreateInvoiceLevel2Entry(level2entry);
                        }
                    }
                }
                //level 1 data entry
                ILib_InvoiceLevel1DataModel level1entry = new InvoiceLevel1DataModel();
                level1entry.InvoiceId = InvoiceId;
                level1entry.TotalBig = TotalBigForCheck;
                level1entry.TotalSmall = TotalSmallForCheck;
                level1entry.TotalAmount = TotalCostForCheck;
                level1entry.StrikeAmount = 0.00;
                level1entry.PurchasedForId = InvoiceForWhoForCheck;
                level1entry.PurchasedById = InvoiceSubmittedByWhoForCheck;
                level1entry.MediaType = "Website";
                level1entry.PurchasedDate = DateTime.Now;
                level1entry.LastUpdatedOn = DateTime.Now;
                level1entry.PageName = InvoicePageNameForCheck;

                // Output the data for Level 1 entry
                //Console.WriteLine($"Level 1 Entry - InvoiceId: {level1entry.InvoiceId}, TotalBig: {level1entry.TotalBig}, TotalSmall: {level1entry.TotalSmall}, TotalAmount: {level1entry.TotalAmount}, StrikeAmount: {level1entry.StrikeAmount}, WhoseId: {level1entry.PurchasedForId},Media: {level1entry.MediaType}, EnteredBy: {level1entry.PurchasedById}, CreatedDate: {level1entry.PurchasedDate}, UpdatedOn: {level1entry.LastUpdatedOn}");
                invoiceData.CreateInvoiceLevel1Entry(level1entry);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            NavigationManager.NavigateTo("/BettingForm4D", forceLoad: true);
        }
    }
}