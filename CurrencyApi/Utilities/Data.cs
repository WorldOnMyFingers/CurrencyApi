using System;
using System.Collections.Generic;
using CurrencyApi.Models;

namespace CurrencyApi.Utilities
{
    public static class Data
    {
        public static Dictionary<string, CurrencyNameAndCode> currencyNameAndCodes = new Dictionary<string, CurrencyNameAndCode>
        {
            { "USD", new CurrencyNameAndCode { Code = "USD", Name = "American Dollar", Country = "United States", Order = 1 } },
            { "EUR", new CurrencyNameAndCode { Code = "EUR", Name = "Euro", Country = "Germany", Order = 2 } },
            { "GBP", new CurrencyNameAndCode { Code = "GBP", Name = "British Pound", Country = "United Kingdom", Order = 3 } },
            { "XAU", new CurrencyNameAndCode { Code = "XAU", Name = "Gold Ounce", Order = 4 } },
            { "PKR", new CurrencyNameAndCode { Code = "PKR", Name = "Pakistani Rupee", Country = "Pakistan", Order = 7 } },
            { "INR", new CurrencyNameAndCode { Code = "INR", Name = "Indian Rupee", Country = "India", Order = 8 } },
            //{ "CNY", new CurrencyNameAndCode { Code = "CNY", Name = "Chinese Yuan", Order = 4 } },
            //{ "JPY", new CurrencyNameAndCode { Code = "JPY", Name = "Japanese Yen", Order = 5 } },
            //{ "NZD", new CurrencyNameAndCode { Code = "NZD", Name = "New Zealand Dollars", Order = 30} },
            //{ "AUD", new CurrencyNameAndCode { Code = "AUD", Name = "Australian Dollars", Order = 31} },
            //{ "HKD", new CurrencyNameAndCode { Code = "HKD", Name = "HKD", Order = 35} },
            //{ "CAD", new CurrencyNameAndCode { Code = "CAD", Name = "Canadian Dollar", Order = 10} },
            //{ "AFN", new CurrencyNameAndCode { Code = "AFN", Name = "Afghan Afghani", Order = 100} },
            //{ "ALL", new CurrencyNameAndCode { Code = "ALL", Name = "Abanian Lek", Order = 90} },
            //{ "DZD", new CurrencyNameAndCode { Code = "DZD", Name = "Algerian Dinar", Order = 91} },
            //{ "XCD", new CurrencyNameAndCode { Code = "XCD", Name = "East Caribbean Dollar", Order = 101} },
            //{ "ARS", new CurrencyNameAndCode { Code = "ARS", Name = "Peso", Order = 99} },
            //{ "AMD", new CurrencyNameAndCode { Code = "AMD", Name = "Dram", Order = 99} },
            //{ "ANG", new CurrencyNameAndCode { Code = "ANG", Name = "Netherlands Antilles Guilder", Order = 99} },
            //{ "AZN", new CurrencyNameAndCode { Code = "AZN", Name = "Manat", Order = 99 } },
            //{ "BSD", new CurrencyNameAndCode { Code = "BSD", Name = "Bahamian Dollar", Order = 99} },
            //{ "BHD", new CurrencyNameAndCode { Code = "BHD", Name = "Bahraini Dinar", Order = 99} },
            //{ "BDT", new CurrencyNameAndCode { Code = "BDT", Name = "Taka", Order = 99} },
            //{ "BBD", new CurrencyNameAndCode { Code = "BBD", Name = "Barbadian Dollar", Order = 99} },
            //{ "BYR", new CurrencyNameAndCode { Code = "BYR", Name = "Belarus Ruble", Order = 99} },
            //{ "BZD", new CurrencyNameAndCode { Code = "BZD", Name = "Belizean Dollar", Order = 99 } },
            //{ "XOF", new CurrencyNameAndCode { Code = "XOF", Name = "CFA Franc BCEAO", Order = 99} },
            //{ "BMD", new CurrencyNameAndCode { Code = "BMD", Name = "Bermudian Dollar", Order = 99} },
            //{ "BOB", new CurrencyNameAndCode { Code = "BOB", Name = "Boliviano", Order = 99} },
            //{ "BWP", new CurrencyNameAndCode { Code = "BWP", Name = "Pula", Order = 99} },
            //{ "NOK", new CurrencyNameAndCode { Code = "NOK", Name = "Norwegian Krone", Order = 99} },
            //{ "BRL", new CurrencyNameAndCode { Code = "BRL", Name = "Brazil", Order = 99} },
            //{ "BND", new CurrencyNameAndCode { Code = "BND", Name = "Bruneian Dollar", Order = 99} },
            //{ "BGN", new CurrencyNameAndCode { Code = "BGN", Name = "Lev", Order = 99} },
            //{ "BIF", new CurrencyNameAndCode { Code = "BIF", Name = "Burundi Franc", Order = 99} },
            //{ "KHR", new CurrencyNameAndCode { Code = "KHR", Name = "Riel", Order = 99} },
            //{ "XAF", new CurrencyNameAndCode { Code = "XAF", Name = "CFA Franc BEAC", Order = 99} },
            //{ "CVE", new CurrencyNameAndCode { Code = "CVE", Name = "Escudo", Order = 99} },
            //{ "KYD", new CurrencyNameAndCode { Code = "KYD", Name = "Caymanian Dollar", Order = 99} },
            //{ "CLP", new CurrencyNameAndCode { Code = "CLP", Name = "Chilean Peso", Order = 99} },
            //{ "COP", new CurrencyNameAndCode { Code = "COP", Name = "Peso", Order = 99} },
            //{ "KMF", new CurrencyNameAndCode { Code = "KMF", Name = "Comoran Franc", Order = 99} },
            //{ "CDF", new CurrencyNameAndCode { Code = "CDF", Name = "Congolese Frank", Order = 99} },
            //{ "CRC", new CurrencyNameAndCode { Code = "CRC", Name = "Costa Rican Colon", Order = 99} },
            //{ "HRK", new CurrencyNameAndCode { Code = "HRK", Name = "Croatian Dinar", Order = 99} },
            //{ "CUP", new CurrencyNameAndCode { Code = "CUP", Name = "Cuban Peso", Order = 99} },
            //{ "CYP", new CurrencyNameAndCode { Code = "CYP", Name = "Cypriot Pound", Order = 99} },
            //{ "CZK", new CurrencyNameAndCode { Code = "CZK", Name = "Koruna", Order = 99} },
            //{ "DKK", new CurrencyNameAndCode { Code = "DKK", Name = "Danish Krone", Order = 99} },
            //{ "DJF", new CurrencyNameAndCode { Code = "DJF", Name = "Djiboutian Franc", Order = 99} },
            //{ "DOP", new CurrencyNameAndCode { Code = "DOP", Name = "Dominican Peso", Order = 99} },
            //{ "IDR", new CurrencyNameAndCode { Code = "IDR", Name = "Indonesian Rupiah", Order = 99} },
            //{ "ECS", new CurrencyNameAndCode { Code = "ECS", Name = "Sucre", Order = 99} },
            //{ "EGP", new CurrencyNameAndCode { Code = "EGP", Name = "Egyptian Pound", Order = 99} },
            //{ "SVC", new CurrencyNameAndCode { Code = "SVC", Name = "Salvadoran Colon", Order = 99} },
            //{ "ETB", new CurrencyNameAndCode { Code = "ETB", Name = "Ethiopian Birr", Order = 99} },
            //{ "EEK", new CurrencyNameAndCode { Code = "EEK", Name = "Estonian Kroon", Order = 99} },
            //{ "FKP", new CurrencyNameAndCode { Code = "FKP", Name = "Falkland Pound", Order = 99} },
            //{ "FJD", new CurrencyNameAndCode { Code = "FJD", Name = "Fijian Dollar", Order = 99} },
            //{ "XPF", new CurrencyNameAndCode { Code = "XPF", Name = "CFP Franc", Order = 99} },
            //{ "GMD", new CurrencyNameAndCode { Code = "GMD", Name = "Dalasi", Order = 99} },
            //{ "GEL", new CurrencyNameAndCode { Code = "GEL", Name = "Lari", Order = 99 } },
            //{ "GIP", new CurrencyNameAndCode { Code = "GIP", Name = "Gibraltar Pound", Order = 99} },
            //{ "GTQ", new CurrencyNameAndCode { Code = "GTQ", Name = "Quetzal", Order = 99} },
            //{ "GNF", new CurrencyNameAndCode { Code = "GNF", Name = "Guinean Franc", Order = 99} },
            //{ "GYD", new CurrencyNameAndCode { Code = "GYD", Name = "Guyanaese Dollar", Order = 99} },
            //{ "HTG", new CurrencyNameAndCode { Code = "HTG", Name = "Gourde", Order = 99} },
            //{ "HNL", new CurrencyNameAndCode { Code = "HNL", Name = "Lempira", Order = 99} },
            //{ "HUF", new CurrencyNameAndCode { Code = "HUF", Name = "Forint", Order = 99} },
            //{ "ISK", new CurrencyNameAndCode { Code = "ISK", Name = "Icelandic Krona", Order = 99} },
            //{ "IRR", new CurrencyNameAndCode { Code = "IRR", Name = "Iranian Rial", Order = 99} },
            //{ "IQD", new CurrencyNameAndCode { Code = "IQD", Name = "Iraqi Dinar", Order = 99} },
            //{ "ILS", new CurrencyNameAndCode { Code = "ILS", Name = "Shekel", Order = 99} },
            //{ "JMD", new CurrencyNameAndCode { Code = "JMD", Name = "Jamaican Dollar", Order = 99} },
            //{ "JOD", new CurrencyNameAndCode { Code = "JOD", Name = "Jordanian Dinar", Order = 99} },
            //{ "KZT", new CurrencyNameAndCode { Code = "KZT", Name = "Tenge", Order = 99} },
            //{ "KES", new CurrencyNameAndCode { Code = "KES", Name = "Kenyan Shilling", Order = 99} },
            //{ "KPW", new CurrencyNameAndCode { Code = "KPW", Name = "North Korean Won", Order = 99} },
            //{ "KRW", new CurrencyNameAndCode { Code = "KRW", Name = "South Korean Won", Order = 99} },
            //{ "KWD", new CurrencyNameAndCode { Code = "KWD", Name = "Kuwaiti Dinar", Order = 99} },
            //{ "KGS", new CurrencyNameAndCode { Code = "KGS", Name = "Som", Order = 99} },
            //{ "LAK", new CurrencyNameAndCode { Code = "LAK", Name = "Kip", Order = 99} },
            //{ "LVL", new CurrencyNameAndCode { Code = "LVL", Name = "Lat", Order = 99} },
            //{ "LBP", new CurrencyNameAndCode { Code = "LBP", Name = "Lebanese Pound", Order = 99} },
            //{ "LSL", new CurrencyNameAndCode { Code = "LSL", Name = "Loti", Order = 99} },
            //{ "LRD", new CurrencyNameAndCode { Code = "LRD", Name = "Liberian Dollar", Order = 99} },
            //{ "LYD", new CurrencyNameAndCode { Code = "LYD", Name = "Libyan Dinar", Order = 99} },
            //{ "CHF", new CurrencyNameAndCode { Code = "CHF", Name = "Swiss Franc", Order = 99} },
            //{ "CHF", new CurrencyNameAndCode { Code = "CHF", Name = "Swiss Franc", Order = 99} },
            //{ "LTL", new CurrencyNameAndCode { Code = "LTL", Name = "Lita", Order = 99} },
            //{ "MOP", new CurrencyNameAndCode { Code = "MOP", Name = "Pataca", Order = 99} },
            //{ "MKD", new CurrencyNameAndCode { Code = "MKD", Name = "Denar", Order = 99} },
            //{ "MGA", new CurrencyNameAndCode { Code = "MGA", Name = "Malagasy Franc", Order = 99} },
            //{ "MWK", new CurrencyNameAndCode { Code = "MWK", Name = "Malawian Kwacha", Order = 99} },
            //{ "MYR", new CurrencyNameAndCode { Code = "MYR", Name = "Ringgit", Order = 99} },
            //{ "MVR", new CurrencyNameAndCode { Code = "MVR", Name = "Rufiyaa", Order = 99} },
            //{ "MTL", new CurrencyNameAndCode { Code = "MTL", Name = "Maltese Lira", Order = 99} },
            //{ "MRO", new CurrencyNameAndCode { Code = "MRO", Name = "Ouguiya", Order = 99} },
            //{ "MUR", new CurrencyNameAndCode { Code = "MUR", Name = "Mauritian Rupee", Order = 99} },
            //{ "MXN", new CurrencyNameAndCode { Code = "MXN", Name = "Peso", Order = 99} },
            //{ "MDL", new CurrencyNameAndCode { Code = "MDL", Name = "Leu", Order = 99} },
            //{ "MNT", new CurrencyNameAndCode { Code = "MNT", Name = "Tugrik", Order = 99} },
            //{ "MAD", new CurrencyNameAndCode { Code = "MAD", Name = "Dirham", Order = 99} },
            //{ "MAD", new CurrencyNameAndCode { Code = "MAD", Name = "Dirham", Order = 99} },
            //{ "MZN", new CurrencyNameAndCode { Code = "MZN", Name = "Metical", Order = 99} },
            //{ "MMK", new CurrencyNameAndCode { Code = "MMK", Name = "Kyat", Order = 99} },
            //{ "NAD", new CurrencyNameAndCode { Code = "NAD", Name = "Dollar", Order = 99} },
            //{ "NPR", new CurrencyNameAndCode { Code = "NPR", Name = "Nepalese Rupee", Order = 99} },
            //{ "NIO", new CurrencyNameAndCode { Code = "NIO", Name = "Cordoba Oro", Order = 99} },
            //{ "NGN", new CurrencyNameAndCode { Code = "NGN", Name = "Naira", Order = 99} },
            //{ "OMR", new CurrencyNameAndCode { Code = "OMR", Name = "Sul Rial", Order = 99} },
            //{ "PAB", new CurrencyNameAndCode { Code = "PAB", Name = "Balboa", Order = 99} },
            //{ "PGK", new CurrencyNameAndCode { Code = "PGK", Name = "Kina", Order = 99} },
            //{ "PYG", new CurrencyNameAndCode { Code = "PYG", Name = "Guarani", Order = 99} },
            //{ "PEN", new CurrencyNameAndCode { Code = "PEN", Name = "Nuevo Sol", Order = 99} },
            //{ "PHP", new CurrencyNameAndCode { Code = "PHP", Name = "Peso", Order = 99} },
            //{ "PLN", new CurrencyNameAndCode { Code = "PLN", Name = "Zloty", Order = 99} },
            //{ "QAR", new CurrencyNameAndCode { Code = "QAR", Name = "Rial", Order = 99} },
            //{ "RON", new CurrencyNameAndCode { Code = "RON", Name = "Leu", Order = 99} },
            //{ "RUB", new CurrencyNameAndCode { Code = "RUB", Name = "Ruble", Order = 99} },
            //{ "RWF", new CurrencyNameAndCode { Code = "RWF", Name = "Rwanda Franc", Order = 99} },
            //{ "STD", new CurrencyNameAndCode { Code = "STD", Name = "Dobra", Order = 99} },
            //{ "SAR", new CurrencyNameAndCode { Code = "SAR", Name = "Riyal", Order = 99} },
            //{ "SCR", new CurrencyNameAndCode { Code = "SCR", Name = "Rupee", Order = 99} },
            //{ "SLL", new CurrencyNameAndCode { Code = "SLL", Name = "Leone", Order = 99} },
            //{ "SGD", new CurrencyNameAndCode { Code = "SGD", Name = "Dollar", Order = 99} },
            //{ "SKK", new CurrencyNameAndCode { Code = "SKK", Name = "Koruna", Order = 99} },
            //{ "SBD", new CurrencyNameAndCode { Code = "SBD", Name = "Solomon Islands Dollar", Order = 99} },
            //{ "SOS", new CurrencyNameAndCode { Code = "SOS", Name = "Shilling", Order = 99} },
            //{ "ZAR", new CurrencyNameAndCode { Code = "ZAR", Name = "Rand", Order = 99} },
            //{ "LKR", new CurrencyNameAndCode { Code = "LKR", Name = "Rupee", Order = 99} },
            //{ "SDG", new CurrencyNameAndCode { Code = "SDG", Name = "Dinar", Order = 99} },
            //{ "SRD", new CurrencyNameAndCode { Code = "SRD", Name = "Surinamese Guilder", Order = 99} },
            //{ "SZL", new CurrencyNameAndCode { Code = "SZL", Name = "Lilangeni", Order = 99} },
            //{ "SEK", new CurrencyNameAndCode { Code = "SEK", Name = "Krona", Order = 99} },
            //{ "SYP", new CurrencyNameAndCode { Code = "SYP", Name = "Syrian Pound", Order = 99} },
            //{ "TWD", new CurrencyNameAndCode { Code = "TWD", Name = "Dollar", Order = 99} },
            //{ "TJS", new CurrencyNameAndCode { Code = "TJS", Name = "Tajikistan Ruble", Order = 99} },
            //{ "TZS", new CurrencyNameAndCode { Code = "TZS", Name = "Shilling", Order = 99} },
            //{ "THB", new CurrencyNameAndCode { Code = "THB", Name = "Baht", Order = 99} },
            //{ "TOP", new CurrencyNameAndCode { Code = "TOP", Name = "PaÕanga", Order = 99} },
            //{ "TTD", new CurrencyNameAndCode { Code = "TTD", Name = "Trinidad and Tobago Dollar", Order = 99} },
            //{ "TND", new CurrencyNameAndCode { Code = "TND", Name = "Tunisian Dinar", Order = 99} },
            { "TRY", new CurrencyNameAndCode { Code = "TRY", Name = "Lira", Country = "Turkey", Order = 6} },
            //{ "TMT", new CurrencyNameAndCode { Code = "TMT", Name = "Manat", Order = 99} },
            //{ "UGX", new CurrencyNameAndCode { Code = "UGX", Name = "Shilling", Order = 99} },
            //{ "UAH", new CurrencyNameAndCode { Code = "UAH", Name = "Hryvnia", Order = 99} },
            //{ "AED", new CurrencyNameAndCode { Code = "AED", Name = "Dirham", Order = 99} },
            //{ "UYU", new CurrencyNameAndCode { Code = "UYU", Name = "Peso", Order = 99} },
            //{ "UZS", new CurrencyNameAndCode { Code = "UZS", Name = "Som", Order = 99} },
            //{ "VUV", new CurrencyNameAndCode { Code = "VUV", Name = "Vatu", Order = 99} },
            //{ "VEF", new CurrencyNameAndCode { Code = "VEF", Name = "Bolivar", Order = 99} },
            //{ "VND", new CurrencyNameAndCode { Code = "VND", Name = "Dong", Order = 99} },
            //{ "YER", new CurrencyNameAndCode { Code = "YER", Name = "Rial", Order = 99} },
            //{ "ZMK", new CurrencyNameAndCode { Code = "ZMK", Name = "Kwacha", Order = 99} },
            //{ "ZWD", new CurrencyNameAndCode { Code = "ZWD", Name = "Zimbabwe Dollar", Order = 99} }
        };

