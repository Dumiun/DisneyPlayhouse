using DisneyPlayhouseLibrary.Models;

namespace DisneyPlayhouseLibrary.Data
{
    public interface IMemberData
    {
        Task CreateNewMemberDetails(ILib_MemberDetailsModel info);

        Task CreateNewMemberRelationship(ILib_MemberDetailsModel info);
        Task<Lib_AccountCreditModel> GetCreditDataOfUser(string userId);
        Task<double> GetCreditOfUser(string userId);

        Task<List<ILib_ListOfChildIdModel>> GetListOfChildId(string currentUserId);

        Task<List<ILib_ListOfChildIdModel>> GetListOfDirectChildId(string currentUserId);

        Task<List<ILib_ListOfParentIdModel>> GetListOfParentId();

        Task<double> GetTicketCommsOfUser(string userId);

        Task UpdatedMemberCredit(string user, double newValue);

        Task UpdatedMemberTicketComms(string user, double newValue);
    }
}