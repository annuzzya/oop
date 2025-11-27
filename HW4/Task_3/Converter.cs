using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_2
{
    public class Converter
    {
        public decimal USDrate { get; }
        public decimal EURrate { get; }

        public Converter(decimal usd, decimal eur)
        {
            USDrate = usd;
            EURrate = eur;
        }

        public decimal ConvertUahToUsd(decimal amountUAH)
        {
            return amountUAH / USDrate;
        }

        public decimal ConvertUsdToUah(decimal amountUSD)
        {
            return amountUSD * USDrate;
        }

        public decimal ConvertUahToEur(decimal amountUAH)
        {
            return amountUAH / EURrate;
        }

        public decimal ConvertEurToUah(decimal amountEUR)
        {
            return amountEUR * EURrate;
        }
    }
}
