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

        public async Task<List<List<Lib_InvoiceLevel1DataModel>>> GetNumberVariationsOfSelectedNumberInInvoice(ILib_ReportHistoryModel searchDetails)
        {
            // Get List of child of current user
            List<List<Lib_InvoiceLevel1DataModel>> listOfChildInvoices = new List<List<Lib_InvoiceLevel1DataModel>>();
            var childList = await _dataAccess.LoadData<Lib_ListOfChildIdModel, dynamic>("dbo.spChildId_Search", new { ParentId = searchDetails.ReportForId }, "DefaultConnection");

            // Add current user's invoices to the list
            var invoicesOfCurrentUser = await _dataAccess.LoadData<Lib_InvoiceLevel1DataModel, dynamic>("dbo.spGetCurrentUserLevel1Invoices", new { PurchasedForId = searchDetails.ReportForId, FromDate = searchDetails.FromDate, ToDate = searchDetails.ToDate }, "DefaultConnection");
            Console.WriteLine("OK");
            listOfChildInvoices.Add(invoicesOfCurrentUser);

            // Add child's invoices to the list if childList is not null

            if (childList != null)
            {
                foreach (var child in childList)
                {
                    var invoicesOfChild = await _dataAccess.LoadData<Lib_InvoiceLevel1DataModel, dynamic>("dbo.spGetChildLevel1Invoices", new { PurchasedForId = child.ChildId, FromDate = searchDetails.FromDate, ToDate = searchDetails.ToDate }, "DefaultConnection");
                    listOfChildInvoices.Add(invoicesOfChild);
                }
            }

            return listOfChildInvoices;
        }
    }
}