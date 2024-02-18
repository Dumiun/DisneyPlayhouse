using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyPlayhouseLibrary.Models
{
    public class Lib_ListOfParentIdModel : ILib_ListOfParentIdModel
    {
        public string? LoginId { get; set; }
    }
}