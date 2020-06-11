using System;
using System.Collections.Generic;


namespace CurrencyApi.Models
{
    public class CurrencyPairNameValue
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string LocalCurrencySymbol { get; set; }
        public LinkedList<CurrencyValue> Values { get; set; }
        public int Order { get; set; }
        public int FxOrder { get; set; }
        public string FxId { get; set; }
        public string Paragraph
        {
            get
            {
                return string.Format("Today {0} rates in Pakistan started at the rate of {1}{2} and {3} to {4}{5}",
                    string.IsNullOrEmpty(Name) ? Code : Name,
                    LocalCurrencySymbol,
                    string.Format("{0:N}", Values.First.Value.Value),
                    Values.First.Value.Value < Values.Last.Value.Value ? "increased" : "decreased",
                    LocalCurrencySymbol,
                    string.Format("{0:N}", Values.Last.Value.Value)
                    );
            }
        }
        //public string ChangeRateColour { get {
        //        if(ChangeRate > 0)
        //        {
        //            return "green";
        //        }else if(ChangeRate < 0)
        //        {
        //            return "red";
        //        }
        //        else
        //        {
        //            return "normal";
        //        }
        //    } }
        //public string RealTimeChangeColour
        //{
        //    get
        //    {
        //        if (Values.Last.Previous == null) return "normal";
        //        var change = Math.Round(Values.Last.Value.Value - Values.Last.Previous.Value.Value, 3);
        //        if ( change > 0)
        //        {
        //            return "green"; 
        //        }
        //        else if (change < 0)
        //        {
        //            return "red";
        //        }
        //        else
        //        {
        //            return "normal";
        //        }

        //    }
        //}
        //public decimal ChangeRate
        //{
        //    get
        //    {
        //        return GetChangeRate(Values.Last.Value.Value, Values.First.Value.Value, 4);
        //    }
        //}

        //private decimal GetChangeRate(decimal d1, decimal d2, int decimalPlace)
        //{
        //    var change = d1 - d2;
        //    return Math.Round((decimal)change, decimalPlace) * 100;
        //}
        public CurrencyPairNameValue()
        {
        }

    }
}
