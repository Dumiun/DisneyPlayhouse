
namespace DisneyPlayhouseLibrary.Models
{
    public interface ILib_MemberDetailsModel
    {
        bool? AutoCredit { get; set; }
        DateTime? CreatedDate { get; set; }
        DateTime? LatestLoggedInDate { get; set; }
        string? LoginId { get; set; }
        string? ParentLoginId { get; set; }
    }
}