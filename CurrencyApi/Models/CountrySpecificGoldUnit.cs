using System;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;

namespace CurrencyApi.Models
{
    public class CountrySpecificGoldUnit
    {
        public string Name { get; set; }
        public string LocalCurrencyCode { get; set; }
        public string LocalCurrencySymbol { get; set; }
        public int Order { get; set; }
        public string GoldOunceFxCode
        {
            get
            {
                return "XAU/USD";
            }
        }
        public double Unit { get; set; }
        public double OunceWeight
        {
            get
            {
                return 31.1034768;
            }
        }

        public CountrySpecificGoldUnit()
        {
        }

        public CurrencyValue CalculatePrice(decimal ounceFx, decimal localFx)
        {
            return new CurrencyValue
            {
                Value = Math.Round((ounceFx / (decimal)OunceWeight) * (decimal)Unit * localFx, 4),
                DateTime = DateTime.Now
            };

        }
    }
}
