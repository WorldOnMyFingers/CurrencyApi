using System;
namespace CurrencyApi.Models
{
    public class CurrencyNameAndCode
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Country { get; set; }
        public int Order { get; set; }
        public CurrencyNameAndCode()
        {
        }
    }
}
