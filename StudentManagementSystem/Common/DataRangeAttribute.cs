using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Common
{
    public class DataRangeAttribute:RangeAttribute
    {
        public DataRangeAttribute(string minumumValue)
            : base(typeof (DateTime), minumumValue, DateTime.Now.ToShortDateString())
        {
            
        }
    }
}