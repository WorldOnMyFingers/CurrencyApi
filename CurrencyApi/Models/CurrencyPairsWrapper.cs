using System;
using System.Collections.Generic;

namespace CurrencyApi.Models
{
    public class CurrencyPairsWrapper
    {
        public IEnumerable<CurrencyPairNameValue> Currencies { get; set; }
        public string LocalCountry { get; set; }
        public string LocalCurrencySymbol { get; set; }
        public string LocalCurrencyCode{ get; set; }
        public CurrencyPairsWrapper()
        {
        }
    }
}
