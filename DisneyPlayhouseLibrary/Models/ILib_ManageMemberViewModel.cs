namespace DisneyPlayhouseLibrary.Models
{
    public interface ILib_ManageMemberViewModel
    {
        double? CommsPercentage { get; set; }
        double? CreditAmount { get; set; }
        string? CurrencyType { get; set; }
        string? HandPhoneNo { get; set; }
        string MemberId { get; set; }
        string Role { get; set; }
    }
}