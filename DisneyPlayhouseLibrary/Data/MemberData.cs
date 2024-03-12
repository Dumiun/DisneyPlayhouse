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
    public class MemberData : IMemberData
    {
        private readonly IDataAccessService _dataAccess;

        public MemberData(IDataAccessService dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task CreateNewMemberDetails(ILib_MemberDetailsModel info)
        {
            var newMember = new
            {
                LoginId = info.LoginId,
                ParentLoginId = info.ParentLoginId,
                AutoCredit = info.AutoCredit,
                CreatedDate = info.CreatedDate,
                LatestLoggedInDate = info.LatestLoggedInDate
            };

            var newCreditRecord = new
            {
                MemberId = info.LoginId,
                CreditAllowed = info.Credit,
                UsedCredit = 0,
                RemainingCredit = info.Credit,
                lastUpdatedOn = info.CreatedDate
            };

            var newTicketCommsRecord = new
            {
                MemberId = info.LoginId,
                CommsPercentage = info.TicketComms,
                LastUpdatedOn = info.CreatedDate
            };

            await _dataAccess.SaveData("dbo.spMember_Insert", newMember, "DefaultConnection");
            await _dataAccess.SaveData("dbo.spMemberCredit_Insert", newCreditRecord, "DefaultConnection");
            await _dataAccess.SaveData("dbo.spMemberTicketComms_Insert", newTicketCommsRecord, "DefaultConnection");
        }

        public async Task CreateNewMemberRelationship(ILib_MemberDetailsModel info)
        {
            var newRS = new
            {
                ChildId = info.LoginId,
                ParentId = info.ParentLoginId,
            };

            await _dataAccess.SaveData("dbo.spMemberRelationshipTree_Insert", newRS, "DefaultConnection");
        }

        public async Task<List<ILib_ListOfParentIdModel>> GetListOfParentId()
        {
            var parentList = await _dataAccess.LoadData<Lib_ListOfParentIdModel, dynamic>("dbo.spParentId_Search", new { }, "DefaultConnection");
            return parentList.ToList<ILib_ListOfParentIdModel>();
        }

        public async Task<List<ILib_ListOfChildIdModel>> GetListOfChildId(string currentUserId)
        {
            var childList = await _dataAccess.LoadData<Lib_ListOfChildIdModel, dynamic>("dbo.spChildId_Search", new { ParentId = currentUserId }, "DefaultConnection");
            return childList.ToList<ILib_ListOfChildIdModel>();
        }

        public async Task<List<ILib_ListOfChildIdModel>> GetListOfDirectChildId(string currentUserId)
        {
            var childList = await _dataAccess.LoadData<Lib_ListOfChildIdModel, dynamic>("dbo.spDirectChildId_Search", new { ParentId = currentUserId }, "DefaultConnection");
            return childList.ToList<ILib_ListOfChildIdModel>();
        }

        public async Task<double> GetTicketCommsOfUser(string userId)
        {
            var commsValue = await _dataAccess.LoadData<double, dynamic>("dbo.spMemberTicketComms_Search", new { MemberId = userId }, "DefaultConnection");

            return commsValue.FirstOrDefault();
        }

        public async Task<double> GetCreditOfUser(string userId)
        {
            var creditValue = await _dataAccess.LoadData<double, dynamic>("dbo.spMemberCredit_Search", new { MemberId = userId }, "DefaultConnection");

            return creditValue.FirstOrDefault();
        }

        public async Task UpdatedMemberCredit(string user, double newValue)
        {
            var newUpdate = new
            {
                MemberId = user,
                CreditAllowed = newValue,
                LastUpdatedOn = DateTime.Now
            };

            await _dataAccess.SaveData("dbo.spMemberCredit_Update", newUpdate, "DefaultConnection");
        }

        public async Task UpdatedMemberTicketComms(string user, double newValue)
        {
            var newUpdate = new
            {
                MemberId = user,
                CommsPercentage = newValue,
                LastUpdatedOn = DateTime.Now
            };

            await _dataAccess.SaveData("dbo.spMemberTicketComms_Update", newUpdate, "DefaultConnection");
        }

        public async Task<Lib_AccountCreditModel> GetCreditDataOfUser(string userId)
        {
            var creditData = await _dataAccess.LoadData<Lib_AccountCreditModel, dynamic>("dbo.spMemberCreditData_Search", new { MemberId = userId }, "DefaultConnection");

            return creditData.FirstOrDefault();
        }

        public async Task<double> GetCommissionOfUser(string userId)
        {
            var commsData = await _dataAccess.LoadData<double, dynamic>("dbo.spMemberComms_Search", new { MemberId = userId }, "DefaultConnection");

            return commsData.FirstOrDefault();
        }

        public async Task<bool> GetIsAutoCreditOfUser(string userId)
        {
            var commsData = await _dataAccess.LoadData<bool, dynamic>("dbo.spMemberAutoCredit_Search", new { LoginId = userId }, "DefaultConnection");

            return commsData.FirstOrDefault();
        }
    }
}