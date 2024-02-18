using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyPlayhouseLibrary.Models
{
    public class Lib_MemberDetailsModel : ILib_MemberDetailsModel
    {
        public string? LoginId { get; set; }
        public string? ParentLoginId { get; set; }
        public bool? AutoCredit { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LatestLoggedInDate { get; set; }
    }
}