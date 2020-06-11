using System;
namespace CurrencyApi.Models
{
    public class CurrencyValue
    {
        public DateTime DateTime { get; set; }
        public decimal Value { get; set; }
        public CurrencyValue()
        {
        }
    }
}
