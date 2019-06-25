using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI.CustomAttributes
{
    public class MyStringLengthAttribute : StringLengthAttribute
    {
        public MyStringLengthAttribute(int maximumLength) : base(maximumLength)
        {
        }

        public override bool IsValid(object value)
        {
            string val = Convert.ToString(value);
            if (val.Length < base.MinimumLength)
                base.ErrorMessage = "Minimum length should be 3";
            if (val.Length > base.MaximumLength)
                base.ErrorMessage = "Maximum length should be 6";
            return base.IsValid(value);
        }
    }
}
