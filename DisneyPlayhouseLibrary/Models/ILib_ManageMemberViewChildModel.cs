namespace DisneyPlayhouseLibrary.Models
{
    public interface ILib_ManageMemberViewChildModel
    {
        double? CommsPercentage { get; set; }
        double? CreditAmount { get; set; }
        string? CurrencyType { get; set; }
        string? HandPhoneNo { get; set; }
        string MemberId { get; set; }
        string MemberParentId { get; set; }
        string Role { get; set; }
    }
}