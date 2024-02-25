using DisneyPlayhouseLibrary.Models;

namespace DisneyPlayhouseLibrary.Data
{
    public interface IMemberData
    {
        Task CreateNewMemberDetails(ILib_MemberDetailsModel info);
        Task CreateNewMemberRelationship(ILib_MemberDetailsModel info);
        Task<List<ILib_ListOfChildIdModel>> GetListOfChildId(string currentUserId);
        Task<List<ILib_ListOfChildIdModel>> GetListOfDirectChildId(string currentUserId);
        Task<List<ILib_ListOfParentIdModel>> GetListOfParentId();
    }
}