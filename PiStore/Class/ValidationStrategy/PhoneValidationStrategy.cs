using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PiStore.Class.ValidationStrategy
{
    public class PhoneValidationStrategy : IValidationStrategy
    {
        public bool Validate(string number)
        {
            return Regex.IsMatch(number, @"^[0-9]{10}$");
        }
    }
}
