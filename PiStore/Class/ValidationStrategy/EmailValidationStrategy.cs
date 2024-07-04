using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiStore.Class.ValidationStrategy
{
    public class EmailValidationStrategy : IValidationStrategy
    {
        public bool Validate(string source)
        {
            return new EmailAddressAttribute().IsValid(source);
        }
    }
}
