﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyPlayhouseLibrary.Models
{
    public class Lib_ManageMemberViewChildModel : ILib_ManageMemberViewChildModel
    {
        public string MemberParentId { get; set; }
        public string MemberId { get; set; }
        public string Role { get; set; }
        public string? HandPhoneNo { get; set; }
        public double? CommsPercentage { get; set; }
        public double? CreditAmount { get; set; }
        public string? CurrencyType { get; set; }
    }
}