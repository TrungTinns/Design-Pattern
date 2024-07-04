using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiStore.Class.ValidationStrategy
{
    public class IntegerValidationStrategy : IValidationStrategy
    {
        public bool Validate(string data)
        {
            bool isValid = int.TryParse(data, out int result);

            return isValid && result >= 0;
        }
    }
}