        public static string GetCurrencySymbolByCode(string localCurrencyCode)
        {
            var symbols = new Dictionary<string, string>()
            {
                {"pkr", "₨" },
                {"try", "₺" },
            };

            return symbols[localCurrencyCode];
        }

        public static List<CountrySpecificGoldUnit> CountrySpecificGoldUnits = new List<CountrySpecificGoldUnit>
        {
            new CountrySpecificGoldUnit
            {
               Name = "24k 10 Gram Gold",
               LocalCurrencyCode = "PKR",
               Unit = 10,
               Order = 5,
               LocalCurrencySymbol = "₨"

            },
            new CountrySpecificGoldUnit
            {
               Name = "22k 10 Gram Gold",
               LocalCurrencyCode = "PKR",
               Unit = 10 * 0.91666,
               Order = 6,
               LocalCurrencySymbol = "₨"

            },
            new CountrySpecificGoldUnit
            {
               Name = "24k Per Tola",
               LocalCurrencyCode = "PKR",
               Unit = 11.6638038,
               Order = 7,
               LocalCurrencySymbol = "₨"

            },
            new CountrySpecificGoldUnit
            {
               Name = "22k Per Tola",
               LocalCurrencyCode = "PKR",
               Unit = 11.6638038 * 0.91666,
               Order = 8,
               LocalCurrencySymbol = "₨"

            },
            new CountrySpecificGoldUnit
            {
               Name = "Gram Altın",
               LocalCurrencyCode = "TRY",
               Unit = 1,
               Order = 5,
               LocalCurrencySymbol = "₺"

            },
            new CountrySpecificGoldUnit
            {
               Name = "Ceyrek",
               LocalCurrencyCode = "TRY",
               Unit = 0.91666 * 1.754,
               Order = 6,
               LocalCurrencySymbol = "₺"

            }
        };
    }
}