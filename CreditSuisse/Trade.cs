using System;
using System.Collections.Generic;
using System.Text;

namespace CreditSuisse
{
    public class Trade : ITrade
    {
        private const int DAYS_LATE_LIMIT = 30;
        private const double VALUE_LIMIT = 1000000;

        public double Value { get; }

        public string ClientSector { get; }

        public DateTime NextPaymentDate { get; }

        public bool IsPoliticallyExposed { get; }

        public Trade( double value, string clientSector, DateTime NextPaymentDate)
        {
            this.Value = value;
            this.ClientSector = clientSector;
            this.NextPaymentDate = NextPaymentDate;
        }

        public string GetCategory(DateTime referenceDate)
        {
            if (this.IsExpired(referenceDate))
                return "EXPIRED";

            if (this.IsHighRick())
                return ("HIGHRISK");

            if (this.IsMediumRisk())
                return ("MEDIUMRISK");

            return "Risk not defined!";
        }

        private bool IsExpired(DateTime referenceDate)
        {
            if (NextPaymentDate >= DateTime.Now)
                return false;

            return Math.Abs((NextPaymentDate - referenceDate).Days) > DAYS_LATE_LIMIT;
        }

        private bool IsHighRick()
        {
            return (Value > VALUE_LIMIT && ClientSector.ToLower().Equals("private"));
         
        }
        private bool IsMediumRisk()
        {
            return (Value > VALUE_LIMIT && ClientSector.ToLower().Equals("public"));
        }
    }
}
