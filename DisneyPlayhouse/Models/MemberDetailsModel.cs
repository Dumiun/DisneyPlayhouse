using DisneyPlayhouseLibrary.Models;

namespace DisneyPlayhouse.Models
{
    public class MemberDetailsModel : ILib_MemberDetailsModel
    {
        public string? LoginId { get; set; }
        public string? ParentLoginId { get; set; }
        public bool? AutoCredit { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LatestLoggedInDate { get; set; }

        public double Credit { get; set; }
        public string PhoneNumber { get; set; }
        public double TicketComms { get; set; }
    }
}