using DisneyPlayhouseLibrary.Models;

namespace DisneyPlayhouseLibrary.Data
{
    public interface IMemberData
    {
        Task CreateNewMemberDetails(ILib_MemberDetailsModel info);
    }
}