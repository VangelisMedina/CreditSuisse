using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CreditSuisse
{
    public class TradeConsoleValidator
    {
        public static DateTime? ReferenceDateValidation(string referenceDateInput)
        {
            DateTime aux;
            if (DateTime.TryParse(referenceDateInput, new CultureInfo("en-US"), DateTimeStyles.None, out aux))
            {
                return aux;
            }
            return null;
        }
    }
}
