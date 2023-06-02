using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpendingManagement.CustomValidation
{
    public class LengthFilm : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int length = int.Parse(value.ToString());
            return length >= 1;
        }
    }
}