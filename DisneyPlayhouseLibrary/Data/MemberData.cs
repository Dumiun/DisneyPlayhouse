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

            await _dataAccess.SaveData("dbo.spMember_Insert", newMember, "DefaultConnection");
        }
    }
}