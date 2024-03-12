using Dapper;
using DisneyPlayhouseLibrary.Models;
using DisneyPlayhouseLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyPlayhouseLibrary.Data
{
    public class ReportData : IReportData
    {
        private readonly IDataAccessService _dataAccess;

        public ReportData(IDataAccessService dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<List<List<Lib_InvoiceLevel1DataModel>>> GetNumberVariationsOfSelectedNumberInInvoice(string reportForId, DateTime fromDate, DateTime toDate)
        {
            // Get List of child of current user
            List<List<Lib_InvoiceLevel1DataModel>> listOfChildInvoices = new List<List<Lib_InvoiceLevel1DataModel>>();
            var childList = await _dataAccess.LoadData<Lib_ListOfChildIdModel, dynamic>("dbo.spChildId_Search", new { ParentId = reportForId }, "DefaultConnection");

            // Add current user's invoices to the list
            var invoicesOfCurrentUser = await _dataAccess.LoadData<Lib_InvoiceLevel1DataModel, dynamic>("dbo.spGetCurrentUserLevel1Invoices", new { PurchasedForId = reportForId, FromDate = fromDate, ToDate = toDate }, "DefaultConnection");
            Console.WriteLine("OK");
            listOfChildInvoices.Add(invoicesOfCurrentUser);

            // Add child's invoices to the list if childList is not null

            if (childList != null)
            {
                foreach (var child in childList)
                {
                    var invoicesOfChild = await _dataAccess.LoadData<Lib_InvoiceLevel1DataModel, dynamic>("dbo.spGetChildLevel1Invoices", new { PurchasedForId = child.ChildId, FromDate = fromDate, ToDate = toDate }, "DefaultConnection");
                    listOfChildInvoices.Add(invoicesOfChild);
                }
            }

            return listOfChildInvoices;
        }

        public async Task<List<Lib_DateRangeModel>> GetDateRangeForCurrentUserPageReport(string reportForId, DateTime fromDate, DateTime toDate)
        {
            var dateRange = await _dataAccess.LoadData<Lib_DateRangeModel, dynamic>("dbo.spGetDateRangeForCurrentUserPageReport", new { PurchasedForId = reportForId, FromDate = fromDate, ToDate = toDate }, "DefaultConnection");

            return dateRange;
        }

        public async Task<List<Lib_InvoiceLevel1_5DataModel>> GetPageRecordsForUserOnDrawDate(string reportForId, DateTime drawDate)
        {
            var invoices = await _dataAccess.LoadData<Lib_InvoiceLevel1_5DataModel, dynamic>("dbo.spGetPageRecordsForUserOnDrawDate", new { PurchasedForId = reportForId, DrawDate = drawDate }, "DefaultConnection");

            return invoices;
        }
    }
}