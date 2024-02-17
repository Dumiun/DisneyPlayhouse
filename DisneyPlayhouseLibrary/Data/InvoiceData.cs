using DisneyPlayhouseLibrary.Models;
using DisneyPlayhouseLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyPlayhouseLibrary.Data
{
    public class InvoiceData : IInvoiceData
    {
        private readonly IDataAccessService _dataAccess;

        public InvoiceData(IDataAccessService dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task CreateInvoiceLevel1Entry(ILib_InvoiceLevel1DataModel data)
        {
            var entry = new
            {
                data.InvoiceId,
                data.PageName,
                data.TotalBig,
                data.TotalSmall,
                data.TotalAmount,
                data.StrikeAmount,
                data.PurchasedById,
                data.PurchasedForId,
                data.MediaType,
                data.PurchasedDate,
                data.LastUpdatedOn
            };
            await _dataAccess.SaveData("dbo.spInvoiceLevel1Entry_Insert", entry, "DefaultConnection");
        }

        public async Task CreateInvoiceLevel2Entry(ILib_InvoiceLevel2DataModel data)
        {
            var entry = new
            {
                data.InvoiceId,
                data.Number,
                data.Big,
                data.Small,
                data.Day,
                data.Roll,
                data.ActualBig,
                data.ActualSmall,
                data.TotalCostForEntry,
                DrawDate1 = data.DrawDates.Count > 0 ? data.DrawDates[0] : (DateTime?)null,
                DrawDate2 = data.DrawDates.Count > 1 ? data.DrawDates[1] : (DateTime?)null,
                DrawDate3 = data.DrawDates.Count > 2 ? data.DrawDates[2] : (DateTime?)null
            };
            await _dataAccess.SaveData("dbo.spInvoiceLevel2Entry_Insert", entry, "DefaultConnection");
        }

        public async Task CreateInvoiceLevel3Entry(ILib_InvoiceLevel3DataModel data)
        {
            var entry = new
            {
                data.InvoiceId,
                data.Number,
                data.Big,
                data.Small,
                data.Roll,
                DrawDate = data.DrawDate
            };
            await _dataAccess.SaveData("dbo.spInvoiceLevel3Entry_Insert", entry, "DefaultConnection");
        }

        public async Task CreateInvoiceLevel4Entry(ILib_InvoiceLevel4DataModel data)
        {
            var entry = new
            {
                data.InvoiceId,
                data.NumberVariation,
                data.PurchasedNumber,
                data.PurchasedRoll,
                data.Big,
                data.Small,
                data.DrawDate,
                data.StrikeAmount
            };
            await _dataAccess.SaveData("dbo.spInvoiceLevel4Entry_Insert", entry, "DefaultConnection");
        }
    }
}